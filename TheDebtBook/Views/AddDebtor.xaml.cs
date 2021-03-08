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
        private DebtBookViewModel _debtBookViewModel;
        private Debtor _addDebtor;
        public AddDebtor(DebtBookViewModel debtBookViewModel)
        {
            _debtBookViewModel = debtBookViewModel;
            InitializeComponent();
        }
    }
}
