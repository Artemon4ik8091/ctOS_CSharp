using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.FileSystem;

namespace ctOS
{
    internal class oobe
    {
        // code for oobe
        public void main_oobe()
        {
            var core = new Kernel();
            string oobe_cfg_file = @"0:\sys\oobe.cfg";
            string oobe_cfg_file_data = "";
            string user_cfg_file = @"0:\sys\user.cfg";
            string user_cfg_file_data = "";
            try
            {
                bool oobe_cfg_ping = VFSManager.FileExists(oobe_cfg_file);
                bool user_cfg_ping = VFSManager.FileExists(user_cfg_file);
                if (oobe_cfg_ping == false || user_cfg_ping == false)
                {
                    System.Console.WriteLine("Files not found.");
                }
                if (oobe_cfg_ping == true && user_cfg_ping == true)
                {
                    //System.Console.WriteLine("Files Found!");
                    oobe_cfg_file_data = core.read_file(oobe_cfg_file);
                    if (oobe_cfg_file_data == "true")
                    {
                        //System.Console.WriteLine("OOBE skip...");
                    }
                    if (oobe_cfg_file_data == "false")
                    {
                        System.Console.WriteLine("OOBE Starting...");
                        Console.Write("Enter username: ");
                        string username = Console.ReadLine();
                        core.write_file(user_cfg_file, username);
                        core.write_file(oobe_cfg_file, "true");
                        System.Console.WriteLine("Success!");
                        System.Console.WriteLine("Press any key..");
                    }
                }
            }
            catch (Exception ex)
            {
                core.Error(2);
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
}