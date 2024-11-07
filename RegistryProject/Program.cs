using Microsoft.Win32;

//RegistryKey localMachineKey = Registry.LocalMachine;
//RegistryKey currentUser = Registry.CurrentUser;
//RegistryKey helloKey = currentUser.CreateSubKey("HelloKey");
//helloKey.SetValue("login", "masha");
//helloKey.SetValue("password","1234");
//helloKey.Close();

//RegistryKey currentUserKey = Registry.CurrentUser;
//RegistryKey helloKey = currentUserKey.OpenSubKey("HelloKey",true);
//RegistryKey subKeyHello = helloKey.CreateSubKey("SubHelloKey");
//subKeyHello.SetValue("val","23");
//subKeyHello.Close();
//helloKey.Close();

//RegistryKey cu = Registry.CurrentUser;
//RegistryKey helloKey = cu.OpenSubKey("HelloKey");
//string login = helloKey.GetValue("login").ToString();
//string password = helloKey.GetValue("Password").ToString();
//helloKey.Close();
//Console.WriteLine(login);
//Console.WriteLine(password);


RegistryKey cu = Registry.CurrentUser;
RegistryKey helloKey = cu.OpenSubKey("HelloKey",true);
helloKey.DeleteSubKey("SubHelloKey");
helloKey.DeleteValue("login");
helloKey.Close();
cu.DeleteSubKey("HelloKey");




