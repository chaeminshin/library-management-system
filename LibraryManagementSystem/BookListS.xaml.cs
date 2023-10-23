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

namespace BookListS
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string id;
        static SqlConnection con = new SqlConnection("Data Source=(local)\\sqlexpress;Initial Catalog=group3 ;Trusted_Connection=true;");
        static CheckOut checkOut = new CheckOut();
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
                BookListTableS.ItemsSource = book;
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            list("Search");
        }

        public void update()
        {
            try
            {
                con.Open();
                string sqlQuery =
                    "update Book set Available = 'N'" +
                    "where ISBN = '" + checkOut.ISBN + "';";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    //MessageBox.Show("Book has been updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                //SearchKwd.Text = ex.ToString();
            }
            finally
            {
                con.Close();
            }
            list("View");
        }

        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {
            if(checkOut.Available == "N")
            {
                MessageBox.Show(checkOut.ISBN + " is not available.");
                return;
            }
            try
            {
                DateTime dtNow = DateTime.Now; 
                checkOut.IssueDate = dtNow.ToShortDateString();

                DateTime dtDue = DateTime.Now.AddDays(7);
                checkOut.DueDate = dtDue.ToShortDateString();

                con.Open();

                string sqlQuery =
                    "insert into IssueBook(UserID, ISBN, IssueDate, DueDate, Status) " +
                    "values('" + this.id + "', '" + checkOut.ISBN + "', '" + checkOut.IssueDate + "', '" + checkOut.DueDate + "', '" + checkOut.Status + "')";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                int result = cmd.ExecuteNonQuery(); 
                if (result == 1)
                {                  
                    MessageBox.Show("Check out has been successfully. Please wait for approval of administrator"); 
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                //SearchKwd.Text = ex.ToString();
            }
            finally
            {
                con.Close();
            }
            update();
            list("Search");
        }
        
        private void BookListTableS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Book book = BookListTableS.SelectedItem as Book;
            
            if (book != null)
            {
                checkOut.Status = "Request";
                checkOut.ISBN = book.ISBN;
                checkOut.Available = book.Available;
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

        public class CheckOut
        {
            public int No { get; set; }
            public string ID { get; set; }
            public string UserID { get; set; }
            public string ISBN { get; set; }
            public string IssueDate { get; set; }
            public string DueDate { get; set; }
            public string Status { get; set; }
            public string Available { get; set; }
        }

        private void AllBooks_Click(object sender, RoutedEventArgs e)
        {
            list("View");
            SearchKwd.Text = "";
        }

        public void SetActiveValue2(string param)
        {
            this.id = param;
        }
    }
}
