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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for StudentRegisteration.xaml
    /// </summary>
    public partial class StudentRegisteration : Window
    {
        ConnectToDB dbc = new ConnectToDB();
        public StudentRegisteration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbc.Registration(Convert.ToInt32(txtstudentid.Text), txtfirstname.Text, txtsurname.Text, txtcity.Text, txtaddress.Text, txtcellphone1.Text);
            MessageBox.Show("Student Registered succesfully");

            txtstudentid.Text = "";
            txtfirstname.Text = "";
            txtsurname.Text = "";
            txtaddress.Text = "";
            txtcity.Text = "";
            txtcellphone1.Text = "";

        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            dbc.UpdateStudentsInfo(Convert.ToInt32(txtstudentid.Text), txtfirstname.Text, txtsurname.Text,txtcity.Text, txtaddress.Text, txtcellphone1.Text);
            MessageBox.Show("Students information updated succesfully");
            txtstudentid.Text = "";
            txtfirstname.Text = "";
            txtsurname.Text = "";
            txtaddress.Text = "";
            txtcity.Text = "";
            txtcellphone1.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dbc.DeleteStudentInfo(Convert.ToInt32(txtstudentid.Text));
            MessageBox.Show("Student Information Deleted Succesfully");
            txtstudentid.Text = "";
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Welcome we = new Welcome();
            we.Show();
        }
    }
}
