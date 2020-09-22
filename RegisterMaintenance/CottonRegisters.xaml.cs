using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for CottonRegisters.xaml
    /// </summary>
    public partial class CottonRegisters : Page
    {
        public CottonRegisters()
        {
            InitializeComponent();
        }

        private void transactionRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("TransactionRegister.xaml", UriKind.Relative));
        }

        private void sellerRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplaySeller.xaml", UriKind.Relative));
        }

        private void buyerRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayBuyer.xaml", UriKind.Relative));
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            closeApp();
        }

        private void closeApp()
        {
            MessageBoxResult key = MessageBox.Show(
                "Are you sure you want to quit",
                "Confirm",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);
            if (key == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void ledgerButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ledger.xaml", UriKind.Relative));
        }

        private void groupButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DebitNoteCreation.xaml", UriKind.Relative));
        }

        private void invoiceButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Invoice.xaml", UriKind.Relative));
        }

        private void debitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DebitNote.xaml", UriKind.Relative));
        }
    }
}
