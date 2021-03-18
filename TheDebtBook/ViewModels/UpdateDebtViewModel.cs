using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class UpdateDebtViewModel : BindableBase
    {
        public Debtor CurrentDebtor { get; private set; }
        private DebtBookViewModel _debtBookViewModel;
        private double _value;
        private ICommand _closeCommand;
        private ICommand _addValueCommand;

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

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ??= (new DelegateCommand(CloseHandler));
            }
        }

        public void CloseHandler()
        {
            Application.Current.Windows[Application.Current.Windows.Count-2].Close();
        }

        public ICommand AddValueCommand
        {
            get
            {
                return _addValueCommand ??= (new DelegateCommand(AddValueHandler));
            }
        }

        public void AddValueHandler()
        {
            _debtBookViewModel.Debtors.ElementAt(_debtBookViewModel.CurrentIndex).DebtsList.Add(new Debt(Value));
            
            //update MoneyOwed in CurrentDebtor
            _debtBookViewModel.CurrentDebtor.MoneyOwed = _debtBookViewModel.CurrentDebtor.CalculatorMoneyOwed();
        }

        public UpdateDebtViewModel(DebtBookViewModel model)
        {
            _debtBookViewModel = model;
            CurrentDebtor = model.CurrentDebtor;
        }

        public UpdateDebtViewModel()
        {
        }
    }
}
