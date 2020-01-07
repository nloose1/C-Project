using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC1012_AP_NicholasLoose
{
    class Babydata
    { 
        private string _name;
        private char _gender;
        private int _number;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length >= 2 && value.Length <= 30)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Error entering valid name");
                }
            }
        }//eop

        public char Gender
        {
            get { return _gender; }
            set
            {
                if(value =='M' || value == 'F')
                {
                    _gender = value;
                }
                else
                {
                    throw new Exception("Error entering valid gender");
                }
            }
        }//eop

        public int Number
        {
            get { return _number; }
            set
            {
                if (value > 0)
                {
                    _number = value;
                }
                else
                {
                   throw new Exception("Error entering valid number");
                }
            }
        }//eop

        public Babydata(string name, char gender, int number)
        {
            Name = name;
            Gender = gender;
            Number = number;
        }//eop
        
    }//eoc
}//eon
