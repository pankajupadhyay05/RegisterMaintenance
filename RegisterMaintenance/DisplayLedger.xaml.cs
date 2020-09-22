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
    public partial class DisplayLedger : Page
    {
        public DisplayLedger()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> ledgerList = new List<string>();
            ledgerList = DAL_Ledgers.LoadLedgersString();
            this.DataContext = ledgerList;
            ICollectionView view =
                CollectionViewSource.GetDefaultView(ledgerList);

            new TextSearchFilter(view, this.searchTextBox);
        }

        private void ledgerListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter: displayLedgerDetail(this.ledgerListView.SelectedItem as string);
                    break;
            }
        }

        private void displayLedgerDetail(string ledger)
        {
            string ledgerName = ledger;
            EditLedger el = new EditLedger(ledgerName);
            this.NavigationService.Navigate(el);
        }

        private void ledgerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            displayLedgerDetail(this.ledgerListView.SelectedItem as string);
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CottonRegisters.xaml", UriKind.Relative));
        }
    }
}
