using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using RegisterMaintenance.DAL;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for CreateLedger.xaml
    /// </summary>
    public partial class CreateLedger : Page
    {
        public CreateLedger()
        {
            InitializeComponent();
        }
        string insertMessage;
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression nameBe = nameText.GetBindingExpression(TextBox.TextProperty);
            nameBe.UpdateSource();

            if (nameBe.HasError)
            {
                MessageBox.Show("Please Enter the name", "Insert Aborted");
            }
            else
            {
                Binding insertLedgerBinding = BindingOperations.GetBinding(nameText, TextBox.TextProperty);
                InsertLedger insertLedger = insertLedgerBinding.Source as InsertLedger;
                insertMessage = insertLedger.Add();
                MessageBox.Show(insertMessage, "Ledger");
                this.NavigationService.Refresh();
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Ledger.xaml", UriKind.Relative));
        }
    }
}
