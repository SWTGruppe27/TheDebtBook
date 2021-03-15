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
        public ObservableCollection<Debt> DebtsList { get; set; }
        private string fullName;
        private double moneyOwed;

        public Debtor()
        {
        }

        public Debtor(string dFullName)
        {
            fullName = dFullName;
            DebtsList = new ObservableCollection<Debt>();
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

        public double CalculatorMoneyOwed()
        {
            double sumOfValues = 0;

            foreach (var debt in DebtsList)
            {
                sumOfValues += debt.Value;
            }

            return sumOfValues;
        }

        public double MoneyOwed
        {
            get
            {
                return CalculatorMoneyOwed();
            }
            set
            {
                SetProperty(ref moneyOwed, value);
            }
        }
    }
}
