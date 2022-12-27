using System;

using SFML.Graphics;
using SFML.Window;


namespace Rect
{
    internal class Program
    {
        static RenderWindow window;
       
        
       

        static void Main(string[] args)
        {

            window = new RenderWindow(new VideoMode(800, 600), "Rect");
            window.Closed += Window_Closed;
            window.SetFramerateLimit(60);

            

            Game game = new Game();
            

            while (window.IsOpen == true)
            {
                window.Clear(new Color(230,230,230));

                

                window.DispatchEvents();

                

                game.UpDate(window);

                window.Display();


            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
} 

