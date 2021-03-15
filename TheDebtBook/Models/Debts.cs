using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace TheDebtBook
{
    public class Debts :BindableBase
    {
        private string _date;
        private double _value;

        public Debts()
        {
        }

        public Debts(double value)
        {
            Date = DateTime.Now.ToLongDateString();
            Value = value;
        }

        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                SetProperty(ref _date, value);
            }
        }

        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                SetProperty(ref _value, value);
            }
        }
    }
}
