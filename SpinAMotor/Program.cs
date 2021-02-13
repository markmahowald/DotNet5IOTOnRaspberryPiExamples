using System;
using System.Threading;
using Iot.Device.Uln2003;

namespace SpinAMotor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pinout for Raspberry Pi 3
            const int pin1 = 17;
            const int pin2 = 27;
            const int pin3 = 22;
            const int pin4 = 10;
            int degreesToRotate = 0;
            bool parsable = Int32.TryParse(args[0], out degreesToRotate);

            int[] parsedArgs = Array.ConvertAll(args, int.Parse);

            using (Uln2003 motor = new Uln2003(pin1, pin2, pin3, pin4))
            {

                Console.WriteLine($"The number of args is {args.Length}.");

                foreach (var parsedArg in parsedArgs)
                {
                    Console.WriteLine(parsedArg);
                }
                try
                {

                    motor.RPM = 15;
                    motor.Mode = StepperMode.HalfStep;
                    foreach (int rotationArg in parsedArgs)
                    {
                        motor.Step(rotationArg*4096);

                        Thread.Sleep(1000*rotationArg);
           
                    }



                    //int i = 0;
                    //while (i<1)
                    //{
                    //    // Set the motor speed to 15 revolutions per minute.
                    //    motor.RPM = 15;
                    //    // Set the motor mode.  
                    //    motor.Mode = StepperMode.HalfStep;
                    //    // The motor rotate 2048 steps clockwise (180 degrees for HalfStep mode).
                    //    motor.Step(2048);

                    //    motor.Mode = StepperMode.FullStepDualPhase;
                    //    motor.RPM = 8;
                    //    // The motor rotate 2048 steps counterclockwise (360 degrees for FullStepDualPhase mode).
                    //    motor.Step(-2048);

                    //    motor.Mode = StepperMode.HalfStep;
                    //    motor.RPM = 1;
                    //    motor.Step(4096);
                    //    i++;
                    //}
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    //motor.Stop();
                    //motor.Dispose();
                }
            }
        }
    }
}
