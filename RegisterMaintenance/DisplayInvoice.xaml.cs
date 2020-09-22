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
    /// Interaction logic for DisplayInvoice.xaml
    /// </summary>
    public partial class DisplayInvoice : Page
    {
        public DisplayInvoice()
        {
            InitializeComponent();

            // Loading Invoice List by calling the generic list class

            List<Invoices> invoiceList = new List<Invoices>();
            invoiceList = DAL_Invoices.LoadInvoices();
            invoiceListView.DataContext = invoiceList;
            Detail.Content = invoiceList;
            if (invoiceList.Count == 0)
            {
                this.emptyText.Visibility = Visibility.Visible;
            }
        }

        private void invoiceListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            edit(this.invoiceListView.SelectedItem as Invoices);
        }

        private void edit(Invoices updateInvoice)
        {
            EditInvoice ei = new EditInvoice(updateInvoice);
            this.NavigationService.Navigate(ei);
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Invoice.xaml", UriKind.Relative));
        }
    }
}
