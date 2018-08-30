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
using System.Data;
using System.Data.SqlClient;

namespace MandagsWPF
{
    /// <summary>
    /// Interaction logic for SletKunde.xaml
    /// </summary>
    public partial class SletKunde : Page
    {
        private string connectionString = @"Data Source=(LocalDB)\LocalDB;Initial Catalog=BGBank;Persist Security Info=True;User ID=SQLAdmin;Password=Passw0rd";
        public SletKunde()
        {
            InitializeComponent();
        }

       

        private void SletKunde_button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("delete * from Person WHERE (CPR='" + SletKunde_textBox.Text.Trim() + "'", sqlCon);
                MessageBox.Show("Kunden er slettet");

                SletKunde_textBox.Text = "";
                sqlCon.Close();
            }
        }
    }
}
