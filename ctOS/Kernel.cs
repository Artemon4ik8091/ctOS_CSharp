using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;
using System.Drawing;
using System.IO;
using IL2CPU.API.Attribs;
using Cosmos.System;
using System.Buffers;
using Cosmos.Core.Memory;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using System.Reflection.Metadata;
using Cosmos.System.FileSystem.FAT;
using System.Runtime.CompilerServices;
using System.Threading;


namespace ctOS
{
    public class Kernel : Sys.Kernel
    {
        //Sys.FileSystem.CosmosVFS fs;
        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
        string current_directory = @"0:\";
        string old_current_directory = "";
        string file = "";
        string oobe_cfg_file = @"0:\sys\oobe.cfg";
        string user_cfg_file = @"0:\sys\user.cfg";
        string username = "";
        protected override void BeforeRun()
        {
            
            MouseManager.ScreenWidth = 1280;
            MouseManager.ScreenHeight = 800;
            MouseManager.X = 1280 / 2;
            MouseManager.Y = 800 / 2;
            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            var Logos = new Logos();
            var net = new net();
            Logos.boot_animation();
            ClearConsole();
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("devOS booted successfully.");
            System.Console.ForegroundColor = ConsoleColor.White;
            //System.Console.WriteLine("+--------------------------------------+");
            //System.Console.WriteLine("| To enable ethernet enter \"setauto\"   |");
            //System.Console.WriteLine("+--------------------------------------+");
            net.net_auto_setup_IPv4();
            
            
        }

        protected override void Run()
        {
            
            //username = Get_username();
            System.Console.ForegroundColor = ConsoleColor.White;
            //System.Console.Write("devOS {" + username + "} [" + current_directory + "] >> ");
            System.Console.Write("devOS [" + current_directory + "] >> ");
            old_current_directory = current_directory;
            var oobe = new oobe();
            //oobe.main_oobe();
            Commands();

        }

