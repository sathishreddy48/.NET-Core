using System;
using System.Threading.Tasks;

namespace SchedulingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Run(() =>
            {
                return 10;
            });
           
            task.ContinueWith((i) =>
            {
                Console.WriteLine("TasK Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask = task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
            Console.ReadKey();
        }
    }
}
