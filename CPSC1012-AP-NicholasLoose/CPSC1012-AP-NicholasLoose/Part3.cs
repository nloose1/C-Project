using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_AP_NicholasLoose
{
    class Part3
    {
        public static void CreateBankAccount()
        {
            //Hint for date **DateCreated = DateTime.Now;** **{1:yyyy-MM-dd}** for format
            List<BankAccount> bankAccounts = new List<BankAccount>();
            int id;
            Console.Clear();
            id = NewBankAccount(bankAccounts);
            AccountMenu(bankAccounts, id);
        }//eom

        static int NewBankAccount(List<BankAccount> bankAccounts)
        {
            int id = -1;
            double balance;
            bool isValid = false;
            Console.WriteLine("New Bank Account Information\n------------------------");
            do
            {
                try
                {
                    id = Program.GetValidInt("Enter account ID: ");
                    balance = Program.GetValidInt("Enter initial account balance: ");
                    BankAccount account = new BankAccount(id, balance, 0, DateTime.Now);
                    bankAccounts.Add(account);
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            } while (!isValid);
     
            return id;
        }//eom

        static void AccountMenu (List<BankAccount> bankAccounts, int id)
        {
            int choice;
            double amount;
            do
            {
                bool isValid = false;
                Console.WriteLine("\nAccount Menu\n-----------------------");
                Console.WriteLine("\t1: Set annual intrest rate");
                Console.WriteLine("\t2: Withdraw");
                Console.WriteLine("\t3: Deposit");
                Console.WriteLine("\t4: Print account info");
                Console.WriteLine("\t5: Exit");
                do
                {
                    choice =Program.GetValidInt("Choice: ");
                    if (choice >= 1 && choice <= 5)
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
                if (choice != 5)
                {
                    switch (choice)
                    {
                        case 1:
                            SetIntrest(bankAccounts, id);
                            break;
                        case 2:
                            BankAccount foundAccount = bankAccounts.Find(item => item.ID == id);
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
                            BankAccount account = bankAccounts.Find(item => item.ID == id);
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
                            PrintAccount(bankAccounts, id);
                            break;
                    }
                    
                }
            } while (choice != 5);

        }//eom

        static void SetIntrest(List<BankAccount> bankAccounts, int id)
        {
            double intrest;
            bool isValid = false;

            BankAccount foundAccount = bankAccounts.Find(item => item.ID == id);
            do
            {
                try
                {
                    intrest = Program.GetValidDouble("Enter annual intrest rate: ");
                    foundAccount.AnnualIntrestRate = intrest / 100;
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            } while (!isValid);
        }//eom

        static void PrintAccount(List<BankAccount> bankAccounts, int id)
        {
            double monthlyIntrest, monthlyIntrestRate;
            BankAccount foundAccount = bankAccounts.Find(item => item.ID == id);
            monthlyIntrestRate = BankAccount.CalculateMonthlyIntrestRate(foundAccount.AnnualIntrestRate);
            monthlyIntrest = BankAccount.CalculateMonthlyIntrest(foundAccount.Balance, monthlyIntrestRate);

            Console.WriteLine("Bank Account Info\n-----------------------------");
            Console.WriteLine("{0,22}{1,10}", "ID: ", id);
            Console.WriteLine("{0,22}{1,10:c}", "Balance: ", foundAccount.Balance);
            Console.WriteLine("{0}{1,10:0.0000}", "Monthly Intrest Rate: ", monthlyIntrestRate);
            Console.WriteLine("{0,22}{1,10:0.00}", "Monthly Intrest: ", monthlyIntrest);
            Console.WriteLine("{0,22}{1,10:yyyy-MM-dd}", "Date Created: ", foundAccount.DateCreated);
        }//eom
    }//eoc
}//eon
