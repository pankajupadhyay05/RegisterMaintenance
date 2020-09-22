using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dateTimeLabel.Content = DateTime.Now;
            CottonRegisters cottonRegisters = new CottonRegisters();
            frame1.Navigate(new Uri("CottonRegisters.xaml", UriKind.Relative));
        }

        private void exit_Click(object sender, RoutedEventArgs e)
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

        private void newTransactionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("NewRecord.xaml", UriKind.Relative));
        }

        private void editTransactionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("DisplayTransaction.xaml", UriKind.Relative));
        }

        private void printInvoiceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("DisplayInvoice.xaml", UriKind.Relative));
        }

        private void printDebitNoteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("DisplayDebitNote.xaml", UriKind.Relative));
        }

        private void newLedgerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("CreateLedger.xaml", UriKind.Relative));
        }

        private void editLedgerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("DisplayLedger.xaml", UriKind.Relative));
        }

        private void newInvoiceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("CreateInvoice.xaml", UriKind.Relative));
        }

        private void editInvoiceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("DisplayInvoice.xaml", UriKind.Relative));
        }

        private void newDebitNoteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("CreateDebitNote.xaml", UriKind.Relative));
        }

        private void editDebitNoteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame1.Navigate(new Uri("DisplayDebitNote.xaml", UriKind.Relative));
        }

        private void aboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Nullable<bool> dlgResult;
            About dlgWindow = new About();
            dlgWindow.Height = 315;
            dlgWindow.Width = 500;

            dlgWindow.InitializeComponent();

            dlgWindow.Owner = this;
            dlgWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            dlgResult = dlgWindow.ShowDialog();
        }
    }
}
