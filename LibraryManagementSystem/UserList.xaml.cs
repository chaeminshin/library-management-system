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

namespace UserList
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
            List<User> user = new List<User>();

            try
            {
                string sqlQuery = "select ID, Email, Fullname, Address, PostalCode, Phone, Position, Department, Semester from UserInfo";
                if (flag == "Search") 
                {
                    sqlQuery = sqlQuery + " where " +
                        "Fullname like '%" + SearchKwd.Text.Trim() + "%' or " +
                        "Fullname like '%" + SearchKwd.Text.Trim() + "' or " +
                        "Fullname like '" + SearchKwd.Text.Trim() + "%';";
                }

                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
                DataSet ds = new DataSet();
                con.Open();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int no = i + 1;
                    string id = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    string email = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    string fullname = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    string address = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    string postalCode = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    string phone = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    string position = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                    string department = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    string semester = ds.Tables[0].Rows[i].ItemArray[8].ToString();

                    user.Add(new User() { No = no, ID = id, Email = email, Name = fullname, Address = address, PostalCode = postalCode, Phone = phone, Position = position, Department = department, Semester = semester });
                    
                }
                UserListTable.ItemsSource = user; 
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


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string sqlQuery =
                    "update UserInfo set " +
                    "Fullname = '" + Name.Text + "', Email = '" + Email.Text + "', Address = '" + Address.Text + "', PostalCode = '" + PostalCode.Text + "', Department = '"  + Department.Text + "', Semester = '" + Semester.Text + "', Position = '" + RadioBtn() + "'" +
                    "where ID = '" + ID.Text.Trim() + "';";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("User has been updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                Email.Text = ex.ToString();
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
                string sqlQuery = "delete from UserInfo where ID = " + ID.Text;

                con.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("User has been deleted successfully.");
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
            ID.Text = "";
            ID.IsEnabled = true;
            Name.Text = "";
            Email.Text = "";
            Address.Text = "";
            PostalCode.Text = "";
            Department.Text = "";
            Semester.Text = "";
            PositionA.IsChecked = false;
            PositionL.IsChecked = false;
            PositionS.IsChecked = false;
        }

        private void UserListTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            User user = UserListTable.SelectedItem as User;
            if (user != null)
            {
                ID.Text = user.ID;
                ID.IsEnabled = false;
                Name.Text = user.Name;
                Email.Text = user.Email;
                Address.Text = user.Address;
                PostalCode.Text = user.PostalCode;
                Department.Text = user.Department;
                Semester.Text = user.Semester;

                string flagPosition = user.Position;
                if (flagPosition == "A")
                {
                    PositionA.IsChecked = true;
                    PositionL.IsChecked = false;
                    PositionS.IsChecked = false;
                }
                else if(flagPosition == "L")
                {
                    PositionA.IsChecked = false;
                    PositionL.IsChecked = true;
                    PositionS.IsChecked = false;
                }
                else
                {
                    PositionA.IsChecked = false;
                    PositionL.IsChecked = false;
                    PositionS.IsChecked = true;
                }
            }
        }

        public class User
        {
            public int No { get; set; }
            public string ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string PostalCode { get; set; }
            public string Department { get; set; }
            public string Semester { get; set; }
            public string Position { get; set; }
            public string Phone { get; set; }
        }

        private void AllUsers_Click(object sender, RoutedEventArgs e)
        {
            list("View");
            SearchKwd.Text = "";
        }
    }
}
