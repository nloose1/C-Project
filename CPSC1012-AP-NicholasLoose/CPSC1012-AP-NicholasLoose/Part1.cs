using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CPSC1012_AP_NicholasLoose
{
    class Part1
    {
        //Needs to be changed based on path to names file
        const string STR_PATH = @"D:\School\2nd Semester\Programing Fundamentals\C# Project\names\";

        public static void BabyName()
        {
            char check;
            do
            {
                Console.Clear();
                List<Babydata> babydatas = new List<Babydata>();
                int year = -1, number = -1;
                char gender;
                string name = "ERROR";
                bool isValid;
                check = 'X';
                Console.WriteLine("Baby Names\n");
                do
                {
                    isValid = false;
                    try
                    {
                        year = Program.GetValidInt("Enter the year (1880-2017): ");
                        LoadData(babydatas, year);
                        do
                        {
                            gender = GetChar("Enter the gender (M/F): ");
                            if(gender != 'M' && gender != 'F')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Must enter a valid option");
                                Console.ResetColor();
                            }
                        } while (gender != 'M' && gender != 'F');
                        Console.Write("Enter the name: ");
                        name = Console.ReadLine();
                        foreach (Babydata babydata in babydatas)
                        {
                            if (string.Equals(name.ToUpper(), babydata.Name.ToUpper()) && char.Equals(gender, babydata.Gender))
                            {
                                number = babydata.Number;
                            }
                        }
                        isValid = true;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                } while (!isValid);
                if (number != -1)
                {
                    Console.WriteLine("The name {0} was used {1} time(s) in the year {2}", name, number, year);
                }
                else
                {
                    Console.WriteLine("The name {0} was not used in the year {1}", name, year);
                }
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

        static char GetChar (string prompt)
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

        static void LoadData(List<Babydata> babydatas, int year)
        {
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
                    throw new Exception(ex.Message);
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
        }//eom
    }//eoc
}//eon
