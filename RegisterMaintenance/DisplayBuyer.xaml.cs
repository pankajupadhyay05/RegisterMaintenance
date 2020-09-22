using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Navigation;
using RegisterMaintenance.DAL;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for DisplayBuyer.xaml
    /// </summary>
    public partial class DisplayBuyer : Page
    {
        public DisplayBuyer()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> buyerList = new List<string>();
            buyerList = DAL_Buyers.LoadBuyersString();

            buyerListView.DataContext = buyerList;
            ICollectionView view =
                CollectionViewSource.GetDefaultView(buyerList);

            new TextSearchFilter(view, this.searchTextBox);
        }

        private void buyerListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter: displayBuyerDetail(this.buyerListView.SelectedItem as string);
                    break;
            }
        }

        private void displayBuyerDetail(string buyer)
        {
            string buyerName = buyer;
            DisplayBuyerDetail ds = new DisplayBuyerDetail(buyerName);
            this.NavigationService.Navigate(ds);
        }

        private void buyerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            displayBuyerDetail(this.buyerListView.SelectedItem as string);
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CottonRegisters.xaml", UriKind.Relative));
        }
    }
}
