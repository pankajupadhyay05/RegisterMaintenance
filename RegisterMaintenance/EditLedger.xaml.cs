using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegisterMaintenance.DAL;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for EditLedger.xaml
    /// </summary>
    public partial class EditLedger : Page
    {
        private string updateMessage;
        public EditLedger()
        {
            InitializeComponent();
        }

        public EditLedger(string sellerName)
            : this()
        {
            Ledgers editLedger = new Ledgers();
            editLedger = DAL_Ledgers.LoadLedger(sellerName);
            this.DataContext = editLedger;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression nameBe = nameText.GetBindingExpression(TextBox.TextProperty);
            nameBe.UpdateSource();

            if (nameBe.HasError)
            {
                MessageBox.Show("Please Enter the name", "Insert Aborted");
            }
            else
            {

                updateMessage = ((Ledgers)this.DataContext).Update();
                MessageBox.Show(updateMessage, "Ledger");
                this.NavigationService.Navigate(new Uri("DisplayLedger.xaml", UriKind.Relative));
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayLedger.xaml", UriKind.Relative));
        }
    }
}
