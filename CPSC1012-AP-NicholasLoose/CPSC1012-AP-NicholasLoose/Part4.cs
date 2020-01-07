using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CPSC1012_AP_NicholasLoose
{
    class Part4
    {
        //Needs to be changed based on path to accounts.csv file
        const string STR_PATH = @"D:\School\2nd Semester\Programing Fundamentals\C# Project\accounts.csv";
        public static void ATM()
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();
            int accountId;
            int check;
            do
            {
                LoadAccounts(bankAccounts);
                accountId = EnterAccount(bankAccounts);
                MainMenu(bankAccounts, accountId);
                do
                {
                    check = GetChar("\nWould you like to make changes to another account?(Y/N): ");
                    if (check != 'Y' && check != 'N')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Must enter a valid option");
                        Console.ResetColor();
                    }
                } while (check != 'Y' && check != 'N');
            } while (check == 'Y');
        }//eom

        static void LoadAccounts(List<BankAccount> bankAccounts)
        {
            if (File.Exists(STR_PATH))
            {
                string input;
                int id;
                double balance, intrestRate;
                DateTime dateCreated;
                StreamReader reader = new StreamReader(STR_PATH);
                try
                {
                    while ((input = reader.ReadLine()) != null)
                    {
                        string[] parts = input.Split(',');
                        id = int.Parse(parts[0]);
                        balance = double.Parse(parts[1]);
                        intrestRate = double.Parse(parts[2]);
                        dateCreated = DateTime.Parse(parts[3]);
                        BankAccount account = new BankAccount(id, balance, intrestRate, dateCreated);
                        bankAccounts.Add(account);
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
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Account file does not exist");
            }
        }//eom


        //This checks for accounts in the list
        static int EnterAccount(List<BankAccount> bankAccounts)
        {
            Console.Clear();
            bool isValid = false;
            int accountNumber;
            do
            {
                accountNumber = Program.GetValidInt("Enter account ID: ");
                int index = bankAccounts.FindIndex(item => item.ID == accountNumber);
                if (index >= 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid acount ID there are no accounts with the ID {0}", accountNumber);
                    Console.ResetColor();
                }
            } while (!isValid);
            return accountNumber;
        }//eom

        static void MainMenu (List<BankAccount> bankAccounts, int accountID)
        {
            int choice = 0;
            double amount;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("\nMain Menu\n------------------");
                Console.WriteLine("\t1: Check balance");
                Console.WriteLine("\t2: Withdraw");
                Console.WriteLine("\t3: Deposit");
                Console.WriteLine("\t4: Exit");
                do
                {
                    choice = Program.GetValidInt("Choice: ");
                    if (choice >= 1 && choice <= 4)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Must enter valid choice");
                        Console.ResetColor();
                    }
                } while (!isValid);
                isValid = false;
                switch (choice)
                {
                    case 1:
                        DisplayBalance(bankAccounts, accountID);
                        break;
                    case 2:
                        BankAccount foundAccount = bankAccounts.Find(item => item.ID == accountID);
                        do
                        {
                            try
                            {
                                do
                                {
                                    amount = Program.GetValidDouble("Enter an amount to withdraw: ");
                                    if (amount < 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Must enter a value 0 or greater");
                                        Console.ResetColor();
                                    }
                                } while (amount < 0);
                                foundAccount.Withdraw(amount);
                                isValid = true;
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ResetColor();
                            }
                        } while (!isValid);
                        isValid = false;
                        break;
                    case 3:
                        BankAccount account = bankAccounts.Find(item => item.ID == accountID);
                        do
                        {
                            try
                            {
                                do
                                {
                                    amount = Program.GetValidDouble("Enter an amount to deposit: ");
                                    if (amount < 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Must enter a value 0 or greater");
                                        Console.ResetColor();
                                    }
                                } while (amount < 0);
                                account.Deposit(amount);
                                isValid = true;
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ResetColor();
                            }
                        } while (!isValid);
                        isValid = false;
                        break;
                    default:
                        UpdateAccount(bankAccounts, accountID);
                        isValid = true;
                        break;
                }
            }
        }//eom

        static void DisplayBalance (List<BankAccount> bankAccounts, int id)
        {
            BankAccount foundAccount = bankAccounts.Find(item => item.ID == id);
            Console.WriteLine("The balance is {0:c}", foundAccount.Balance);
        }

        static void UpdateAccount(List<BankAccount> bankAccounts, int id)
        {
            string output;
            StreamWriter writer = new StreamWriter(STR_PATH);
            try
            {
                foreach(BankAccount account in bankAccounts)
                {
                    output = account.ID + "," + account.Balance + "," + account.AnnualIntrestRate + "," + account.DateCreated;
                    writer.WriteLine(output);
                }
                writer.Close();
            }
            catch(Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error updating account");
                Console.ResetColor();
            }
            finally
            {
                writer.Close();
            }

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
    }//eoc
}//eon
