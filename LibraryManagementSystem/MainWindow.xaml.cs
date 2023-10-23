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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public delegate void DataPushEventHandler(string value);
    public partial class MainWindow : Window
    {
        public DataPushEventHandler DataSendEvent;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp.Window1 moveToSignUp = new SignUp.Window1();
            moveToSignUp.ShowDialog();
        }

        
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(local)\\sqlexpress;Initial Catalog=Group3 ;Trusted_Connection=true;");
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                string query = "SELECT count(1) from UserInfo WHERE Email = '" + txtUsername.Text.Trim() +"' AND Password='" + txtPassword.Password.Trim() +"';";
                
                SqlCommand sqlcmd = new SqlCommand(query, con);
                sqlcmd.CommandType = System.Data.CommandType.Text;
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count == 1)
                {
                    MessageBox.Show("Successfully");

                    Dashboard.Window1 moveToDashboard = new Dashboard.Window1();

                    this.DataSendEvent += new DataPushEventHandler(moveToDashboard.SetActiveValue);
                    DataSendEvent(txtUsername.Text.Trim());

                    moveToDashboard.ShowDialog();

                    txtUsername.Text = "";
                    txtPassword.Password = "";

                }
                else
                {
                    MessageBox.Show("ID or Password is not valided");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();
            }
            
        }
       
    }
}
