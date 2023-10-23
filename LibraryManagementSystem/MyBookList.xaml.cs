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

namespace MyBookList
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string id;
        static SqlConnection con = new SqlConnection("Data Source=(local)\\sqlexpress;Initial Catalog=group3 ;Trusted_Connection=true;");
        public Window1()
        {
            InitializeComponent();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void list(string flag)
        {
           List<IssueBook> issueBook = new List<IssueBook>();
           
           try
           {
               string sqlQuery = "select i.Id, i.Status, i.ISBN, b.Title, FORMAT(CAST(i.IssueDate AS DATE), 'yyyyMMdd') as IssueDt, FORMAT(CAST(i.DueDate AS DATE), 'yyyyMMdd') as DueDt, i.UserID from IssueBook i left outer join Book b on b.ISBN = i.ISBN where i.UserID = '" + this.id + "' ";
               if (flag == "Request")
               {
                    sqlQuery = sqlQuery + "and i.Status = '" + Request.Tag as string + "';";
               }
               else if (flag == "Loan")
               {
                    sqlQuery = sqlQuery + "and i.Status = '" + Loan.Tag as string + "';";
                }
               else if(flag == "Returned")
               {
                    sqlQuery = sqlQuery + "and i.Status = '" + Returned.Tag as string + "';";
               }
               

               SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
               DataSet ds = new DataSet();
               con.Open();
               da.Fill(ds);
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                    int no = i + 1;
                    string id = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    string status = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    string isbn = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    string title = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    string issueDate = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    string dueDate = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    string userId = ds.Tables[0].Rows[i].ItemArray[6].ToString();

                    issueBook.Add(new IssueBook() { No = no, ID = id, Status = status, Title = title, ISBN = isbn, IssueDate = issueDate, DueDate = dueDate, UserId = userId });

               }
               MyBookListTable.ItemsSource = issueBook;
           }
           catch (Exception ex)
           {
               //Status.Text = ex.ToString();
               //MessageBox.Show("Not successfully.");
           }
           finally
           {
               con.Close();
           }
        }

        public void update()
        {
            try
            {
                con.Open();
                string sqlQuery =
                    "update Book set Available = 'Y'" +
                    "where ISBN = '" + ISBN.Text + "';";
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
                Status.Text = ex.ToString();
            }
            finally
            {
                con.Close();
            }
            list("View");
        }

       private void MyBookListTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {

            IssueBook issueBook = MyBookListTable.SelectedItem as IssueBook;
           if (issueBook != null)
           {
                ID.Text = issueBook.ID;
                Status.Text = issueBook.Status;
                ISBN.Text = issueBook.ISBN;
                Title.Text = issueBook.Title;
                IssueDate.Text = issueBook.IssueDate;
                DueDate.Text = issueBook.DueDate;
                UserId.Text = issueBook.UserId;
                 
                ID.IsEnabled = false;
                Status.IsEnabled = false;
                ISBN.IsEnabled = false;
                Title.IsEnabled = false;
                IssueDate.IsEnabled = false;
                DueDate.IsEnabled = false;
                UserId.IsEnabled = false;
            }
       }

        public void returnBook()
        {
            try
            {
                con.Open();
                string sqlQuery =
                    "update IssueBook set Status = 'Returned' " +
                    "where ID = " + ID.Text + " and ISBN = '" + ISBN.Text + "' and UserId = '" + UserId.Text + "';";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    //MessageBox.Show("Book has been updated successfully.");
                }
                else
                {
                    //MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                Status.Text = ex.ToString();
            }
            finally
            {
                con.Close();
            }
            update();
            list("View");
            //reset();
        }

        public void reset()
        {
            ID.Text = "";
            ISBN.Text = "";
            Title.Text = "";
            IssueDate.Text = "";
            DueDate.Text = "";
            Status.Text = "";
        }


        public class IssueBook
        {
            public int No { get; set; }
            public string ID { get; set; }
            public string UserId { get; set; }
            public string Title { get; set; }
            public string ISBN { get; set; }
            public string IssueDate { get; set; }
            public string DueDate { get; set; }
            public string Status { get; set; }
        }

        private void All_Checked(object sender, RoutedEventArgs e)
        {
            list("View");
        }

        private void Request_Checked(object sender, RoutedEventArgs e)
        { 
            list("Request");
        }

        private void Loan_Checked(object sender, RoutedEventArgs e)
        {
            list("Loan");
        }

        private void Returned_Checked(object sender, RoutedEventArgs e)
        {
            list("Returned");
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            returnBook();
        }

        public void SetActiveValue1(string param)
        {
            this.id = param;
            list("View");
        }
    }
}
