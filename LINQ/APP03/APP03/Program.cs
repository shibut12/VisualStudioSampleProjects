using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList =new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> selectedVal = from number in numberList
                                           where number % 2 == 0
                                           select number;

            Console.WriteLine("Values of array before appending & filtering");
            foreach (int num in numberList)
            {
                Console.Write(num);
            }

            Console.WriteLine("\nValues of array after appending & filtering");

            numberList.Add(6);
            foreach (int number in selectedVal)
            {
                Console.Write(number);
            }

            Console.ReadLine();
        }
    }
}
