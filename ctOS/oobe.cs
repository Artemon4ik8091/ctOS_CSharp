using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;

namespace ctOS
{
    internal class oobe
    {
        // code for oobe
        public void main_oobe(string filename, string current_directory)
        {
            var core = new Kernel();

            //System.Console.Write("Enter filename: ");
            //filename = System.Console.ReadLine();

            try
            {
                bool test = VFSManager.FileExists(@"0:\sys\oobe.cfg");
                System.Console.WriteLine("Result: " + test);
                if (test == true)
                {
                    System.Console.WriteLine("File Found!");
                    //string file_data = core.read_file(@"0:\sys\oobe.cfg");
                    core.write_file(@"0:\sys\oobe.cfg", "Writed text!");
                    string file_data = core.read_file(@"0:\sys\oobe.cfg");
                    System.Console.WriteLine(file_data);
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