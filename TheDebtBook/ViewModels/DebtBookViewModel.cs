﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Models;
using TheDebtBook.Views;


namespace TheDebtBook.ViewModels
{
    public class DebtBookViewModel : BindableBase
    {
        public ObservableCollection<Debtor> Debtors { get; set; }

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
            AddDebtor addDebtor = new AddDebtor(this);

            addDebtor.ShowDialog();
            CurrentIndex = Debtors.Count - 1;
        }

        private ICommand _editDebt;

        public ICommand EditDebtCommand
        {
            get
            {
                return _editDebt ??= (new DelegateCommand(EditDebtHandler));
            }
        }

        public void EditDebtHandler()
        {
            UpdateDebtOwed updateDebtOwed = new UpdateDebtOwed(this);

            updateDebtOwed.ShowDialog();
        }


        public DebtBookViewModel()
        {
            Debtors = new ObservableCollection<Debtor>();
            
            Debtors.Add(new Debtor("Kathrine Alroee", 0));
            Debtors.Add(new Debtor("Simon Bjermand Kjær", 0));
            Debtors.Add(new Debtor("Simon Schou Jensen", 1));

            Debtors.ElementAt(0).DebtsList.Add(new Debt(-40));
        }

    }
}
