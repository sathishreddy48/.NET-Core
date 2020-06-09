using System;
using System.Threading.Tasks;

namespace TasksAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task1 = Task.Run(() =>
            {
                return 12;
            }).ContinueWith((antecedent) =>
            {
                return $"The Square of {antecedent.Result} is: {antecedent.Result * antecedent.Result}";
            });
            Console.WriteLine(task1.Result);

            Console.ReadKey();
        }
    }
}
