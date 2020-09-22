using System;
using System.IO;
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
    /// Interaction logic for EditInvoice.xaml
    /// </summary>
    public partial class EditInvoice : Page
    {
        private string editMessage;
        public EditInvoice()
        {
            InitializeComponent();
        }

        public EditInvoice(Invoices data) :
            this()
        {
            this.DataContext = data;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            this.invoiceDateText.IsEnabled = true;
            this.invoiceNoText.IsEnabled = true;
            this.commissionRateText.IsEnabled = true;
            this.fromText.IsEnabled = true;
            this.toText.IsEnabled = true;
            this.vatRateText.IsEnabled = true;
            this.truckNoText.IsEnabled = true;
            this.saveButton.Visibility = Visibility.Visible;
            this.printButton.IsEnabled = false;
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            PrintInvoice pi = new PrintInvoice();
            pi.DataContext = this.DataContext;
            PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            if (printDlg.ShowDialog() == true)
            {
                pi.Measure(new Size(printDlg.PrintableAreaWidth,
                printDlg.PrintableAreaHeight));
                pi.Arrange(new Rect(new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight)));
                pi.Margin = new Thickness(40);
                pi.UpdateLayout();

                //now print the visual to printer to fit on the one page.
                printDlg.PrintVisual(pi, "First Fit to Page WPF Print");
            }
            Directory.SetCurrentDirectory(path);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayInvoice.xaml", UriKind.Relative));
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
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
                return;
            }
            else
            {
                editMessage = ((Invoices)this.DataContext).Update();
                MessageBox.Show(editMessage, "Invoice");
                this.saveButton.Visibility = Visibility.Hidden;
                this.invoiceDateText.IsEnabled = false;
                this.invoiceNoText.IsEnabled = false;
                this.commissionRateText.IsEnabled = false;
                this.fromText.IsEnabled = false;
                this.toText.IsEnabled = false;
                this.truckNoText.IsEnabled = false;
                this.vatRateText.IsEnabled = false;
                this.printButton.IsEnabled = true;
            }
        }
    }
}
