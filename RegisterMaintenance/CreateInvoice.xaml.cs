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
    /// Interaction logic for CreateInvoice.xaml
    /// </summary>
    public partial class CreateInvoice : Page
    {
        public CreateInvoice()
        {
            InitializeComponent();

            // Loading Invoice Pending List by calling the generic list class

            List<Transactions> transactionPendingInvoiceList = new List<Transactions>();
            transactionPendingInvoiceList = DAL_Transactions.LoadTransactionsPendingInvoice();
            transactionPendingInvoiceListView.DataContext = transactionPendingInvoiceList;
            Detail.Content = transactionPendingInvoiceList;
            if (transactionPendingInvoiceList.Count == 0)
            {
                this.emptyText.Visibility = Visibility.Visible;
            }
        }

        private void transactionPendingInvoiceListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            insert(this.transactionPendingInvoiceListView.SelectedItem as Transactions);
        }

        private void insert(Transactions tran)
        {
            int transactionID = tran.Serial;
            this.NavigationService.Navigate(new InvoiceCreation(transactionID));
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Invoice.xaml", UriKind.Relative));
        }


    }
}
