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
    }
}
