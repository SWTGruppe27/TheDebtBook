using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Models;
using TheDebtBook.Views;


namespace TheDebtBook.ViewModels
{
    class DebtBookViewModel : BindableBase
    {
        public ObservableCollection<Debtor> Debtors { get; }

        private Debtor currentDebtor = null;
        public Debtor CurrentDebtor
        {
            get
            {
                return currentDebtor;
            }
            set
            {
                SetProperty(ref currentDebtor, value);
            }
        }
       
        int currentIndex = -1;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                SetProperty(ref currentIndex, value);
            }
        }

        private ICommand _addNewCommand;
        public ICommand AddNewCommand
        {
            get
            {
                return _addNewCommand ??= (new DelegateCommand(AddNewHandler));
            }
        }

        void AddNewHandler()
        {
            AddDebtor addDebtor = new AddDebtor();

            addDebtor.ShowDialog();
            Debtors.Add(new Debtor("", 0));
            CurrentIndex = Debtors.Count - 1;
        }

        public DebtBookViewModel()
        {
            Debtors = new ObservableCollection<Debtor>();
            Debtors.Add(new Debtor("Kathrine Alroee", 1000.4));
        }

    }
}
