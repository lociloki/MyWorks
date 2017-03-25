using System;

namespace Tasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DoWorkAsync();
            Console.ReadKey();
        }

        private static void DoWorkAsync()
        {
            var myRunners = new Runners();
            myRunners.MyMethodAsync();
        }

    }
}