        public void Commands()
        {
            var input = System.Console.ReadLine();
            string filename = "";
            string dirname = "";
            var Logos = new Logos();
            var net = new net();
            switch (input)
            {
                default:
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Unknown command: " + input);
                    break;
                case "setman":
                    net.net_manual_setup_IPv4(); 
                    break;
                //case "setauto":
                //    net.net_auto_setup_IPv4();
                //    break;
                case "getip":
                    try
                    {
                        string ip2 = net.GetIP();
                        System.Console.WriteLine("Local IP: " + ip2);
                    }
                    catch (Exception ex)
                    {
                        Error(2);
                        System.Console.WriteLine(ex.ToString());
                    }
                    break;
                case "ping":
                    System.Console.Write("Enter URL: ");
                    string site = System.Console.ReadLine();
                    for(int i = 0; i < 4; i++)                    
                    {
                        try
                        {
                            System.Console.WriteLine("Pinged! IP: " + net.dns(site));
                        }
                        catch(Exception ex)
                        {
                            System.Console.WriteLine("Ping Error!");
                            System.Console.WriteLine(ex.ToString());
                        }
                        Thread.Sleep(500);
                    }
                    System.Console.WriteLine();
                    break;
                case "gui":
                    var guicl = new gui();
                    guicl.GuiMain();
                    break;
                case "logo":
                    Logos.logo();
                    break;
                case "uname":
                    string ip = net.GetIP();
                    System.Console.WriteLine("ctOS " + ip + " 1.0 Cosmos Kernel Version 20221121");
                    break;
                case "simerr1":
                    Error(1);
                    System.Console.WriteLine("The error was caused by the user.");
                    break;
                case "simerr2":
                    Error(2);
                    System.Console.WriteLine("The error was caused by the user.");
                    break;
                case "help":
                    System.Console.WriteLine("Help command:");
                    System.Console.WriteLine(@"
clear - clean terminal
echo - print text
calc - calculator
shutdown - shutdown PC
reboot - reboot PC
ver - system info
cd - change directory
ls - show files and folders
mkdir - make directory
mkfile - make file
delfile - delete file
deldir - delete directory
simerr1 - simulate user error
simerr2 - simulate system error
datetime - print date and time
ping - ping website
setauto - auto setup ethernet
logo - logo
getip - print your IP Address
");
                    //System.Console.ForegroundColor = ConsoleColor.Yellow;
                    //System.Console.WriteLine("ATTENTION! Commands for file system NOT STABLE!");
                    break;
                case "clear":
                    ClearConsole();
                    break;
                case "datetime":
                    System.Console.WriteLine(DateTime.Now);
                    break;
                case "echo":
                    System.Console.Write("Enter text: ");
                    var buffer = System.Console.ReadLine();
                    System.Console.WriteLine(buffer);
                    break;
                case "calc":
                    var calcu = new Calc();
                    calcu.CalcMain();
                    break;
                case "shutdown":
                    Cosmos.System.Power.Shutdown();
                    break;
                case "reboot":
                    Cosmos.System.Power.Reboot();
                    break;
                case "ver":
                    //var Logos = new Logos();
                    Logos.logo();
                    Sys_Info();
                    break;
                case "mkfile":
                    System.Console.Write("Enter file name: ");
                    filename = System.Console.ReadLine();
                    fs.CreateFile(@current_directory + @"\" + @filename);
                    break;
                case "mkdir":
                    System.Console.Write("Enter directory name: ");
                    dirname = System.Console.ReadLine();
                    fs.CreateDirectory(@current_directory + @dirname);
                    break;
                case "delfile":
                    try
                    {
                        System.Console.Write("Enter file name: ");
                        filename = System.Console.ReadLine();
                        VFSManager.DeleteFile(current_directory + @"\" + filename);
                    }
                    catch (Exception e)
                    {
                        Error(1);
                        System.Console.WriteLine("Error: File not found.");
                        System.Console.WriteLine(e.ToString());
                    }
                    break;
                case "deldir":
                    try
                    {
                        System.Console.Write("Enter directory name: ");
                        dirname = System.Console.ReadLine();
                        VFSManager.DeleteDirectory(current_directory + dirname, false);
                    }
                    catch (Exception e)
                    {
                        Error(1);
                        System.Console.WriteLine("Error: Directory not found.");
                        System.Console.WriteLine(e.ToString());
                    }
                    break;
                case "cd":
                    System.Console.Write("Enter patch or press Return to 0:\\ ");
                    string ch_directory = System.Console.ReadLine();
                    if (ch_directory == "")
                    {
                        current_directory = "0:\\";
                    }
                    if (ch_directory != "")
                    {
                        current_directory = old_current_directory + @"\" + ch_directory;
                    }
                    break;
                case "ls":
                    ls();
                    break;
                case "cat":
                    try
                    {
                        System.Console.Write("Enter file name: ");
                        filename = System.Console.ReadLine();
                        System.Console.WriteLine(File.ReadAllText(current_directory + @"\" + filename));
                    }
                    catch (Exception e)
                    {
                        Error(1);
                        System.Console.WriteLine(e.ToString());
                        break;
                    }
                    break;
                case "wrfile":
                    try
                    {
                        System.Console.Write("Enter file name: ");
                        filename = System.Console.ReadLine();
                        System.Console.Write("Enter text: ");
                        buffer = System.Console.ReadLine();
                        File.WriteAllText(current_directory + @"\" + filename, buffer);
                    }
                    catch (Exception e)
                    {
                        Error(1);
                        System.Console.WriteLine(e.ToString());
                        break;
                    }
                    break;
                case "my_app":
                    My_App();
                    break;
                case "test_app":
                    Test_app();
                    break;
                case "reset":
                    var reset = new reset();
                    reset.reset_main();
                    break;
                case "oobe":
                    //System.Console.Write("Enter filename: ");
                    //filename = System.Console.ReadLine();
                    //oobe(filename);

                    var oobe = new oobe();
                    oobe.main_oobe();
                    break;
                case "username":
                    string result = Get_username();
                    System.Console.WriteLine(result);
                    break;
                case "":
                    break;
            }
        }

        public void Error(int variable)
        {
            if (variable == 1)
            {
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(@"+--------------------------------------------------------+
| A non-critical system error has occurred.              |
| You may have made a mistake when entering a parameter  | 
| for the command. Try again.                            |
+--------------------------------------------------------+
Details about the error:");
            }
            if (variable == 2)
            {
                System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine(@"+--------------------------------------------------------+
| A non-critical system error has occurred.              |
| An error occurred in the application.                  |
| Please inform the developer of this software about it. |
+--------------------------------------------------------+
Details about the error:");
            }
        }

        

        public void ClearConsole()
        {
            System.Console.Clear();
            System.Console.BackgroundColor = ConsoleColor.DarkMagenta;
            System.Console.WriteLine("ctOS                                                         " + DateTime.Now);
            System.Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Sys_Info()
        {
            //Logo();
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("This is SDK Prototype to ctOS");
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            string CPUbrand = Cosmos.Core.CPU.GetCPUBrandString();
            System.Console.WriteLine("CPU: "+ CPUbrand);
            string CPUvendor = Cosmos.Core.CPU.GetCPUVendorName();
            System.Console.WriteLine("CPU Vendor: " + CPUvendor);
            uint amount_of_ram = Cosmos.Core.CPU.GetAmountOfRAM();
            System.Console.WriteLine("Amount RAM: " + amount_of_ram);
            ulong available_ram = Cosmos.Core.GCImplementation.GetAvailableRAM();
            System.Console.WriteLine("Available RAM: " + available_ram + " MB");
            uint used_ram = Cosmos.Core.GCImplementation.GetUsedRAM();
            uint buffer_ram = used_ram / 1024;
            used_ram = buffer_ram;
            System.Console.WriteLine("Used RAM: " + used_ram + " KB");
        }

        public void ls()
        {
            try
            {
                var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(current_directory);
                foreach (var directoryEntry in directory_list)
                {
                    try
                    {
                        var entry_type = directoryEntry.mEntryType;
                        if (entry_type == Sys.FileSystem.Listing.DirectoryEntryTypeEnum.File)
                        {
                            System.Console.WriteLine("| <File>        " + directoryEntry.mName);
                        }
                        if (entry_type == Sys.FileSystem.Listing.DirectoryEntryTypeEnum.Directory)
                        {
                            System.Console.WriteLine("| <Directory>   " + directoryEntry.mName);
                        }
                    }
                    catch (Exception e)
                    {
                        Error(2);
                        System.Console.WriteLine("Error: Directory not found.");
                        System.Console.WriteLine(e.ToString());
                    }
                }
                System.Console.WriteLine("===================================================");
                var available_space_b = fs.GetAvailableFreeSpace(@"0:\");
                var available_space_kb = available_space_b / 1024;
                var available_space_mb = available_space_kb / 1024;
                System.Console.WriteLine("Available Free Space: " + available_space_mb + " MB");
                var fs_type = fs.GetFileSystemType(@"0:\");
                System.Console.WriteLine("File System Type: " + fs_type);
            }
            catch (Exception ex)
            {
                Error(2);
                System.Console.WriteLine(ex.ToString());
            }
        }

        public void My_App()
        {
            var app = new NewApp();
            app.AppMain();
        }

        public string read_file(string path_to_file)
        {
            string data = File.ReadAllText(@path_to_file);
            return data;
        }

        public void write_file(string path_to_file, string data)
        {
            File.WriteAllText(@path_to_file, @data);
        }

        public void create_file(string path_to_file)
        {
            fs.CreateFile(@path_to_file);
        }
        
        public void create_dir(string path)
        {
            fs.CreateDirectory(@path);
        }

        public void del_file(string path_to_file)
        {
            VFSManager.DeleteFile(path_to_file);
        }

        public void del_dir(string path, bool recursive)
        {
            VFSManager.DeleteDirectory(path, recursive);
        }

        public void shutdown()
        {
            Power.Shutdown();
        }

        public void reboot()
        {
            Power.Reboot();
        }

        public string Get_username()        //не работает нормально, лучше не юзайте
        {
            string result = read_file(user_cfg_file);
            return result;
        }

        public void Test_app()
        {
            //testing
            //VFSManager.FormatDisk();
            System.Console.WriteLine(VFSManager.GetVolume(current_directory));
            
        }
    }
}