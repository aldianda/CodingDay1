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
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace ShopperCashier
{
    /// <summary>
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        public Insert()
        {
            InitializeComponent();
        }
        private void BTN_Add_Action(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            var check = con.QueryAsync<Employee>("exec SP_InsertData @name, @address, @email, @placebirth, @phone, @status", new
            {
                name = TB_Name.Text,
                address = TB_Address.Text,
                email = TB_Email.Text,
                placebirth = TB_Birth.Text,
                phone = TB_Phone.Text,
                status = TB_Status.Text
            }).Result.SingleOrDefault();
            MessageBox.Show("Berhasil Input");
        }
    }
   
}
