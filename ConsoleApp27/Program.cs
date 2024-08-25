using System;

namespace WaterBillCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] waterUsageByMonth = new int[12];
            double[] waterBillByMonth = new double[12];

            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("---------------------WATER BILL---------------------");
                Console.WriteLine("Please enter your full name: ");
                string fullName = Console.ReadLine();

                Console.WriteLine("Please enter your customer type:\n 1) Household \n 2) Government agency, public service \n 3) Manufacturing unit \n 4) Business service ");
                string customerType = Console.ReadLine() ?? string.Empty;

                string customerTypeDescription = CheckCustomerType(customerType);
                if (customerTypeDescription.Contains("not valid"))
                {
                    Console.WriteLine(customerTypeDescription);
                    continue; // Skip to next iteration if customer type is invalid
                }

                Console.WriteLine(customerTypeDescription);

                Console.WriteLine("\nPlease enter your home address: ");
                string address = Console.ReadLine();

                Console.WriteLine("\nPlease enter your phone number: ");
                string phoneNumber = Console.ReadLine();

                Console.WriteLine("Please enter the amount of water you have used in m3: ");
                if (!int.TryParse(Console.ReadLine(), out int waterUsage))
                {
                    Console.WriteLine("Invalid input. Please enter again.");
                    i--;
                    continue;
                }

                double waterCost = CalculateWaterCost(customerType, waterUsage);
                double roundedWaterCost = RoundAmount(waterCost, 2);
                Console.WriteLine($"\nThe total water cost is {roundedWaterCost} VND");

                waterUsageByMonth[i] = waterUsage;
                waterBillByMonth[i] = roundedWaterCost;

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

            Console.WriteLine("\nMonthly water usage statistics:");
            foreach (int value in waterUsageByMonth)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("\nMonthly water bill statistics:");
            foreach (double value in waterBillByMonth)
            {
                Console.WriteLine(value);
            }
        }

        static double CalculateWaterCost(string customerType, double waterUsage)
        {
            double waterCost = 0;
            switch (customerType)
            {
                case "1":
                    if (waterUsage <= 10)
                    {
                        waterCost = waterUsage * 5.973;
                    }
                    else if (waterUsage <= 20)
                    {
                        waterCost = (10 * 5.973) + (waterUsage - 10) * 7.052;
                    }
                    else if (waterUsage <= 30)
                    {
                        waterCost = (10 * 5.973) + (10 * 7.052) + (waterUsage - 20) * 8.699;
                    }
                    else
                    {
                        waterCost = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + (waterUsage - 30) * 15.929;
                    }
                    break;

                case "2":
                    waterCost = waterUsage * 9.955;
                    break;
                case "3":
                    waterCost = waterUsage * 11.615;
                    break;
                case "4":
                    waterCost = waterUsage * 22.068;
                    break;
                default:
                    waterCost = 0;
                    break;
            }
            return waterCost;
        }

        static double RoundAmount(double amount, int decimalPlaces)
        {
            return Math.Round(amount, decimalPlaces);
        }

        static string CheckCustomerType(string customerType)
        {
            switch (customerType)
            {
                case "1":
                    return "Your customer type is Household";
                case "2":
                    return "Your customer type is Government agency, public service";
                case "3":
                    return "Your customer type is Manufacturing unit";
                case "4":
                    return "Your customer type is Business service";
                default:
                    return "Your customer type is not valid";
            }
        }
    }
}

