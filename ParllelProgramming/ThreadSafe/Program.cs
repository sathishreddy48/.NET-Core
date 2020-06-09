using System;
using System.Threading;

namespace ThreadSafe
{
    class Program
    {
        static readonly object lockObject = new object();
        public static void PrintNumbers()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section");
            Monitor.Enter(lockObject);
            try
            {
                Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(lockObject);
                Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
            }
        }
        static void Main(string[] args)
        {
            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                Threads[i] = new Thread(PrintNumbers);
                Threads[i].Name = "Child Thread " + i;
            }
            foreach (Thread t in Threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }
    }
}
