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
using System.Data;

namespace Air_Tickets_Online_Booking
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=DESKTOP-4R6RO9I;Initial Catalog=Airline;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            sqlcon.Open();
            string commandstring = "select * from login";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            SqlDataReader read = sqlcmd.ExecuteReader();
            
            while (read.Read())
            {
                if (txt_name.Text == read[0].ToString() && password.Password == read[1].ToString())
                {
                    MessageBox.Show("Welcome to Admin Panel");
                    All_information mw = new All_information();
                    mw.Show();
                    this.Close();
                }


            }
        }

        private void home_click(object sender, RoutedEventArgs e)
        {
            MainWindow EF = new MainWindow();
            EF.Show();
            this.Close();
        }
    }
}

