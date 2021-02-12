using ClientApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            /* 
             *Book bookId=  await Book.getByIdAsync(1);
             txtBox.Text = $"le contenue est : {bookId.Contenu}";
             lb.Items.Add(bookId.Id);
             lb.Items.Add(bookId.Id);
             lb.Items.Add(bookId.Id);
             lb.Items.Add(bookId.Id);
             lb.Items.Add(bookId.Id);
          */
        }

        private void btnB_Click(object sender, RoutedEventArgs e)
        {
            WindowBooks winB = new WindowBooks();
            winB.Show();

        }

        private void btnG_Click(object sender, RoutedEventArgs e)
        {
            WindowGenres winG = new WindowGenres();
            winG.Show();
        }


    }
}
