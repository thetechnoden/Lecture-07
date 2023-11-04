using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            FunctionCache<string, int> cache = new FunctionCache<string, int>();

            TimeSpan customCacheDuration = TimeSpan.FromMinutes(5);

            int result1 = cache.GetOrAdd("Key1", key => ComputeResult(key), customCacheDuration);
            Console.WriteLine($"Result 1: {result1}");

            int result2 = cache.GetOrAdd("Key1", key => ComputeResult(key), customCacheDuration);
            Console.WriteLine($"Result 2 (cached): {result2}");
        }

        static int ComputeResult(string key)
        {
            Console.WriteLine($"Computing result for key: {key}");
            return key.Length;
        }
    }
}