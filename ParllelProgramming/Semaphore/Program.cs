using System;
using System.Threading;

namespace Semaphore
{
    class Program
    {
        public static SemaphoreSlim semaphore = new SemaphoreSlim(0, 3);

        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread threadObject = new Thread(DoSomeTask)
                {
                    Name = "Thread " + i
                };
                threadObject.Start(i);
            }
            Console.ReadKey();
        }

        static void DoSomeTask(object id)
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter into Critical Section for processing");
            try
            {
                //Blocks the current thread until the current WaitHandle receives a signal.   
                semaphore.WaitAsync();
                Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Doing its work");
                Thread.Sleep(5000);
                Console.WriteLine(Thread.CurrentThread.Name + "Exit.");
            }
            finally
            {
                //Release() method to releage semaphore  
                semaphore.Release();
            }
        }
    }
}
