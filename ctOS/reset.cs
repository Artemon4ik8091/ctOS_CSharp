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
            var core = new Kernel();
            string want = "";

            System.Console.WriteLine("Do you want reset system files? (Y/N)");
            want = System.Console.ReadLine();
            if (want == "Y" || want == "y")
            {
                System.Console.WriteLine("Reseting...");
                core.write_file(oobe_cfg_file, "false");
            }
            if (want != "N" || want != "n")
            {
                System.Console.WriteLine("Exiting...");
            }
        }
    }
}
