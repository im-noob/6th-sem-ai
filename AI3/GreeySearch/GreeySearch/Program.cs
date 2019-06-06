using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeySearch
{
    class Program
    {
        //Best Example of Greedy Search



        static void Main(string[] args)
        {

            int[] coins = { 2000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };
            int amount, count, i;
            Console.Write("Enter the amount you want to Paid : ");
            amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("==========================");
            for (i = 0; i < coins.Length; i++)
            {
                count = amount / coins[i];
                if (count != 0)
                    Console.WriteLine("Give Him {0} (s) :{1}", coins[i], count);
                amount %= coins[i];
            }
            Console.ReadKey();


        }
 

    }

}
