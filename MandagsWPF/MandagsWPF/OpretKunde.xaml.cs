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
using System.Data;

namespace MandagsWPF
{
    /// <summary>
    /// Interaction logic for OpretKunde.xaml
    /// </summary>
    public partial class OpretKunde : Page
    {
        private string connectionString = @"Data Source=(LocalDB)\LocalDB;Initial Catalog=BGBank;Persist Security Info=True;User ID=SQLAdmin;Password=Passw0rd";
        public OpretKunde()
        {
            InitializeComponent();
            Aarstal();
        }

        public void Aarstal()
        {
            for (int i = 1930; i <= 2018; i++)
            {
                ComboBoxItem year = new ComboBoxItem();
                year.Content = i;
                Aarstal_comboBox.Items.Add(year);
            }
        }

        private void OpretBruger_button_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection sqlcon = new SqlConnection(connectionString);
            string query = "Select* from Person Where CPR='" + CPR_textBox.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count == 1)
            {
                MessageBox.Show("Bruger eksistere i forvejen!");
            }
            else if(Fornavn_textBox.Text == "" || Efternavn_textBox.Text == "" || Aarstal_comboBox.Text == "" || Adresse_textBox.Text == "" || CPR_textBox.Text == "")
                MessageBox.Show("Udfyld de tomme felter!");
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Add_Data", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@fornavn", Fornavn_textBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@efternavn", Efternavn_textBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@aarstal", Aarstal_comboBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@adresse", Adresse_textBox.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@cpr", CPR_textBox.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Kunden er nu registreret!");
                    sqlCon.Close();
                }
            }

        }
    }
}
