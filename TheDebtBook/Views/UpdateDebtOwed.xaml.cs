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
using TheDebtBook.ViewModels;

namespace TheDebtBook.Views
{
    public partial class UpdateDebtOwed : Window
    {
        private UpdateDebtViewModel _updateDebtViewModel;
        public UpdateDebtOwed(DebtBookViewModel model)
        {
            InitializeComponent();
            _updateDebtViewModel = new UpdateDebtViewModel(model);
            DataContext = _updateDebtViewModel;
        }
    }
}
