using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheDebtBook.Models;
using TheDebtBook.ViewModels;

namespace TheDebtBook.Views
{
    public partial class AddDebtor : Window
    {
        private AddDebtorViewModel _addDebtorViewModel;
        private Debtor _addDebtor;
        public AddDebtor(DebtBookViewModel debtBookViewModel)
        {
            InitializeComponent();
            _addDebtorViewModel = new AddDebtorViewModel(debtBookViewModel);
            DataContext = _addDebtorViewModel;
        }
    }
}
