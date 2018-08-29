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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string Password = Password_Textbox.Password;

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("Brugernavn", Brugernavn_Textbox.Text));
            sqlParams.Add(new SqlParameter("Password", Password));
            sqlParams.Add(new SqlParameter("Bruger_Type", BrugerType_Combobox.SelectionBoxItem.ToString()));

            DataTable dtLoginResults = DAL.ExecSP("ValidateLogin", sqlParams);

            if (dtLoginResults.Rows.Count == 1)
            {
                if (BrugerType_Combobox.SelectionBoxItem.ToString() == "Admin")
                {
                    AdminWindow win2 = new AdminWindow();
                    win2.Show();
                    this.Close();
                }
                else if (BrugerType_Combobox.SelectionBoxItem.ToString() == "Kunde")
                {
                    KundeWindow win2 = new KundeWindow();
                    win2.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Dit brugernavn eller password er forkert");
            }
        }
    }
}
