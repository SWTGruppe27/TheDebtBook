using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Models;

namespace TheDebtBook.ViewModels
{
    public class AddDebtorViewModel : BindableBase
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
            _debtBookViewModel.Debtors.Add(AddNewDebtor);
            Application.Current.Windows[Application.Current.Windows.Count - 2].Close();
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
            set
            {
                SetProperty(ref _addDebtor, value);
            }
        }

        public object CurrentDebtor { get; private set; }

        private DebtBookViewModel _debtBookViewModel;
        public AddDebtorViewModel(DebtBookViewModel debtBookViewModel)
        {
            _debtBookViewModel = debtBookViewModel;
            _addDebtor = new Debtor("", 0);
        }

        public AddDebtorViewModel() { }
    }
}
