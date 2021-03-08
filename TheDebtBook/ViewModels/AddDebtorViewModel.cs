using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class AddDebtorViewModel
    {
        private ICommand _okCommand;
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ??= (new DelegateCommand(OkHandler));
            }
        }
        public void OkHandler()
        {
            Application.
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ??= (new DelegateCommand(CancelHandler));
            }
        }

        public void CancelHandler()
        {
            Application.Current.Windows[Application.Current.Windows.Count - 2].Close();
        }

        private Debtor _addDebtor;
        public Debtor AddNewDebtor
        {
            get
            {
                return _addDebtor;
            }
        }

        public object CurrentDebtor { get; private set; }

        private DebtBookViewModel _debtBookViewModel;
        public AddDebtorViewModel(DebtBookViewModel debtBookViewModel)
        {
            
            _debtBookViewModel = debtBookViewModel;
            _addDebtor = new Debtor("", 0);

        }
    }
}
