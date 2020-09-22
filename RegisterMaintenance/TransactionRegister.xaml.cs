using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for TransactionRegisters.xaml
    /// </summary>
    public partial class TransactionRegister : Page
    {
        public TransactionRegister()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("NewRecord.xaml", UriKind.Relative));
        }

        private void displayButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayTransaction.xaml", UriKind.Relative));
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CottonRegisters.xaml", UriKind.Relative));
        }
    }
}
