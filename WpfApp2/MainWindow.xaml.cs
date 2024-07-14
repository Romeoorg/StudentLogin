using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


using System.Threading;
using System.Linq.Expressions;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Welcome we = new Welcome();
            we.Show();
            Thread.Sleep(9000);
            we.Close();
            InitializeComponent();
            //InitializeComponent();
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Welcome we = new Welcome();
            we.Show();
        }

        private void txtusername_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void btnstudentlogin_Click(object sender, RoutedEventArgs e)
        {
            StudentLogin st = new StudentLogin();
            st.Show();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ROMEO-AI;Initial Catalog=MettusLoginDatabase;Integrated Security=True");

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                String query = "select count(1) from AdminLogin where Username = @Username AND Password =@Password";
                SqlCommand sqlcmd = new SqlCommand(query, conn);
                sqlcmd.CommandType = System.Data.CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@Username", txtusername.Text);
                sqlcmd.Parameters.AddWithValue("@Password", txtpassword.Text);

                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());

                if (count == 1)
                {
                    MessageBox.Show("Login Succesful");
                    Admin ad = new Admin();
                    ad.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect please verify your loging");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}