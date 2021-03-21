using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
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

        private ICommand _saveAsCommand;

        public ICommand SaveAsCommand
        {
            get
            {
                return _saveAsCommand ??= (new DelegateCommand(SaveAsHandler));
            }
        }
        void SaveAsHandler()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save the debt book as txt";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var debtor in Debtors)
                    {
                        writer.Write($"{debtor.FullName},");
                        foreach (var debt in debtor.DebtsList)
                        {
                            writer.Write($"{debt.Date},{debt.Value},");
                        }
                        writer.Write("\n");
                    }
                }
            }
        }

        private ICommand _openCommand;

        public ICommand OpenCommand
        {
            get
            {
                return _openCommand ??= (new DelegateCommand(OpenHandler));
            }
        }


        void OpenHandler()
        {
            string filePath = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string inputFromFile;

                    while ((inputFromFile = reader.ReadLine()) != null)
                    {
                        string[] words = inputFromFile.Split(",");
                        Debtor openDebtor = new Debtor(words[0],0);
                        for (int i = 1; i < words.Length-1; i+=2)
                        {
                            Debt openDebt = new Debt(words[i], double.Parse(words[i + 1]));
                            openDebtor.DebtsList.Add(openDebt);
                        }
                        Debtors.Add(openDebtor);
                    }

                }
            }
        }

        private ICommand _exitCommand;

        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand ??= (new DelegateCommand(ExitHandler));
            }
        }

        void ExitHandler()
        {
            Application.Current.Shutdown();
        }


        public DebtBookViewModel()
        {
            Debtors = new ObservableCollection<Debtor>();
            
            Debtors.Add(new Debtor("Kathrine Alroee", 0));
            Debtors.Add(new Debtor("Simon Bjermand Kjær", 0));
            Debtors.Add(new Debtor("Simon Schou Jensen", 0));

            Debtors.ElementAt(0).DebtsList.Add(new Debt(-40));
            Debtors.ElementAt(0).DebtsList.Add(new Debt(-47));
            Debtors.ElementAt(1).DebtsList.Add(new Debt(130));
        }
    }
}
