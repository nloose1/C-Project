using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_AP_NicholasLoose
{
    class BankAccount
    {
        private int _id;
        private double _balance;
        private double _annualIntrestRate;
        private DateTime _dateCreated;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value > 0)
                {
                    _id = value;
                }
                else
                {
                    throw new Exception("Error entering valid ID");
                }
            }
        }//eop

        public double Balance
        {
            get { return _balance; }
            set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
                else
                {
                    throw new Exception("Error invalid balance");
                }
            }
        }//eop

        public double AnnualIntrestRate
        {
            get { return _annualIntrestRate; }
            set
            {
                if (value >= 0)
                {
                    _annualIntrestRate = value;
                }
                else
                {
                    throw new Exception("Error entering valid number");
                }
            }
        }//eop

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set
            {
                _dateCreated = value;
            }
        }//eop

        public BankAccount(DateTime dateCreated)
        {
            ID = 0;
            Balance = 0;
            AnnualIntrestRate = 0;
            DateCreated = dateCreated;
        }

        public BankAccount(int id, double balance, double annualIntrestRate, DateTime dateCreated)
        {
            ID = id;
            Balance = balance;
            AnnualIntrestRate = annualIntrestRate;
            DateCreated = dateCreated;
        }//eoc

        public void Withdraw(double amount)
        {
            Balance = Balance - amount;
        }//eom

        public void Deposit(double amount)
        {
            Balance = Balance + amount;
            
        }//eom

        public static double CalculateMonthlyIntrestRate(double intrestRate)
        {
            return intrestRate / 12;
        }//eom

        public static double CalculateMonthlyIntrest(double balance, double monthlyIntrest)
        {
            return balance * monthlyIntrest;
        }//eom
    }//eoc
}//eon
