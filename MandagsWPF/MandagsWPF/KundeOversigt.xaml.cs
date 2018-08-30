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
    /// Interaction logic for KundeOversigt.xaml
    /// </summary>
    public partial class KundeOversigt : Page
    {
        public DataView DV { get; set; }
        
        public KundeOversigt()
        {
            InitializeComponent();
            Oversigt();
        }

        //https://parallelcodes.com/wpf-datagrid-bind-sql-database/
        private void Oversigt()
        {
            String connectionString = @"Data Source=(LocalDB)\LocalDB;Initial Catalog=BGBank;Persist Security Info=True;User ID=SQLAdmin;Password=Passw0rd";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select Fornavn, Efternavn, CPR, Oprettelsesdato, Adresse.* from Person inner join Adresse on Person.Adresse = Adresse.ID", con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Kundeoversigt_dataGrid.IsReadOnly = true;
            Kundeoversigt_dataGrid.ItemsSource = dt.DefaultView;
            DV = dt.DefaultView;
            DataContext = this;
            
            cmd.Dispose();
            con.Close();
        }

        private void Kundeoversigt_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if(row_selected != null)
            {
                Konto konto = new Konto();
                konto.textBoxinthewindow.Text = row_selected["CPR"].ToString();
                textBox.Text = row_selected["CPR"].ToString();
                
            }
        }

        private void Kundeoversigt_dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Konto konti = new Konto();
            konti.Show();
        }
    }
}
