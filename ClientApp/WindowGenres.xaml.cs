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
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for WindowGenres.xaml
    /// </summary>
    public partial class WindowGenres : Window
    {
        public List<Genre> Genres { get; set; }
        public List<Book> Livres { get; set; }
        public Book Livre { get; set; }

   
        public WindowGenres()
        {
            InitializeComponent();
        }

        public async Task<int> fillsComboboxGenre(int pseize=0)
        {
            listGenres.Items.Clear();
            idGenres.Items.Clear();
            List<Genre> genre = await Genre.getAllAsync(pseize);

            this.Genres = genre;



            foreach (Genre item in genre)
            {
                listGenres.Items.Add(item.Nom);
                idGenres.Items.Add(item.Id);


            }

            return 0;
        }
        private async void mainStackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            paging.Items.Add("Seize");
            paging.Items.Add(2);
            paging.Items.Add(5);
            paging.Items.Add(10);
            paging.Items.Add(15);
            paging.Items.Add(20);

            paging.SelectedIndex = 0;

            var a = await fillsComboboxGenre();

        }

        private async void listGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

             listBooks.Items.Clear();
             idBooks.Items.Clear();


            int b = listGenres.SelectedIndex;
            idGenres.SelectedIndex = b;
            var idItem = idGenres.SelectedItem;


            List<Book> books = await Book.getByGenreId(int.Parse(idItem.ToString()));

            this.Livres = books;



            foreach (Book item in books)
            {
                listBooks.Items.Add(item.Title);
                idBooks.Items.Add(item.Id);


            }

        }

        public void displayData(List<Book> books)
        {

            if (this.listView != null) listView.Items.Clear();

            // Initialize
            this.InitializeComponent();

            // Add columns
            var gridView = new GridView();

            this.listView.View = gridView;


            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id",
                DisplayMemberBinding = new Binding("Id")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Title",
                DisplayMemberBinding = new Binding("Title")
            });



            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Prix",
                DisplayMemberBinding = new Binding("Prix")
            });

            for (int i = 0; i < books[0].Genre.Count; i++)
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = $"Genre {i + 1}",
                    DisplayMemberBinding = new Binding($"Genre[{i}].Nom")
                });




            // Populate list

            foreach (Book item in books)
            {
                this.listView.Items.Add(item);



            }
        }

        private void listBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            listView.Items.Clear();
            
            int b = listBooks.SelectedIndex;
            idBooks.SelectedIndex = b;
            var idItem = idBooks.SelectedItem;
            if (idItem != null)
            {
                IEnumerable<Book> filteringQuery =
                from l in Livres
                where l.Id == Int32.Parse(idItem.ToString())
                select l;

                List<Book> result = filteringQuery.ToList();
                this.Livre = result[0];
                listView.Visibility = Visibility.Visible;
                detail.Visibility = Visibility.Visible;
                displayData(result);
            }

            

        }

        private void detail_Click(object sender, RoutedEventArgs e)
        {
            if (Livre != null)
            {
                DetailBook detail = new DetailBook(this.Livre);
                detail.Show();
            }
        }

        private async void paging_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pseize;
            string a = paging.SelectedItem.ToString();
            if (a == "Seize")
            {
                pseize = 0;
            }
            else
            {
                pseize = int.Parse(a);
            }

            var cbx = await fillsComboboxGenre(pseize);
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window main = Application.Current.MainWindow;
            var a = Application.Current.Windows;
            main.Show();
        }
    }
}
