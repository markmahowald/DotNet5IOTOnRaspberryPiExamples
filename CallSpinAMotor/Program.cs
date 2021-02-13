using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CallSpinAMotor
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "/home/pi/SpinAMotor/SpinAMotor";
            List<string> spinArguments = new List<string>(){ "1", "2", "-2" };

            string argString = "";
            foreach (var argument in spinArguments)
            {
                argString += argument + " ";
            }

            var processInfo = new ProcessStartInfo(arguments: argString, fileName: fileName) ;

            Process proc = new Process();
            proc.StartInfo = processInfo;
            proc.Start();
            Console.WriteLine("ran the hell out of that process");
        }

    }
}
