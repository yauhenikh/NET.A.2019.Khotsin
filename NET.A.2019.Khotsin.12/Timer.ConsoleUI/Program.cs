using System;
using TimerLibrary;

namespace TimerConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting timer for 5 seconds...");

            Timer timer = new Timer(5000);
            TimerEventUser user = new TimerEventUser(timer);

            timer.Start();

            Console.ReadLine();
        }
    }
}
