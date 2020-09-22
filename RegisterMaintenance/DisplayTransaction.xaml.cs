using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using RegisterMaintenance.DAL;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for DisplaySeller.xaml
    /// </summary>
    public partial class DisplayTransaction : Page
    {
        public DisplayTransaction()
        {
            InitializeComponent();
            
            // Loading Transaction List by calling the generic list class

            List<Transactions> transactionList = new List<Transactions>();
            transactionList = DAL_Transactions.LoadTransactions();
            transactionListView.DataContext = transactionList;
            Detail.Content = transactionList;
            if (transactionList.Count == 0)
            {
                this.emptyText.Visibility = Visibility.Visible;
            }
        }

        private void transactionListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            edit(this.transactionListView.SelectedItem as Transactions);
        }

        private void edit(Transactions updateTransaction)
        {
            EditTransaction ed = new EditTransaction(updateTransaction);
            this.NavigationService.Navigate(ed);
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("TransactionRegister.xaml", UriKind.Relative));
        }
    }
}
