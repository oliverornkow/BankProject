using System;
using System.Collections.Generic;
using System.Data;
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

namespace MandagsWPF
{
    /// <summary>
    /// Interaction logic for Konto.xaml
    /// </summary>
    public partial class Konto : Window
    {
        public Konto()
        {
            InitializeComponent();
        }

        private void Kundeoversigt_dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KundeOversigt kto = new KundeOversigt();
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                
                textBoxinthewindow.Text = row_selected["CPR"].ToString();
                //textBox.Text = row_selected["CPR"].ToString();

            }
            
        }
        
    }
}
