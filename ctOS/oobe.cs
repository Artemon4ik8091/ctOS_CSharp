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
        public void main_oobe(string filename, string current_directory)
        {
            var core = new Kernel();
            string oobe_cfg_file_data = "";
            string oobe_cfg_file = @"0:\sys\oobe.cfg";
            try
            {
                bool test = VFSManager.FileExists(@"0:\sys\oobe.cfg");
                if (test == true)
                {
                    System.Console.WriteLine("File Found!");
                    oobe_cfg_file_data = core.read_file(oobe_cfg_file);
                    if (oobe_cfg_file_data == "true")
                    {
                        System.Console.WriteLine("OOBE skip...");
                    }
                    if (oobe_cfg_file_data == "false")
                    {
                        System.Console.WriteLine("OOBE Starting...");
                        core.write_file(oobe_cfg_file, "true");
                        System.Console.WriteLine("Success!");
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