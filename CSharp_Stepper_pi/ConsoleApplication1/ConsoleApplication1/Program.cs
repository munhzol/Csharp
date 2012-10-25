using System;
using LibPiGpio;
using System.Threading;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            // setup the stepper motor and specify which GPIO pins to use.
            Stepper motor = new Stepper(24, 25, 8, 7);

            Console.WriteLine("Stepper Motor stepup complete");
            Console.WriteLine("Press up or Down Arrow keys to drive motor forwards or reverse.");
           
            // start checking for key presses
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                

                if (keyinfo.Key.ToString()=="UpArrow"){
                    motor.forward(1);
                
                };

                if (keyinfo.Key.ToString() == "DownArrow")
                {
                    motor.reverse(1);

                };
            }
            while (keyinfo.Key != ConsoleKey.X);
         
        }
    
    
    }


}
