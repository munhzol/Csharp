using System;
using LibPiGpio;
using System.Collections;
using System.Threading;

namespace ConsoleApplication1
{
    class Stepper
    {
        private int pina=0;
        private  int pinb=0;
        private  int pinc=0;
        private  int pind = 0;
        private  string[] graycode=new string[8]{"1000","1100","0100","0110","0010","0011","0001,","1001"};
        private string[] reversegraycode = new string[8] { "1001", "0001", "0011", "0010", "0110", "0100", "1100,", "1000" };
       public Stepper(int setpina, int setpinb, int setpinc, int setpind)
        {
            pina = setpina;
            pinb = setpinb;
            pinc = setpinc;
            pind = setpind;
            RpiGpio.SetOutputPins(new[] { setpina, setpinb, setpinc, setpind });
            RpiGpio.Pins[pina] = false;
            RpiGpio.Pins[pinb] = false;
            RpiGpio.Pins[pinc] = false;
            RpiGpio.Pins[pind] = false;
           

           
       }

        public void forward(int delay)
        {

            foreach (String value in graycode)
            {

                setPin(pina, value[0]);
                setPin(pinb, value[1]);
                setPin(pinc, value[2]);
                setPin(pind, value[3]);


                Thread.Sleep(delay);

            }
        }

        public void reverse(int delay)
        {
            foreach (String value in reversegraycode)
            {

                setPin(pina, value[0]);
                setPin(pinb, value[1]);
                setPin(pinc, value[2]);
                setPin(pind, value[3]);


                Thread.Sleep(delay);

            }
        }

        private void setPin(int pin, char value)
        {
            if (value == '0')
            {
                RpiGpio.Pins[pin] = false;

            }
            else
            {
                RpiGpio.Pins[pin] = true;

            }

        }


    }
}
