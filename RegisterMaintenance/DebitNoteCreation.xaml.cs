using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using RegisterMaintenance.DAL;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for DebitNoteCreation.xaml
    /// </summary>
    public partial class DebitNoteCreation : Page
    {
        string insertMessage;
        public DebitNoteCreation()
        {
            InitializeComponent();
        }

        public DebitNoteCreation(InsertDebitNote id) :
            this()
        {
            this.DataContext = id;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //Check for Validation Error
            BindingExpression debitNoteNoBe = debitNoteNoText.GetBindingExpression(TextBox.TextProperty); 
            BindingExpression debitNoteDateBe = debitNoteDateText.GetBindingExpression(DatePicker.SelectedDateProperty);
            BindingExpression commissionRateBe = commissionRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression charityRateBe = charityRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression brokeageRateBe = brokerageRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression postageCostBe = postageCostText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression cottonDeliveryExpRateBe = cottonDeliveryExpText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression jafferyActualCostBe = jafferyActualCostText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression markingRateBe = markingRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression sampleCuttingCostBe = sampleCuttingCostText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression cartagePlatformRateBe = cartageFactoryRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression stackingRateBe = stackingRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression katlaExpRateBe = katlaExpRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression cartageFactoryRateBe = cartageFactoryRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression stationExpRateBe = stationExpText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression truckLoadingRateBe = truckLoadingRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bankChargeRateBe = bankChargeCostText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression godownRentFromBe = godownRentFromText.GetBindingExpression(DatePicker.SelectedDateProperty);
            BindingExpression godownRentToBe = godownRentToText.GetBindingExpression(DatePicker.SelectedDateProperty);
            BindingExpression godownRentCostBe = godownRentCostText.GetBindingExpression(TextBox.TextProperty); 
            BindingExpression stockInsuranceCostBe = stockInsuranceCostText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression freightFromBe = freightFromText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression freightToBe = freightToText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression freightCostBe = freightCostText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression carringChargesOnBe = carringChargesOnText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression carringChargesFromBe = carringChargesFromText.GetBindingExpression(DatePicker.SelectedDateProperty);
            BindingExpression carringChargesToBe = carringChargesToText.GetBindingExpression(DatePicker.SelectedDateProperty);
            BindingExpression carringChargesRateBe = carringChargesRateText.GetBindingExpression(TextBox.TextProperty);
            BindingExpression amountAndVatRateBe = amountAndVatText.GetBindingExpression(TextBox.TextProperty);

            debitNoteNoBe.UpdateSource();
            debitNoteDateBe.UpdateSource();
            commissionRateBe.UpdateSource();
            charityRateBe.UpdateSource();
            brokeageRateBe.UpdateSource();
            postageCostBe.UpdateSource();
            cottonDeliveryExpRateBe.UpdateSource();
            jafferyActualCostBe.UpdateSource();
            markingRateBe.UpdateSource();
            sampleCuttingCostBe.UpdateSource();
            cartagePlatformRateBe.UpdateSource();
            stackingRateBe.UpdateSource();
            katlaExpRateBe.UpdateSource();
            cartageFactoryRateBe.UpdateSource();
            stationExpRateBe.UpdateSource();
            truckLoadingRateBe.UpdateSource();
            bankChargeRateBe.UpdateSource();
            godownRentFromBe.UpdateSource();
            godownRentToBe.UpdateSource();
            godownRentCostBe.UpdateSource();
            stockInsuranceCostBe.UpdateSource();
            freightFromBe.UpdateSource();
            freightToBe.UpdateSource();
            freightCostBe.UpdateSource();
            carringChargesOnBe.UpdateSource();
            carringChargesFromBe.UpdateSource();
            carringChargesToBe.UpdateSource();
            carringChargesRateBe.UpdateSource();
            amountAndVatRateBe.UpdateSource();

            if (debitNoteNoBe.HasError || debitNoteDateBe.HasError || commissionRateBe.HasError || charityRateBe.HasError || brokeageRateBe.HasError || postageCostBe.HasError || cottonDeliveryExpRateBe.HasError ||
                jafferyActualCostBe.HasError || markingRateBe.HasError || sampleCuttingCostBe.HasError || cartagePlatformRateBe.HasError || stackingRateBe.HasError || katlaExpRateBe.HasError ||
                cartageFactoryRateBe.HasError || stationExpRateBe.HasError || truckLoadingRateBe.HasError || bankChargeRateBe.HasError || godownRentFromBe.HasError || godownRentToBe.HasError ||
                stockInsuranceCostBe.HasError || freightFromBe.HasError || freightToBe.HasError || carringChargesOnBe.HasError || carringChargesFromBe.HasError || carringChargesToBe.HasError ||
                carringChargesRateBe.HasError || godownRentCostBe.HasError || freightCostBe.HasError || amountAndVatRateBe.HasError)
            {
                MessageBox.Show("Please correct Errors", "Insert Aborted");
            }
            else
            {
                insertMessage = ((InsertDebitNote)this.DataContext).Add();
                MessageBox.Show(insertMessage, "DebitNote");
                this.NavigationService.Navigate(new Uri("DebitNote.xaml", UriKind.Relative));
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DebitNote.xaml", UriKind.Relative));
        }
    }
}
