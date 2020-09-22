using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using RegisterMaintenance.DAL;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for InvoiceCreation.xaml
    /// </summary>
    public partial class InvoiceCreation : Page
    {
        string insertMessage;
        public InvoiceCreation()
        {
            InitializeComponent();
        }

        public InvoiceCreation(int transactionID) :
            this()
        {
            InsertInvoice ic = new InsertInvoice();
            ic.Load(transactionID);
            this.DataContext = ic;
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression invoiceNoTextBe = invoiceNoText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression invoiceDateTextBe = invoiceDateText.GetBindingExpression(DatePicker.SelectedDateProperty);
            BindingExpression commissionRateTextBe = commissionRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression vatRateTextBe = vatRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression fromTextBe = fromText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression toTextBe = toText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression truckNoTextBe = truckNoText.GetBindingExpression(TextBox.TextProperty);

            invoiceNoTextBe.UpdateSource();
            invoiceDateTextBe.UpdateSource();
            commissionRateTextBe.UpdateSource();
            vatRateTextBe.UpdateSource();
            fromTextBe.UpdateSource();
            toTextBe.UpdateSource();
            truckNoTextBe.UpdateSource();

            if (invoiceNoTextBe.HasError || invoiceDateTextBe.HasError || commissionRateTextBe.HasError || vatRateTextBe.HasError
                || fromTextBe.HasError || toTextBe.HasError || truckNoTextBe.HasError)
            {
                MessageBox.Show("Please Correct Errors", "Invoice");
            }
            else
            {
                insertMessage = ((InsertInvoice)this.DataContext).Add();
                MessageBox.Show(insertMessage, "Invoice");
                this.NavigationService.Navigate(new Uri("Invoice.xaml", UriKind.Relative));
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Invoice.xaml", UriKind.Relative));
        }
    }
}
