using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for DebitNote.xaml
    /// </summary>
    public partial class DebitNote : Page
    {
        public DebitNote()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CreateDebitNote.xaml", UriKind.Relative));
        }

        private void displayButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayDebitNote.xaml", UriKind.Relative));
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CottonRegisters.xaml", UriKind.Relative));
        }
    }
}
