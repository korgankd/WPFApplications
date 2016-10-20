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
using System.Collections.ObjectModel;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        League LG;
        int TID = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            int lid = 0;
            string userName = input1.Text;
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT TID,LID FROM League WHERE UserName='" + userName +"';";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                TID = (int)reader.GetValue(0);
                lid = (int)reader.GetValue(1);
            }
            reader.Close();

            LG = new League(lid, con);
            con.Close();
            
            var page = new MyTeam(LG, TID);
            page.Show();
            this.Close();
        }

        private void createLeague_Click(object sender, RoutedEventArgs e)
        {
            var page = new CreateLeague();
            page.Show();
            this.Close();
        }

        private void clearLeagueTable_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "TRUNCATE TABLE League;";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            con.Close();
        }
    }
}
