using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

using System.Data.Sql;




using System.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for StudentLogin.xaml
    /// </summary>
    public partial class StudentLogin : Window
    {
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnlogin_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=ROMEO-AI;Initial Catalog=MettusLoginDatabase;Integrated Security=True");

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();

                String query = "select count(1) from Studentlogin where Username = @Username AND Password = @Password";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@Username", by.Text);
                sqlcmd.Parameters.AddWithValue("@Password", bx.Text);


                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count == 1)
                {
                    StudentRegisteration std = new StudentRegisteration();
                    std.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Welcome we = new Welcome();
            we.Show();
        }
    }
}
