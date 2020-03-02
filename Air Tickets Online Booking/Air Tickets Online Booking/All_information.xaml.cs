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
using System.Data;
using System.Data.SqlClient;

namespace Air_Tickets_Online_Booking
{
    /// <summary>
    /// Interaction logic for All_information.xaml
    /// </summary>
    public partial class All_information : Window
    {
        public All_information()
        {
            InitializeComponent();
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            string connectionstring = @"Data Source=DESKTOP-4R6RO9I;Initial Catalog=Regent;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            sqlcon.Open();
            string commandstring = "select * from customer_details where mobile_num='" + mobile_number.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(commandstring, sqlcon);
            SqlDataReader read = sqlcmd.ExecuteReader();


            while (read.Read())
            {
                txt_block.Text = "Fromm:" + read[0] + "\ntoo:" + read[1] + "\ndeparting_on:" + read[2] + "\nticket_num:" + read[3] + "\ncustomer_name:" + read[4] + "\nmobile_num:" + read[5];
            }
         
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {

            string connectionstring = @"Data Source=DESKTOP-4R6RO9I;Initial Catalog=Regent;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("delete from customer_details where(mobile_num='" + mobile_number.Text + "')", sqlcon);


            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("DELETE SUCCESSFULLY.....");
            sqlcon.Close();
        }

        private void update_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do u really want to update?", "Update Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            string connectionstring = @"Data Source=DESKTOP-4R6RO9I;Initial Catalog=Regent;Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(connectionstring);

            SqlCommand cmd = new SqlCommand("update customer_details set Fromm='" + from.Text + "',too='" + to.Text + "', departing_on ='" + departing_on.Text + "',ticket_num = '" + num_ticket.Text + "',customer_name= '" + customer_name.Text + "' where (mobile_num='" + mobile_number.Text + "')", sqlcon);


            sqlcon.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)

                MessageBox.Show("Save");
            sqlcon.Close();
        }

        private void refresh_click(object sender, RoutedEventArgs e)
        {
            mobile_number.Text = "";
            from.SelectedIndex = 0;
            to.SelectedIndex = 0;
            departing_on.SelectedIndex = 0;
            num_ticket.Clear();
            customer_name.Clear();
            mobile_number.Clear();
            
        }

        private void home_click(object sender, RoutedEventArgs e)
        {
            MainWindow EF = new MainWindow();
            EF.Show();
            this.Close();
        }
    }
}
