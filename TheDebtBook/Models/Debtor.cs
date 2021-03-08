using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TheDebtBook.Models
{
    public class Debtor : INotifyPropertyChanged
    {
        private string fullName;
        private double moneyOwed;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

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
                fullName = value;
                Notify("Full Name");
            }
        }

        public string MoneyOwed
        {
            get
            {
                return Convert.ToString(moneyOwed);
            }
            set
            {
                moneyOwed = double.Parse(value);
                Notify("Money Owed");
            }
        }
    }
}
