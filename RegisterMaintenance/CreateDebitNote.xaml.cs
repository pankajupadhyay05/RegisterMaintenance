using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using RegisterMaintenance.DAL;

namespace RegisterMaintenance
{
    /// <summary>
    /// Interaction logic for CreateDebitNote.xaml
    /// </summary>
    public partial class CreateDebitNote : Page
    {
        public CreateDebitNote()
        {
            InitializeComponent();
            
            // Loading DebitNote Pending List by calling the generic list class

            List<Transactions> transactionPendingDebitNoteList = new List<Transactions>();
            transactionPendingDebitNoteList = DAL_Transactions.LoadTransactionsPendingDebitNote();
            transactionPendingDebitNoteListView.DataContext = transactionPendingDebitNoteList;
            Detail.Content = transactionPendingDebitNoteList;
            if (transactionPendingDebitNoteList.Count == 0)
            {
                this.emptyText.Visibility = Visibility.Visible;
            }
        }

        private void transactionPendingDebitNoteListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            insert(this.transactionPendingDebitNoteListView.SelectedItem as Transactions);
        }

        private void insert(Transactions tran)
        {
            int transactionID = tran.Serial;
            InsertDebitNote dn = new InsertDebitNote();
            bool loadMessage = dn.Load(transactionID);
            if (loadMessage == true)
            {
                this.NavigationService.Navigate(new DebitNoteCreation(dn));
            }
            else
            {
                MessageBox.Show("Some of the date entries for this transaction are empty, please go back to complete them", "ERROR");
            }
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DebitNote.xaml", UriKind.Relative));
        }
    }
}
