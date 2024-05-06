using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctOS
{
    internal class reset
    {
        public void reset_main()
        {
            string oobe_cfg_file = @"0:\sys\oobe.cfg";
            string user_cfg_file = @"0:\sys\user.cfg";
            bool user_cfg_ping = true;
            bool oobe_cfg_ping = true;
            var core = new Kernel();
            string want = "";

            System.Console.WriteLine("Do you want reset system files? (Y/N)");
            want = System.Console.ReadLine();
            if (want != "N" || want != "n")
            {
                System.Console.WriteLine("Exiting...");
            }
            if (want == "Y" || want == "y")
            {
                user_cfg_ping = VFSManager.FileExists(user_cfg_file);
                Console.WriteLine(user_cfg_ping);
                oobe_cfg_ping = VFSManager.FileExists(oobe_cfg_file);
                Console.WriteLine(oobe_cfg_ping);
                if (user_cfg_ping == false)
                {
                    core.create_file(user_cfg_file);
                    Console.WriteLine("Success.");
                }
                if (oobe_cfg_ping == false)
                {
                    core.create_file(oobe_cfg_file);
                    Console.WriteLine("Success.");
                }
                System.Console.WriteLine("Reseting...");
                core.write_file(oobe_cfg_file, "false");
                core.write_file(user_cfg_file, "NULL");
                Console.WriteLine("Success.");
            }
        }
    }
}
