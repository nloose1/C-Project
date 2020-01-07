using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CPSC1012_AP_NicholasLoose
{
    class Part2
    {
        //Needs to be changed based on path to names file
        const string STR_PATH = @"D:\School\2nd Semester\Programing Fundamentals\C# Project\names\";
        public static void NameRanking()
        {
            int year;
            int number;
            char check;
            List<Babydata> babydatas = new List<Babydata>();
            List<string> femaleNames = new List<string>();
            List<string> maleNames = new List<string>();
            do
            {
                Console.Clear();
                Console.WriteLine("Ranking Summary\n");
                do
                {
                    year = Program.GetValidInt("           Enter the year(1880-2017): ");
                    if (year < 1880 || year > 2017)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Must enter a valid year");
                        Console.ResetColor();
                    }
                } while (year < 1880 || year > 2017);
                do
                {
                    number = Program.GetValidInt("Enter the number of rankings(max 30): ");
                    if (number <=0 || number > 30)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Must enter a valid number");
                        Console.ResetColor();
                    }
                } while (number <= 1 || number > 30);
                LoadData(babydatas, year, femaleNames, maleNames, number);
                DisplayRanking(femaleNames, maleNames, number, year);
                do
                {
                    check = GetChar("\nWould you like to search again?(Y/N): ");
                    if (check != 'Y' && check != 'N')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Must enter a valid option");
                        Console.ResetColor();
                    }
                } while (check != 'Y' && check != 'N');
            } while (check == 'Y');
        }//eom

        static char GetChar(string prompt)
        {
            char choice = 'X';
            bool isValid = false;
            do
            {
                try
                {
                    Console.Write(prompt);
                    choice = char.Parse(Console.ReadLine());
                    choice = char.ToUpper(choice);
                    isValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must enter valid character");
                    Console.ResetColor();
                }

            } while (!isValid);
            return choice;
        }//eom

        static void LoadData(List<Babydata> babydatas, int year, List<string> femaleNames, List<string> maleNames, int amount)
        {
            int fCount = 0, mCount = 0;
            if (File.Exists(STR_PATH + "yob" + year + ".txt"))
            {
                string name, input;
                char gender;
                int number;
                StreamReader reader = new StreamReader(STR_PATH + "yob" + year + ".txt");
                try
                {
                    while ((input = reader.ReadLine()) != null)
                    {
                        string[] parts = input.Split(',');
                        name = parts[0];
                        gender = char.Parse(parts[1]);
                        number = int.Parse(parts[2]);
                        Babydata babydata = new Babydata(name, gender, number);
                        babydatas.Add(babydata);
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
                finally
                {
                    reader.Close();
                }
            }
            else
            {
                throw new Exception("Enter a Valid year");
            }
            foreach (Babydata babydata in babydatas)
            {
                if (babydata.Gender == 'F' && fCount < amount)
                {
                    femaleNames.Add(babydata.Name);
                    fCount++;
                }
            }
            foreach (Babydata babydata in babydatas)
            { 
                if (babydata.Gender == 'M' && mCount < amount)
                {
                    maleNames.Add(babydata.Name);
                    mCount++;
                }
            }
        }//eom

        static void DisplayRanking(List<string> femaleNames, List<string> maleNames, int number, int year)
        {
            int count = 0;
            Console.WriteLine("\nTop {0} baby names of {1}", number, year);
            Console.WriteLine("{0,-16}{1,-24}{2}","Rank", "Female names", "Male names\n========================================================");
            for (int index = 0; index < number; index++)
            {
                count++;
                Console.Write("  {0,-12}\t",count);
                Console.Write("{0,-20}\t",femaleNames[index]);
                Console.Write("{0}\n", maleNames[index]);
            }
        }//eom
    }//eoc
}//eon
