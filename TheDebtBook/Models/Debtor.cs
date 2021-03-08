using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Prism.Mvvm;

namespace TheDebtBook.Models
{
    public class Debtor : BindableBase
    {
        public ObservableCollection<Debts> DebtsList { get; set; }
        private string fullName;
        private double moneyOwed;

        public Debtor()
        {
        }

        public Debtor(string dFullName, double dMoneyOwed)
        {
            fullName = dFullName;
            moneyOwed = dMoneyOwed;
            DebtsList = new ObservableCollection<Debts>();
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
