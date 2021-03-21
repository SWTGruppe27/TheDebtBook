using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace TheDebtBook
{
    public class Debt : BindableBase
    {
        private string _date;
        private double _value;

        public Debt()
        {
        }

        public Debt(string date, double value)
        {
            _date = date;
            _value = value;
        }

        public Debt(double value)
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
