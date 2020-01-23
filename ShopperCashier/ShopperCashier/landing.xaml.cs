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
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace ShopperCashier
{

    /// <summary>
    /// Interaction logic for landing.xaml
    /// </summary>
    public partial class landing : Window
    {
       
        public landing()
        {
            Configuration configuration;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            InitializeComponent();
            

        }

        void FillDataGridView()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            DynamicParameters param = new DynamicParameters();
            List<Employee> list = con.QueryAsync<Employee>("exec SP_Employee", param, commandType: CommandType.Store).Result.SingleOrDefault();
        }

        private void BTN_Insert(object sender, RoutedEventArgs e)
        {
            Insert ins = new Insert();
            ins.Show();
        }

        private void BTN_Del(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            var check = con.QueryAsync<Employee>("exec SP_Delete @name", new
            {
                name = TB_Del.Text,
            }).Result.SingleOrDefault();
        }
    }
}
