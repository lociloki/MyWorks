using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    internal class Runners
    {
        internal void TaskRunner()
        {
            List<string> myString = new List<string>() { "this", "is", "a", "sample" };

            myString.ForEach(item =>
            Task.Run(() =>
           Console.WriteLine(item.First() + "    " + Thread.CurrentThread.ManagedThreadId)
            ));
            Console.ReadKey();
        }

        internal async void AsyncRunner()
        {
            Console.WriteLine("Method started");
            Task<int> x = DoWork();
            Console.WriteLine("Writing ");
            Console.WriteLine("Writing ");
            Console.WriteLine("Writing ");
            Console.WriteLine("Writing ");
            Console.WriteLine("Writing ");
            int result = await x;
            Console.WriteLine("Int is " + result);
        }

        private async Task<int> DoWork()
        {
            int returnValue = 0;
            for (int i =1; i<22222; i++)
            {
                if (i == 22222) returnValue = i;
            }
            return returnValue;
        }
    }
}
