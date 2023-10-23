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

namespace IssueBookList
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

        private void UserListTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void list(string flag)
        {
           List<IssueBook> issueBook = new List<IssueBook>();
           
           try
           {
               string sqlQuery = "select Id, Status, UserID, ISBN, FORMAT(CAST(IssueDate AS DATE), 'yyyyMMdd') as IssueDt, FORMAT(CAST(DueDate AS DATE), 'yyyyMMdd') as DueDt from IssueBook ";
               if (flag == "Request")
               {
                    sqlQuery = sqlQuery + "where Status = '" + Request.Tag as string + "';";
               }
               else if (flag == "Loan")
               {
                    sqlQuery = sqlQuery + "where Status = '" + Loan.Tag as string + "';";
                }
               else if(flag == "Returned")
               {
                    sqlQuery = sqlQuery + "where Status = '" + Returned.Tag as string + "';";
                }
                else
                {

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
                   string userId = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                   string isbn = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                   string issueDate = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                   string dueDate = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                   issueBook.Add(new IssueBook() { No = no, ID = id, Status = status, UserId = userId, ISBN = isbn, IssueDate = issueDate, DueDate = dueDate });

               }
               IssueBookListTable.ItemsSource = issueBook;
           }
           catch (Exception ex)
           {
               Status.Text = ex.ToString();
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

       private void IssueBookListTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {

            IssueBook issueBook = IssueBookListTable.SelectedItem as IssueBook;
           if (issueBook != null)
           {
                ID.Text = issueBook.ID;
                Status.Text = issueBook.Status;
                UserId.Text = issueBook.UserId;
                ISBN.Text = issueBook.ISBN;
                IssueDate.Text = issueBook.IssueDate;
                DueDate.Text = issueBook.DueDate;

                ID.IsEnabled = false;
                Status.IsEnabled = false;
                UserId.IsEnabled = false;
                ISBN.IsEnabled = false;
                IssueDate.IsEnabled = false;
                DueDate.IsEnabled = false;
            }
       }

        public void approval()
        {
            try
            {
                if (Status.Text == "Loan" || Status.Text == "Returned")
                {
                    MessageBox.Show("Only acceptable with a status value of 'Request'.");
                    return;
                }
                con.Open();
                string sqlQuery =
                    "update IssueBook set Status = 'Loan' " +
                    "where ID = " + ID.Text + " and ISBN = '" + ISBN.Text + "';";
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
                //Status.Text = ex.ToString();
            }
            finally
            {
                con.Close();
            }
            list("View");
            reset();
        }

        public void reset()
        {
            ID.Text = "";
            UserId.Text = "";
            ISBN.Text = "";
            IssueDate.Text = "";
            DueDate.Text = "";
            Status.Text = "";
        }


        public class IssueBook
        {
            public int No { get; set; }
            public string ID { get; set; }
            public string UserId { get; set; }
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

        private void Approval_Click(object sender, RoutedEventArgs e)
        {
            approval();
        }
    }
}
