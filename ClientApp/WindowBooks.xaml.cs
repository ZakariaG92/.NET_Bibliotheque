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


    public partial class WindowBooks : Window
    {
       public List<Book> Livres { get; set; }
       public Book Livre { get; set; }
        public WindowBooks()
        {
            Console.WriteLine("created");
            InitializeComponent();
            // listBoxBooks.Items.Add("item1");


        }




        public async Task<string> fillComboboxBooks(int pseize=0)
        {
            
            combobox.Items.Clear();
            idCombobox.Items.Clear();

            

            List<Book> book = await Book.getAllAsync(pseize);

            this.Livres = book;



            foreach (Book item in book)
            {
                combobox.Items.Add(item.Title);
                idCombobox.Items.Add(item.Id);


            }

            return null;
        }




        private async void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            paging.Items.Add("Seize");
            paging.Items.Add(2);
            paging.Items.Add(5);
            paging.Items.Add(10);
            paging.Items.Add(15);
            paging.Items.Add(20);

            var a = await fillComboboxBooks();

        }

        public void displayData(List<Book> books)
        {
            
            if (this.listView!=null)  listView.Items.Clear();

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

           for(int i=0; i < books[0].Genre.Count; i++ )
                gridView.Columns.Add(new GridViewColumn
                {
                    Header = $"Genre {i+1}",
                    DisplayMemberBinding = new Binding($"Genre[{i}].Nom")
                });
            
          


            // Populate list

            foreach (Book item in books)
            {
                 this.listView.Items.Add(item);
             


            }
        }


        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string a = combobox.SelectedItem.ToString();
            var b = combobox.SelectedIndex;

            idCombobox.SelectedIndex = b;
            var idItem = idCombobox.SelectedItem;

            IEnumerable<Book> filteringQuery =
            from l in Livres
            where l.Id == Int32.Parse(idItem.ToString()) 
            select l;

            List<Book> result = filteringQuery.ToList();
            List<Genre> g = result[0].Genre;
           
            this.Livre = result[0];

            String gen = "Genre du livre : ";
            foreach (Genre genre in g)
            {
                gen += $"{genre.Nom}  ";
            }

            displayData(result);
           



        }

        private void detailButton_Click(object sender, RoutedEventArgs e)
        {
            if (Livre!=null)
            {
                DetailBook detail = new DetailBook(this.Livre);
                detail.Show();
            }
          
        }

        private async void  paging_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

           var cbx = await fillComboboxBooks(pseize);
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
