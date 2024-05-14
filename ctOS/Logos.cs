using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ctOS
{
    internal class Logos
    {
        public void white()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void black()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void logo()
        {
            Console.WriteLine();
            white();
            Console.Write(@"         _   "); black(); Console.WriteLine(@"  ____    _____ "); white();
            Console.Write(@"        | |  "); black(); Console.WriteLine(@" / __ \  / ____|"); white();
            Console.Write(@"    ___ | |_ "); black(); Console.WriteLine(@"| |  | || (___  "); white();
            Console.Write(@"   / __|| __|"); black(); Console.WriteLine(@"| |  | | \___ \ "); white();
            Console.Write(@"  | (__ | |_ "); black(); Console.WriteLine(@"| |__| | ____) |"); white();
            Console.Write(@"   \___| \__)"); black(); Console.WriteLine(@" \____/ |_____/");
            Console.WriteLine();
        }

        public void boot_animation()
        {
            black();
            Thread.Sleep(1500);
            Console.Clear();

            Console.WriteLine("\n\n\nModule ");
            Thread.Sleep(500);
            Console.Clear();        //Initialized
            Console.WriteLine("\n\n\nModule ***********");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule I**********");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule In*********");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule Ini********");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule Init*******");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule Initi******");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule Initia*****");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule Initial****");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule Initiali***");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule Initializ**");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule Initialize*");

            Thread.Sleep(125);
            Console.Clear();
            Console.WriteLine("\n\n\nModule Initialized");

            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("                  ");
            Console.WriteLine("                  ");
            Console.WriteLine("                  ");
            Console.WriteLine("                  ");
            Thread.Sleep(500);
            black();
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("  ");
            Console.WriteLine("      ");
            black();
            Console.WriteLine("System Loading");
            white();
            Console.WriteLine("          ");
            black();
            Console.WriteLine("");
            Thread.Sleep(175);
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("  ");
            Console.WriteLine("       ");
            black();
            Console.WriteLine("System Loading");
            white();
            Console.WriteLine("           ");
            black();
            Console.WriteLine("");
            Thread.Sleep(175);
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("  ");
            Console.WriteLine("        ");
            black();
            Console.WriteLine("System Loading");
            white();
            Console.WriteLine("            ");
            black();
            Console.WriteLine("");
            Thread.Sleep(175);
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("  ");
            Console.WriteLine("         ");
            black();
            Console.WriteLine("System Loading");
            white();
            Console.WriteLine("             ");
            black();
            Console.WriteLine("");
            Thread.Sleep(175);
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("  ");
            Console.WriteLine("          ");
            black();
            Console.WriteLine("System Loading");
            white();
            Console.WriteLine("              ");
            black();
            Console.WriteLine("");
            Thread.Sleep(175);
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("  ");
            Console.WriteLine("           ");
            black();
            Console.WriteLine("System Loading");
            white();
            Console.WriteLine("               ");
            black();
            Console.WriteLine("");
            Thread.Sleep(175);
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("  ");
            Console.WriteLine("            ");
            black();
            Console.WriteLine("System Loading");
            white();
            Console.WriteLine("                ");
            black();
            Console.WriteLine("");
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("  ");
            Console.WriteLine("            ");
            white();
            Console.WriteLine("              ");
            white();
            Console.WriteLine("                ");
            black();
            Console.WriteLine("");
            Thread.Sleep(400);
            Console.Clear();

            Console.WriteLine();
            white();
            Console.WriteLine("  ");
            Console.WriteLine("            ");
            white();
            Console.WriteLine("              ");
            white();
            Console.WriteLine("                ");
            black();
            Console.WriteLine("");
            Thread.Sleep(400);
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            white();
            Console.WriteLine("              ");
            black();
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            white();
            Console.WriteLine("              ");
            black();
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(200);
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            white();
            Console.WriteLine("              ");
            black();
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(200);
            Console.Clear();
        }

        public void animation()
        {
            Thread.Sleep(3000);
            Console.Clear();
            Thread.Sleep(450);
            Console.WriteLine("[           ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[=          ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[==         ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[===        ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[====       ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[=====      ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[======     ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[=======    ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[========   ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[=========  ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[========== ]");
            Thread.Sleep(450);
            Console.Clear();
            Console.WriteLine("[===========]");
            Thread.Sleep(450);
        }
    }
}
