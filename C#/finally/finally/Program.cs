using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @finally
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine(addtwoNumner(10,0));
            Console.ReadKey();
        }

        private static int addtwoNumner(int a, int b)
        {
            try
            {
                return a/b;
            }
            catch (Exception e)
            {
                return 1;
            }
            finally
            {
                Console.WriteLine("Execution completed");
            }
        }
    }
}
