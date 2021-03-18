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
        private string _fullName;
        private double _moneyOwed;

        public Debtor()
        {
        }

        public Debtor(string dFullName, double moneyOwed)
        {
            _fullName = dFullName;
            _moneyOwed = moneyOwed;
            DebtsList = new ObservableCollection<Debt>();
        }

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                SetProperty(ref _fullName,value);
            }
        }

        public double CalculatorMoneyOwed()
        {
            double sumOfValues = _moneyOwed;

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
                SetProperty(ref _moneyOwed, value);
            }
        }
    }
}
