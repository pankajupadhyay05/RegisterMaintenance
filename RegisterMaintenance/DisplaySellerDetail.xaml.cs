using System;
using System.Collections.Generic;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using RegisterMaintenance.DAL;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for DisplaySellerDetail.xaml
    /// </summary>
    public partial class DisplaySellerDetail : Page
    {
        public DisplaySellerDetail()
        {
            InitializeComponent();
        }

        public DisplaySellerDetail(string sellerName)
            : this()
        {
            int transactionTotal = 0;
            int balesTotal = 0;
            int totalAmount = 0;
            groupBox1.Header = sellerName;
            List<SellerDetail> sellerDetail = new List<SellerDetail>();
            sellerDetail = DAL_SellerDetail.LoadSellerDetail(sellerName);
            foreach (var record in sellerDetail)
            {
                transactionTotal++;
                balesTotal = balesTotal + Convert.ToInt32(record.Bales);
                if (record.Amount.HasValue)
                {
                    totalAmount = totalAmount + (int)record.Amount;
                }
            }
            sellerDetailListView.DataContext = sellerDetail;
            tranTotalText.Content = transactionTotal.ToString();
            tranBalesText.Content = balesTotal.ToString();
            tranAmountText.Content = totalAmount.ToString("C0", new CultureInfo("en-IN")) + "/-";
            Detail.Content = sellerDetail;
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplaySeller.xaml", UriKind.Relative));
        }
    }
}
