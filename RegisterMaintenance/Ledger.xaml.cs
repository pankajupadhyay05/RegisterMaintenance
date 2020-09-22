using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for Ledger.xaml
    /// </summary>
    public partial class Ledger : Page
    {
        public Ledger()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CreateLedger.xaml", UriKind.Relative));
        }

        private void displayRecordButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayLedger.xaml", UriKind.Relative));
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CottonRegisters.xaml", UriKind.Relative));
        }
    }
}
