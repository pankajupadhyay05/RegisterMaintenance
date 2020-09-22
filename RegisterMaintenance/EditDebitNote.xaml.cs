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
    /// Interaction logic for EditDebitNote.xaml
    /// </summary>
    public partial class EditDebitNote : Page
    {
        private string editMessage;
        public EditDebitNote()
        {
            InitializeComponent();
        }

        public EditDebitNote(DebitNotes data) :
            this()
        {
            this.DataContext = data;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            this.saveButton.Visibility = Visibility.Visible;
            this.printButton.IsEnabled = false;
            this.debitNoteDateText.IsEnabled = true;
            this.debitNoteNoText.IsEnabled = true;
            this.commissionRateText.IsEnabled = true;
            this.charityRateText.IsEnabled = true;
            this.brokerageRateText.IsEnabled = true;
            this.postageText.IsEnabled = true;
            this.postageCostText.IsEnabled = true;
            this.cottonDeliveryExpText.IsEnabled = true;
            this.jafferyActualText.IsEnabled = true;
            this.jafferyActualCostText.IsEnabled = true;
            this.markingRateText.IsEnabled = true;
            this.sampleCuttingText.IsEnabled = true;
            this.sampleCuttingCostText.IsEnabled = true;
            this.cartagePlatformRateText.IsEnabled = true;
            this.stackingRateText.IsEnabled = true;
            this.katlaExpText.IsEnabled = true;
            this.katlaExpRateText.IsEnabled = true;
            this.cartageFactoryRateText.IsEnabled = true;
            this.stationExpText.IsEnabled = true;
            this.truckLoadingRateText.IsEnabled = true;
            this.bankChargeCostText.IsEnabled = true;
            this.godownRentFromText.IsEnabled = true;
            this.godownRentToText.IsEnabled = true;
            this.godownRentCostText.IsEnabled = true;
            this.stockInsuranceText.IsEnabled = true;
            this.stockInsuranceCostText.IsEnabled = true;
            this.freightFromText.IsEnabled = true;
            this.freightToText.IsEnabled = true;
            this.freightCostText.IsEnabled = true;
            this.carringChargesOnText.IsEnabled = true;
            this.carringChargesFromText.IsEnabled = true;
            this.carringChargesToText.IsEnabled = true;
            this.carringChargesRateText.IsEnabled = true;
            this.amountAndVatRateText.IsEnabled = true;
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            PrintDebitNote pd = new PrintDebitNote();
            pd.DataContext = this.DataContext;
            pd.cleanDebitNote();
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

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayDebitNote.xaml", UriKind.Relative));
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //Check for Validation Error
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
            BindingExpression amountAndVatRateBe = amountAndVatRateText.GetBindingExpression(TextBox.TextProperty);

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

            if (debitNoteDateBe.HasError || commissionRateBe.HasError || charityRateBe.HasError || brokeageRateBe.HasError || postageCostBe.HasError || cottonDeliveryExpRateBe.HasError ||
                jafferyActualCostBe.HasError || markingRateBe.HasError || sampleCuttingCostBe.HasError || cartagePlatformRateBe.HasError || stackingRateBe.HasError || katlaExpRateBe.HasError ||
                cartageFactoryRateBe.HasError || stationExpRateBe.HasError || truckLoadingRateBe.HasError || bankChargeRateBe.HasError || godownRentFromBe.HasError || godownRentToBe.HasError ||
                stockInsuranceCostBe.HasError || freightFromBe.HasError || freightToBe.HasError || carringChargesOnBe.HasError || carringChargesFromBe.HasError || carringChargesToBe.HasError ||
                carringChargesRateBe.HasError || godownRentCostBe.HasError || freightCostBe.HasError || amountAndVatRateBe.HasError)
            {
                MessageBox.Show("Please correct Errors", "Insert Aborted");
            }
            else
            {
                editMessage = ((DebitNotes)this.DataContext).Update();
                MessageBox.Show(editMessage, "Invoice");
                this.NavigationService.Navigate(new Uri("DebitNote.xaml", UriKind.Relative));
            }
        }
    }
}
