using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source_code_asm1_programing_loitv_bh01776
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int sizeOfCustomer = 0;

            string keyword = null;

            Console.WriteLine("Enter number of customer:");

            sizeOfCustomer = int.Parse(Console.ReadLine());

            string[] names = new string[sizeOfCustomer]; 
            double[] lastMonthMeter = new double[sizeOfCustomer];
            double[] thisMonthMeter = new double[sizeOfCustomer];
            int[] customerType = new int[sizeOfCustomer];
            int[] peopleNum = new int[sizeOfCustomer];
            double[] consumeWater = new double[sizeOfCustomer];
            double[] cost = new double[sizeOfCustomer];

            for (int i = 0; i < sizeOfCustomer; i++)
            {

                Console.WriteLine("Input name:");

                names[i] = Console.ReadLine();

                Console.WriteLine("Last month index:");

                lastMonthMeter[i] = double.Parse(Console.ReadLine());

                Console.WriteLine("This month index:");
                thisMonthMeter[i] = double.Parse(Console.ReadLine());

                Console.WriteLine("Input type of customer: 1-household 2-goverment 3-manuafacturing 4-business");
                customerType[i] = int.Parse(Console.ReadLine());

                if (customerType[i] == 1)
                {
                    Console.WriteLine("Enter total of member in familiy:");
                    peopleNum[i] = int.Parse(Console.ReadLine());
                }

                consumeWater[i] = thisMonthMeter[i] - lastMonthMeter[i];

            }

            Console.WriteLine("====================WaterBill =======================");

            for (int i = 0; i < sizeOfCustomer; i++)
            {
                Console.WriteLine("Customer:" + names[i]);
                Console.WriteLine("Total water consume:" + consumeWater[i]);

                cost[i] = calculateBill(lastMonthMeter[i], thisMonthMeter[i], customerType[i], peopleNum[i]);
                Console.WriteLine("Money:" + cost[i]);

            }

            Console.WriteLine("===================Sorting============================");
            for (int i = 0; i < sizeOfCustomer; i++)
            {
                for (int j = i + 1; i > j; j++)
                {
                    if (cost[i] < cost[j])
                    {
                        string namesTemp = names[i];
                        names[i] = names[j];
                        names[j] = namesTemp;

                        double costTemp = cost[i];
                        cost[i] = cost[j];
                        cost[j] = costTemp;

                        int customerTypeTemp = customerType[i];
                        customerType[i] = customerType[j];
                        customerType[j] = customerTypeTemp;

                        double lastIndex = lastMonthMeter[i];
                        lastMonthMeter[i] = lastMonthMeter[j];
                        lastMonthMeter[j] = lastIndex;
                        

                        double thisIndex = thisMonthMeter[i];
                        thisMonthMeter[i] = thisMonthMeter[j];
                        thisMonthMeter[j] = thisIndex;

                    }
                }
            }

            for (int i = 0; i < sizeOfCustomer; i++)
            {
                Console.WriteLine("Customer:" + names[i]);
                Console.WriteLine("Total water consume:" + consumeWater[i]);

                cost[i] = calculateBill(lastMonthMeter[i], thisMonthMeter[i], customerType[i], peopleNum[i]);
                Console.WriteLine("Money:" + cost[i]);

            }


            Console.WriteLine("====================Finding=============================");

            Console.WriteLine("Find by customer name:");
            keyword = Console.ReadLine();

            for (int i = 0; i < sizeOfCustomer; i++)
            {
                if (names[i].Equals(keyword))
                {
                    Console.WriteLine("CustomerName:" + names[i]);
                    Console.WriteLine("LastMonthIndex:" + lastMonthMeter[i]);
                    Console.WriteLine("ThisMonthIndex:" + thisMonthMeter[i]);
                    Console.WriteLine("TotalBill:" + cost[i]);
                }
            }
            Console.ReadKey();
        }

        static double calculateBill(double lastIndex, double thisIndex, int typeCustomer, int numberPeople)
        {

            double total = 0;
            double consumeIndex = thisIndex - lastIndex;
            if (typeCustomer == 1)
            {
                double consumeAvg = consumeIndex / numberPeople;
                if (consumeAvg > 30)
                {
                    total = 15929 * consumeIndex;
                }
                else if (consumeAvg > 20)
                {
                    total = 8699 * consumeIndex;
                }
                else if (consumeAvg > 10)
                {
                    total = 7052 * consumeIndex;
                }
                else total = 5973 * consumeIndex;
            }
            else if (typeCustomer == 2)
            {
                total = 9955 * consumeIndex;
            }
            else if (typeCustomer == 3)
            {
                total = 11615 * consumeIndex;
            }
            else if (typeCustomer == 4)
            {
                total = 22068 * consumeIndex;
            }

            return total + total * 0.2;
            

        }
        
        
    }
}
     
