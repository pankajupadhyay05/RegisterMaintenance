using System;
using System.Collections.Generic;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Navigation;
using RegisterMaintenance.DAL;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for DisplayBuyerDetail.xaml
    /// </summary>
    public partial class DisplayBuyerDetail : Page
    {
        public DisplayBuyerDetail()
        {
            InitializeComponent();
        }

        public DisplayBuyerDetail(string buyerName)
            : this()
        {
            int transactionTotal = 0;
            int balesTotal = 0;
            int totalAmount = 0;
            groupBox1.Header = buyerName;
            List<BuyerDetail> buyerDetail = new List<BuyerDetail>();
            buyerDetail = DAL_BuyerDetail.LoadBuyerDetail(buyerName);
            foreach (var record in buyerDetail)
            {
                transactionTotal++;
                balesTotal = balesTotal + Convert.ToInt32(record.Bales);
                totalAmount = totalAmount + (int)record.InvoiceAmount;
            }
            buyerDetailListView.DataContext = buyerDetail;
            tranTotalText.Content = transactionTotal.ToString();
            tranBalesText.Content = balesTotal.ToString();
            tranAmountText.Content = totalAmount.ToString("C0", new CultureInfo("en-IN")) + "/-";
            Detail.Content = buyerDetail;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayBuyer.xaml", UriKind.Relative));
        }
    }
}
