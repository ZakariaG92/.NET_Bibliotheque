using ClientApp.ViewModel;
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





 

     

        private async void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
           List<Book> book = await Book.getAllAsync();

           this.Livres = book;

          
/*

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
                Header = "Contenu",
                DisplayMemberBinding = new Binding("Contenu")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Prix",
                DisplayMemberBinding = new Binding("Prix")
            });

            */

            // Populate list

            foreach (Book item in book)
            {
                // this.listView.Items.Add(item);
                combobox.Items.Add(item.Title);


            }
            


        }


        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string a = combobox.SelectedItem.ToString();

            IEnumerable<Book> filteringQuery =
            from l in Livres
            where l.Title == a 
            select l;

            List<Book> result = filteringQuery.ToList();
            List<Genre> g = result[0].Genre;
           
            this.Livre = result[0];

            String gen = "Genre du livre : ";
            foreach (Genre genre in g)
            {
                gen += $"{genre.Nom}  ";
            }
            labelPrix.Content = $"Prix : {result[0].Prix}";
            labelgenre1.Content = gen;


           



        }

        private void detailButton_Click(object sender, RoutedEventArgs e)
        {
            if (Livre!=null)
            {
                DetailBook detail = new DetailBook(this.Livre);
                detail.Show();
            }
          
        }
    }

}
