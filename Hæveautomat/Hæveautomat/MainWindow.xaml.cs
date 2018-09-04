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

namespace Hæveautomat
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
            string Password = KontoNR_PasswordBox.Password;

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("CPR_Nummer", CPR_Textbox.Text));
            sqlParams.Add(new SqlParameter("Konto_Nummer", Password));

            DataTable dtLoginResults = DAL.ExecSP("ValidateCPR", sqlParams);

            if (dtLoginResults.Rows.Count == 1)
            {
                HævEllerIndest win2 = new HævEllerIndest();
                win2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Dit CPR Nummer eller Konto Nummer er forkert.");
            }
        }
    }
}
