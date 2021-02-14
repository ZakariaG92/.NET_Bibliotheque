using ClientApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for DetailBook.xaml
    /// </summary>
    public partial class DetailBook : Window
    {
        private Book Book { get; set; }
        public DetailBook( Book book)
        {
            this.Book = book;
            InitializeComponent();

            title.Content = book.Title;
            textBlock.Text = book.Contenu;
        }


        private void home_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window main= Application.Current.MainWindow;
            var a =   Application.Current.Windows;
            main.Show();
        }
    }
}
