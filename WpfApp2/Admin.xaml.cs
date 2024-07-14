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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        ConnectToDB dbc2 = new ConnectToDB();
        public Admin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbc2.DisplayStudentsInfo();
            datagrids.ItemsSource = dbc2.table.DefaultView;
        }

        private void datagrids_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
      
    }
}
