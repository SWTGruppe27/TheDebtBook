using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Prism.Mvvm;

namespace TheDebtBook.Models
{
    public class Debtor : BindableBase
    {
        private string fullName;
        private double moneyOwed;

        public Debtor()
        {

        }

        public Debtor(string dFullName, double dMoneyOwed)
        {
            fullName = dFullName;
            moneyOwed = dMoneyOwed;
        }

        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                SetProperty(ref fullName,value);
            }
        }

        public double MoneyOwed
        {
            get
            {
                return moneyOwed;
            }
            set
            {
                SetProperty(ref moneyOwed, value);
            }
        }
    }
}
