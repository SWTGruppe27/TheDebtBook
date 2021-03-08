using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace TheDebtBook.ViewModels
{
    public class UpdateDebtViewModel : BindableBase
    {
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
            Application.Current.Shutdown();
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
        }


    }
}
