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

namespace TheDebtBook.Views
{
    /// <summary>
    /// Interaction logic for AddDebtor.xaml
    /// </summary>
    public partial class AddDebtor : Window
    {
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
