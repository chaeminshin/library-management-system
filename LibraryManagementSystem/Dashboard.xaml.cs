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

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public delegate void DataPushEventHandler(string value);
    public partial class  Window1 : Window
    {
        public DataPushEventHandler DataSendEvent;

        private string position;
        private string id;
        static SqlConnection con = new SqlConnection("Data Source=(local)\\sqlexpress;Initial Catalog=group3 ;Trusted_Connection=true;");
        public Window1()
        {
            InitializeComponent();
           
        }
        public void checkPosition()
        {
            try
            {
                string sqlQuery = "select position from UserInfo where Email = '" + id + "';";

                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    position = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                }
                if (position == "A")
                {
                    User.Visibility = Visibility.Visible;
                    Book.Visibility = Visibility.Visible;
                    IssueBook.Visibility = Visibility.Visible;

                    Borrow.Visibility = Visibility.Hidden;
                    MyBook.Visibility = Visibility.Hidden;
                }

                if (position == "L")
                {
                    User.Visibility = Visibility.Hidden;
                    Book.Visibility = Visibility.Visible;
                    IssueBook.Visibility = Visibility.Visible;

                    Borrow.Visibility = Visibility.Hidden;
                    MyBook.Visibility = Visibility.Hidden;

                }

                if (position == "S")
                {
                    User.Visibility = Visibility.Hidden;
                    Book.Visibility = Visibility.Hidden;
                    IssueBook.Visibility = Visibility.Hidden;

                    Borrow.Visibility = Visibility.Visible;
                    MyBook.Visibility = Visibility.Visible;
                }

                if (position == "")
                {
                    User.Visibility = Visibility.Hidden;
                    Book.Visibility = Visibility.Hidden;
                    IssueBook.Visibility = Visibility.Hidden;

                    Borrow.Visibility = Visibility.Hidden;
                    MyBook.Visibility = Visibility.Hidden;

                    
                }

            }
            catch (Exception ex)
            {
                User.Content = ex.ToString();
                //MessageBox.Show("Not successfully.");
            }
            finally
            {
                con.Close();
            }
        }
        public void SetActiveValue(string param)
        {            
            id = param;

            checkPosition();

            string tempPosition = "";
            if (position == "A")
            {
                tempPosition = "Administrator";
            }
            else if (position == "L")
            {
                tempPosition = "Librarian";
            }
            else if (position == "S")
            {
                tempPosition = "Student";
            }
            else
            {
                tempPosition = "Guest";
                MessageBox.Show("Administrator approval is required. Please contact administrator.");
            }
            ID.Content = param + "(" + tempPosition + ") is logged in";

           
        }
       
        private void BookList_Click(object sender, RoutedEventArgs e)
        {
            BookList.Window1 moveToBookList = new BookList.Window1();
            moveToBookList.ShowDialog();
        }

        private void UserList_Click(object sender, RoutedEventArgs e)
        {
            UserList.Window1 moveToBookList = new UserList.Window1();
            moveToBookList.ShowDialog();
        }


        

        private void IssueBook_Click(object sender, RoutedEventArgs e)
        {
            IssueBookList.Window1 moveToIssueBookList = new IssueBookList.Window1();
            moveToIssueBookList.ShowDialog();
        }

        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            BookListS.Window1 moveToBookListS = new BookListS.Window1();
            this.DataSendEvent += new DataPushEventHandler(moveToBookListS.SetActiveValue2);
            DataSendEvent(id);

            moveToBookListS.ShowDialog();
        }

        private void MyBook_Click(object sender, RoutedEventArgs e)
        {
            MyBookList.Window1 moveToMyBookList = new MyBookList.Window1();
            this.DataSendEvent += new DataPushEventHandler(moveToMyBookList.SetActiveValue1);
            DataSendEvent(id);

            moveToMyBookList.ShowDialog();
        }
    }
}
