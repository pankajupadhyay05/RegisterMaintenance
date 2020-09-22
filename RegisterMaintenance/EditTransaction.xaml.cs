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
    /// Interaction logic for EditTransaction.xaml
    /// </summary>
    public partial class EditTransaction : Page
    {
        private string insertMessage;
        private string deleteMessage;
        public EditTransaction()
        {
            InitializeComponent(); 
        }

        public EditTransaction(Transactions data) :
            this()
        {
            this.DataContext = data;
            List<string> ledgerList = new List<string>();
            ledgerList = DAL_LedgerNameList.LoadLedgerNameListString();
            sellerText.ItemsSource = ledgerList;
            buyerText.ItemsSource = ledgerList;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression sellerBe = sellerText.GetBindingExpression(AutoCompleteBox.SelectedItemProperty);
            BindingExpression stationBe = stationText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression balesBe = balesText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression qualityBe = qualityBox.GetBindingExpression(ComboBox.TextProperty);
            BindingExpression ratePerMoundBe = ratePerMoundText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression conditionBe = conditionText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression brokerBe = brokerText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression brokeragePaidBe = brokeragePaidText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression buyerBe = buyerText.GetBindingExpression(AutoCompleteBox.SelectedItemProperty);
            BindingExpression grossWeightBe = grossWeightText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression lessTearBe = lessTearText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression lessSampleBe = lessSampleText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression lessDamageBe = lessDamageText.GetBindingExpression(TextBox.TextProperty);

            sellerBe.UpdateSource();
            stationBe.UpdateSource();
            balesBe.UpdateSource();
            qualityBe.UpdateSource();
            ratePerMoundBe.UpdateSource();
            conditionBe.UpdateSource();
            brokerBe.UpdateSource();
            brokeragePaidBe.UpdateSource();
            buyerBe.UpdateSource();
            grossWeightBe.UpdateSource();
            lessTearBe.UpdateSource();
            lessSampleBe.UpdateSource();
            lessDamageBe.UpdateSource();

            if (sellerBe.HasError || stationBe.HasError || balesBe.HasError || qualityBe.HasError || ratePerMoundBe.HasError
                || conditionBe.HasError || brokerBe.HasError || brokeragePaidBe.HasError
                || buyerBe.HasError || grossWeightBe.HasError || lessDamageBe.HasError || lessSampleBe.HasError || lessTearBe.HasError)
            {
                MessageBox.Show("Please correct Errors", "Insert Aborted");
            }
            else
            {
                insertMessage = ((Transactions)this.DataContext).Update();
                MessageBox.Show(insertMessage, "Transaction");
                this.NavigationService.GoBack();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            deleteMessage = ((Transactions)this.DataContext).Delete();
            MessageBox.Show(deleteMessage, "Transaction");
            this.NavigationService.Navigate(new Uri("DisplayTransaction.xaml", UriKind.Relative));
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            PrintDetail pd = new PrintDetail();
            pd.DataContext = this.DataContext;
            PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            if (printDlg.ShowDialog() == true)
            {
                pd.Measure(new Size(printDlg.PrintableAreaWidth,
                printDlg.PrintableAreaHeight));
                pd.Arrange(new Rect(new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight)));
                pd.Margin = new Thickness(40);
                pd.UpdateLayout();

                //now print the visual to printer to fit on the one page.
                printDlg.PrintVisual(pd, "First Fit to Page WPF Print");
            }
            Directory.SetCurrentDirectory(path);
        }

        private void purchasePrintButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            PrintAdvice pi = new PrintAdvice();
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

        private void salePrintButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            SaleAdvice si = new SaleAdvice();
            si.DataContext = this.DataContext;
            PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            if (printDlg.ShowDialog() == true)
            {
                si.Measure(new Size(printDlg.PrintableAreaWidth,
                printDlg.PrintableAreaHeight));
                si.Arrange(new Rect(new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight)));
                si.Margin = new Thickness(40);
                si.UpdateLayout();

                //now print the visual to printer to fit on the one page.
                printDlg.PrintVisual(si, "First Fit to Page WPF Print");
            }
            Directory.SetCurrentDirectory(path);
        }
    }
}
