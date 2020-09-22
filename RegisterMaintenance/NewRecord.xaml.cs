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
    /// Interaction logic for NewRecord.xaml
    /// </summary>
    public partial class NewRecord : Page
    {
        public NewRecord()
        {
            InitializeComponent();
            List<string> ledgerList = new List<string>();
            ledgerList = DAL_LedgerNameList.LoadLedgerNameListString();
            sellerText.ItemsSource = ledgerList;
            buyerText.ItemsSource = ledgerList;
        }

        string insertMessage;
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression dateBe = dateText.GetBindingExpression(DatePicker.SelectedDateProperty);
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

            dateBe.UpdateSource();
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

            if (dateBe.HasError || sellerBe.HasError || stationBe.HasError || balesBe.HasError || qualityBe.HasError || ratePerMoundBe.HasError
                || conditionBe.HasError || brokerBe.HasError || brokeragePaidBe.HasError
                || buyerBe.HasError || grossWeightBe.HasError || lessDamageBe.HasError || lessSampleBe.HasError || lessTearBe.HasError)
            {
                MessageBox.Show("Please correct Errors", "Insert Aborted");
            }
            else
            {
                Binding insertTransactionBinding = BindingOperations.GetBinding(balesText, TextBox.TextProperty);
                InsertTransaction insertTransaction = insertTransactionBinding.Source as InsertTransaction;
                insertMessage = insertTransaction.Add();
                MessageBox.Show(insertMessage, "Transaction");
                this.NavigationService.Refresh();
            }
        }

        
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("TransactionRegister.xaml", UriKind.Relative));
        }
    }
}
