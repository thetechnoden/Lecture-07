using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository<int> intRepository = new Repository<int>();
            intRepository.Add(1);
            intRepository.Add(2);
            intRepository.Add(3);
            intRepository.Add(4);
            intRepository.Add(5);

            Criteria<int> evenCriteria = x => x % 2 == 0;
            List<int> evenNumbers = intRepository.Find(evenCriteria);

            Console.WriteLine("Even numbers:");
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number);
            }

            Repository<string> stringRepository = new Repository<string>();
            stringRepository.Add("apple");
            stringRepository.Add("banana");
            stringRepository.Add("cherry");
            stringRepository.Add("date");

            Criteria<string> startsWithC = s => s.StartsWith("c", StringComparison.OrdinalIgnoreCase);
            List<string> fruitsStartingWithC = stringRepository.Find(startsWithC);

            Console.WriteLine("Fruits starting with 'C':");
            foreach (string fruit in fruitsStartingWithC)
            {
                Console.WriteLine(fruit);
            }
        }
    }
}