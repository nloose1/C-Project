using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Need to change paths to files in Part1, Part2 and Part4.

namespace CPSC1012_AP_NicholasLoose
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();
                choice = MainMenu();
                if (choice != 5)
                {
                    switch (choice)
                    {
                        case 1:
                            Part1.BabyName();
                            break;
                        case 2:
                            Part2.NameRanking();
                            break;
                        case 3:
                            Part3.CreateBankAccount();
                            break;
                        default:
                            Part4.ATM();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                }
            } while (choice != 5);

            Console.ReadLine();
        }//eom

        static int MainMenu()
        {
            int choice;
            bool isValid = false;
            Console.WriteLine("Main Menu");
            Console.WriteLine("\t1. Baby Names");
            Console.WriteLine("\t2. Ranking Summary");
            Console.WriteLine("\t3. Bank Account Class");
            Console.WriteLine("\t4. ATM Machine");
            Console.WriteLine("\t5. Exit");
            do
            {
                choice = GetValidInt("Choice: ");
                if (choice >= 1 && choice <= 5)
                {
                    isValid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must enter a valid choice!");
                    Console.ResetColor();
                }
            } while (!isValid);
            return choice;
        }//eom

        public static int GetValidInt (string prompt)
        {
            bool isValid = false;
            int number = -1;
            do
            {
                try
                {
                    Console.Write(prompt);
                    number = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must enter valid Int");
                    Console.ResetColor();
                }
            } while (!isValid);
            return number;
        }//eom

        public static double GetValidDouble(string prompt)
        {
            bool isValid = false;
            double number = -1;
            do
            {
                try
                {
                    Console.Write(prompt);
                    number = double.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must enter valid Int");
                    Console.ResetColor();
                }
            } while (!isValid);
            return number;
        }//eom
    }//eoc
}//eon
