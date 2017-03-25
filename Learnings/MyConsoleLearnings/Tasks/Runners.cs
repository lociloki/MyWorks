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

        public async Task MyMethodAsync()
        {
            Task<int> longRunningTask = LongRunningOperationAsync();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here

            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            Console.WriteLine(result);
        }

        public async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
        {
            await Task.Delay(3000); //1 seconds delay
            return 1;
        }
    }
}
