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
        private DebtBookViewModel debtBookViewModel;
        private Debtor _addDebtor;
        public AddDebtor()
        {
            InitializeComponent();
            _addDebtor = new Debtor("", 0);
        }

        public Debtor AddNewDebtor
        {
            get
            {
                return _addDebtor;
            }
        }
    }
}
