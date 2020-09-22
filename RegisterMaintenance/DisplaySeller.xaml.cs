using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using RegisterMaintenance.DAL;
using System.ComponentModel;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for DisplaySeller.xaml
    /// </summary>
    public partial class DisplaySeller : Page
    {
        public DisplaySeller()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> sellerList = new List<string>();
            sellerList = DAL_Sellers.LoadSellersString();

            sellerListView.DataContext = sellerList;
            ICollectionView view =
                CollectionViewSource.GetDefaultView(sellerList);

            new TextSearchFilter(view, this.searchTextBox);
        }

        private void sellerListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter: displaySellerDetail(this.sellerListView.SelectedItem as string);
                    break;
            }
        }

        private void displaySellerDetail(string seller)
        {
            string sellerName = seller;
            DisplaySellerDetail ds = new DisplaySellerDetail(sellerName);
            this.NavigationService.Navigate(ds);
        }

        private void sellerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            displaySellerDetail(this.sellerListView.SelectedItem as string);
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CottonRegisters.xaml", UriKind.Relative));
        }
    }
}
