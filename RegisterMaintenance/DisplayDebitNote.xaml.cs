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
    /// Interaction logic for DisplayDebitNote.xaml
    /// </summary>
    public partial class DisplayDebitNote : Page
    {
        public DisplayDebitNote()
        {
            InitializeComponent();

            // Loading Invoice List by calling the generic list class

            List<DebitNotes> debitNoteList = new List<DebitNotes>();
            debitNoteList = DAL_DebitNotes.LoadDebitNotes();
            debitNoteListView.DataContext = debitNoteList;
            Detail.Content = debitNoteList;
            if (debitNoteList.Count == 0)
            {
                this.emptyText.Visibility = Visibility.Visible;
            }
        }

        private void debitNoteListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            edit(this.debitNoteListView.SelectedItem as DebitNotes);
        }

        private void edit(DebitNotes updateDebitNote)
        {
            EditDebitNote ed = new EditDebitNote(updateDebitNote);
            this.NavigationService.Navigate(ed);
        }

        private void exitbutton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DebitNote.xaml", UriKind.Relative));
        }
    }
}
