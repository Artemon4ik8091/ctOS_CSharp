using Cosmos.Core.Memory;
using Cosmos.System.Graphics;
using Cosmos.System;
using System;
using Sys = Cosmos.System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IL2CPU.API.Attribs;
using Cosmos.Debug.Kernel;
using Cosmos.System.Graphics.Fonts;
using System.Drawing;

namespace ctOS
{
    internal class gui
    {
        Canvas canvas;
        private readonly Bitmap bitmap = new Bitmap(10, 10,
                new byte[] { 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0,
                    255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255,
                    23, 59, 88, 255, 0, 255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255, 23, 59, 88, 255, 0, 255, 243, 255, 0,
                    255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255, 153, 57, 12, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
                    243, 255, 0, 255, 243, 255, 153, 57, 12, 255, 23, 59, 88, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243,
                    255, 0, 255, 243, 255, 0, 255, 243, 255, 72, 72, 72, 255, 72, 72, 72, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0,
                    255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 72, 72,
                    72, 255, 72, 72, 72, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
                    243, 255, 10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 10, 66, 148, 255, 10, 66, 148, 255,
                    10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
                    243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148,
                    255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, }, ColorDepth.ColorDepth32);
        public void GuiMain()
        {
            /*
            You don't have to specify the Mode, but here we do to show that you can.
            To not specify the Mode and pick the best one, use:
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            */
            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));

            // This will clear the canvas with the specified color.
            canvas.Clear(Color.Blue);
            try
            {
                // A red Point
                canvas.DrawPoint(Color.Red, 69, 69);

                // A GreenYellow horizontal line
                canvas.DrawLine(Color.GreenYellow, 250, 100, 400, 100);

                // An IndianRed vertical line
                canvas.DrawLine(Color.IndianRed, 350, 150, 350, 250);

                // A MintCream diagonal line
                canvas.DrawLine(Color.MintCream, 250, 150, 400, 250);

                // A PaleVioletRed rectangle
                canvas.DrawRectangle(Color.PaleVioletRed, 350, 350, 80, 60);

                // A LimeGreen rectangle
                canvas.DrawRectangle(Color.LimeGreen, 450, 450, 80, 60);

                // A bitmap

                Bitmap bitmap2 = new Bitmap(40, 40, ColorDepth.ColorDepth32);
                canvas.DrawImage(bitmap2, 20, 20);

                canvas.DrawImage(bitmap, 100, 150);

                //string text = "Hello world";

                //Font font = new Font("Arial", 16);


                //canvas.DrawString("Hello world", font: ("Times New Roman", 24), Color.White, 1, 1);



                canvas.Display(); // Required for something to be displayed when using a double buffered driver

                System.Console.ReadKey();
                Sys.Power.Shutdown();
            }
            catch (Exception e)
            {
                //Debugger.Send("Exception occurred: " + e.Message);
                Sys.Power.Shutdown();
            }
        }
    }
}
