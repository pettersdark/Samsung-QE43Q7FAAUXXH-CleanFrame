using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
class GamesStartupControl {
 const string Operation="http://tizen.org/appcontrol/operation/main";
 const string Target="YourGames1.CleanFrame";
 static readonly string[] Keys={"db/appfw/home_appid","db/appfw/startup_appid","db/appfw/booting_appid_backup","db/first_screen/type"};
 const string AutoKey="db/menu/smart_hub/ontvsetting/auto_start";
 [DllImport("libbundle.so.0")] static extern IntPtr bundle_create();
 [DllImport("libbundle.so.0")] static extern void bundle_free(IntPtr b);
 [DllImport("libaul.so.0")] static extern int aul_svc_set_operation(IntPtr b,string op);
 [DllImport("libaul.so.0")] static extern int aul_get_default_app(IntPtr b,out IntPtr app);
 [DllImport("libapp-context-manager-common.so")] static extern byte util_is_appbooting_supported_webapp_byappid(string app);
 [DllImport("libcapi-appfw-app-operation-tv.so.0")] static extern int app_operation_set_current_app(string op,string app);
 [DllImport("libvconf.so.0")] static extern IntPtr vconf_get_str(string key);
 [DllImport("libvconf.so.0")] static extern int vconf_get_int(string key,out int value);
 [DllImport("libc")] static extern uint getuid();
 [DllImport("libc")] static extern void free(IntPtr ptr);
 public class Snapshot {public string Home{get;set;} public Dictionary<string,string> Strings{get;set;} public int Autostart{get;set;} public uint Uid{get;set;} public int BootSupported{get;set;}}
 static string ReadString(string key){IntPtr p=vconf_get_str(key);if(p==IntPtr.Zero)throw new Exception("Cannot read "+key);try{return Marshal.PtrToStringAnsi(p);}finally{free(p);}}
 static string Home(){IntPtr b=bundle_create();if(b==IntPtr.Zero)throw new Exception("No bundle");try{if(aul_svc_set_operation(b,Operation)!=0)throw new Exception("Cannot set query operation");IntPtr p;if(aul_get_default_app(b,out p)!=0||p==IntPtr.Zero)throw new Exception("Cannot read Home operation");try{return Marshal.PtrToStringAnsi(p);}finally{free(p);}}finally{bundle_free(b);}}
 static Snapshot Query(){var s=new Snapshot{Home=Home(),Strings=new Dictionary<string,string>(),Uid=getuid(),BootSupported=util_is_appbooting_supported_webapp_byappid(Target)};foreach(var k in Keys)s.Strings[k]=ReadString(k);int v;if(vconf_get_int(AutoKey,out v)!=0)throw new Exception("Cannot read autostart");s.Autostart=v;return s;}
 static void SetHome(string value){if(app_operation_set_current_app(Operation,value)!=0||Home()!=value)throw new Exception("Home operation write/readback failed");}

 static void CheckSnapshot(Snapshot s){if(s==null||string.IsNullOrWhiteSpace(s.Home)||s.Strings==null||s.Strings.Count!=Keys.Length||(s.Autostart!=0&&s.Autostart!=1))throw new Exception("Invalid original snapshot");foreach(var k in Keys)if(!s.Strings.ContainsKey(k)||string.IsNullOrWhiteSpace(s.Strings[k]))throw new Exception("Missing original setting: "+k);}


 [DllImport("libvconf.so.0")] static extern int vconf_set_str(string key,string value);
 [DllImport("libvconf.so.0")] static extern int vconf_set_int(string key,int value);
 static readonly string[] StartupKeys={"db/appfw/home_appid","db/appfw/startup_appid","db/appfw/booting_appid_backup"};
 static void SetString(string key,string value){if(vconf_set_str(key,value)!=0||ReadString(key)!=value)throw new Exception("Write/readback failed: "+key);}
 static void SetAuto(int value){int v;if(vconf_set_int(AutoKey,value)!=0||vconf_get_int(AutoKey,out v)!=0||v!=value)throw new Exception("Autostart write/readback failed");}
 static void Same(Snapshot a,Snapshot b){if(a.Home!=b.Home||a.Autostart!=b.Autostart)throw new Exception("Home/autostart changed");foreach(var k in Keys)if(a.Strings[k]!=b.Strings[k])throw new Exception("Preference changed: "+k);}
 static void Restore(Snapshot s){SetAuto(s.Autostart);foreach(var k in StartupKeys)SetString(k,s.Strings[k]);System.Threading.Thread.Sleep(1200);Same(s,Query());}
 static bool Expected(Snapshot s,Snapshot original){if(s.Home!=Target||s.Autostart!=1||s.Strings["db/appfw/home_appid"]!=Target||s.Strings["db/first_screen/type"]!=original.Strings["db/first_screen/type"])return false;foreach(var k in StartupKeys)if(s.Strings[k]!=Target&&s.Strings[k]!=original.Strings[k])return false;return true;}
 static int Main(string[] args){try{
  if(IntPtr.Size!=4||getuid()!=901)throw new Exception("Expected 32-bit SDK user, no root");
  if(!File.ReadAllText("/etc/prd_info.ini").Contains("Version=T-PTMFDEUC-0090-1301.0;"))throw new Exception("Unexpected firmware");
  if(args.Length==1&&args[0]=="query"){Console.WriteLine("CLEANFRAME_HOME_JSON="+JsonSerializer.Serialize(Query()));return 0;}
  if(args.Length!=2)throw new Exception("Expected action and baseline");
  var original=JsonSerializer.Deserialize<Snapshot>(File.ReadAllText(args[1]));CheckSnapshot(original);if(original.Home!=Target||original.Uid!=901)throw new Exception("Unexpected original Home or UID");var before=Query();
  if(args[0]=="verify-baseline"){Same(original,before);Console.WriteLine("GAMES_STARTUP_BASELINE_VERIFIED");return 0;}
  if(args[0]=="restore"){if(!Expected(before,original))Same(original,before);Restore(original);Console.WriteLine("GAMES_STARTUP_RESTORED="+JsonSerializer.Serialize(Query()));return 0;}
  if(args[0]!="apply")throw new Exception("Unknown action");Same(original,before);
  if(!Directory.Exists("/opt/usr/apps/YourGames1")||before.BootSupported==0)throw new Exception("Installed app not boot eligible");
  try{SetString("db/appfw/home_appid",Target);SetAuto(1);System.Threading.Thread.Sleep(1200);var after=Query();if(!Expected(after,original))throw new Exception("Unexpected applied state");Console.WriteLine("GAMES_STARTUP_APPLIED="+JsonSerializer.Serialize(after));}
  catch{Restore(original);throw;}
  return 0;
 }catch(Exception e){Console.Error.WriteLine(e.ToString());return 1;}}
}
