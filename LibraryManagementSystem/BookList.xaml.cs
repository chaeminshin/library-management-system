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

using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace BookList
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static SqlConnection con = new SqlConnection("Data Source=(local)\\sqlexpress;Initial Catalog=group3 ;Trusted_Connection=true;");
        public Window1()
        {
            InitializeComponent();
            list("View");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void list(string flag)
        {
            List<Book> book = new List<Book>();

            try
            {
                string sqlQuery = "select ISBN, Title, Author, FORMAT(CAST(PublishedDate AS DATE), 'yyyyMMdd'), Description, Available from Book";
                if (flag == "Search") 
                {
                    sqlQuery = sqlQuery + " where " +
                        "Title like '%" + SearchKwd.Text.Trim() + "%' or " +
                        "Title like '%" + SearchKwd.Text.Trim() + "' or " +
                        "Title like '" + SearchKwd.Text.Trim() + "%';";
                }

                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int no = i + 1;
                    string isbn = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    string title = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    string author = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    string publishedDate = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    string description = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    string available = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                    book.Add(new Book() { No = no, ISBN = isbn, Title = title, Author = author, PublishedDate = publishedDate, Description = description, Available = available });
                    
                }
                BookListTable.ItemsSource = book; 
            }
            catch (Exception ex)
            {
                //Title.Text = ex.ToString();
                //MessageBox.Show("Not successfully.");
            }
            finally
            {
                con.Close();
            }  
        }
  
        public string RadioBtn()
        {
            RadioButton radioButton = (from element in radioButtonPanel.Children.Cast<UIElement>()
                                       where element is RadioButton && (element as RadioButton).IsChecked.Value
                                       select element).SingleOrDefault() as RadioButton;
            string content = radioButton.Content as string;  
            bool check = radioButton.IsChecked.Value;  
            string tag = radioButton.Tag as string;
            return tag; 
        }
        



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string sqlQuery =
                    "insert into Book (ISBN, Title, Author, Description, PublishedDate, Available) " + 
                    "values('"+ ISBN.Text+"', '"+ Title.Text+"', '" + Author.Text + "', '" + Description.Text + "', '" + PublishedDate.Text + "', '"+ RadioBtn()+ "');";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                int result = cmd.ExecuteNonQuery();
                if(result == 1)
                {
                    MessageBox.Show("Book has been added successfully.");
                }
                else 
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                ///Title.Text = ex.ToString();
            }
            finally
            {
                con.Close();
            }
            list("View");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string sqlQuery =
                    "update Book set " +
                    "ISBN = '" + ISBN.Text + "', Title = '" + Title.Text + "', Author = '" + Author.Text + "', Description = '" + Description.Text + "', PublishedDate = '" + PublishedDate.Text + "', Available = '" + RadioBtn() + "'" +
                    "where ISBN = '" + ISBN.Text.Trim() + "';";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Book has been updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                //Title.Text = ex.ToString();
            }
            finally
            {
                con.Close();
            }
            list("View");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sqlQuery = "delete from Book where ISBN = " + ISBN.Text;

                con.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Book has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                //Title.Text= ex.ToString();
            }
            finally
            {
                con.Close();
            }
            list("View");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            list("Search");
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ISBN.Text = "";
            ISBN.IsEnabled = true;
            Title.Text = "";
            Author.Text = "";
            PublishedDate.Text = "";
            Description.Text = "";
            AvailableY.IsChecked = false;
            AvailableN.IsChecked = false;
        }

        private void BookListTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Book book = BookListTable.SelectedItem as Book;
            if (book != null)
            {
                ISBN.Text = book.ISBN;
                ISBN.IsEnabled = false;
                Title.Text = book.Title;
                Author.Text = book.Author;
                Description.Text = book.Description;
                PublishedDate.Text = book.PublishedDate;

                string flagAvailable = book.Available;
                if (flagAvailable == "Y")
                {
                    AvailableY.IsChecked = true;
                    AvailableN.IsChecked = false;
                }
                else
                {
                    AvailableY.IsChecked = false;
                    AvailableN.IsChecked = true;
                }
            }
        }

        public class Book
        {
            public int No { get; set; }
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
            public string PublishedDate { get; set; }
            public string Available { get; set; }
        }

        private void AllBooks_Click(object sender, RoutedEventArgs e)
        {
            list("View");
            SearchKwd.Text = "";
        }
    }
}
