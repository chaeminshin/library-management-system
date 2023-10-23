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
using System.Text.RegularExpressions;


namespace SignUp

{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static SqlConnection con = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=group3 ;Trusted_Connection=true;");
        public Window1()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            bool isValidEmail = IsValidEmail(txtBoxEmail.Text);
            if(isValidEmail == false)
            {
                MessageBox.Show("The email address format is not valid.");
                return;
            }

            if (passwordBox1.Password != passwordBoxConfirm.Password)
            {
                MessageBox.Show("Password and Confirm password must be the same.");
                return;
            }
            

            try
            {
                con.Open();
                string sqlQuery =
                    "insert into UserInfo(Email, Fullname, Password, Phone, Address, PostalCode) " +
                    "values('" + txtBoxEmail.Text + "', '" + txtfullname.Text + "', '" + passwordBox1.Password + "', '" + textBoxPhoneNum.Text + "', '" + textBoxAddress.Text + "', '" + textBoxPostalCode.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("User has been added successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                //txtBoxEmail.Text = ex.ToString();
            }
            finally
            {
                con.Close();
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public bool IsValidEmail(string email)
        {
            bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            return valid;
        }
    }


}




