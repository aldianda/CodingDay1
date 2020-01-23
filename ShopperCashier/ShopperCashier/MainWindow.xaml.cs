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
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace ShopperCashier
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

        private void BTN_Login_Click(object sender, RoutedEventArgs e)
        {
            Configuration configuration;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            var check = con.QueryAsync<Login>("exec SP_Retrieve_Login @Username, @Password",
                    new { Username = TB_Email.Text, Password = TB_Password.Password }).Result.SingleOrDefault();
            String uname = check.username;
            String password = check.password;

            if (uname == TB_Email.Text)
            {
                if(password == TB_Password.Password)
                {
                    landing land = new landing();
                    land.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password Salah!");
                }
            }
            else
            {
                MessageBox.Show("Username salah!");
            }
        }
    }
}
