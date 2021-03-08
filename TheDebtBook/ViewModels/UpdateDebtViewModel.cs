using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace TheDebtBook.ViewModels
{
    public class UpdateDebtViewModel : BindableBase
    {
        public ObservableCollection<Debts> UpdateDebtList { get; set; }

        private ICommand _closeCommand;
        private ICommand _addValueCommand;

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

        }

        public UpdateDebtViewModel()
        {
            UpdateDebtList = new ObservableCollection<Debts>();
            //UpdateDebtList.Add(new Debts(-55));
        }


    }
}
