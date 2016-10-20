using System;
using System.Windows;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Draft.xaml
    /// </summary>
    public partial class Draft : Window
    {
        League LG;
        int TID;
        public Draft()
        {
            InitializeComponent();
        }

        public Draft(League lg)
        {
            InitializeComponent();
            LG = lg;
            TID = lg.getPickTID();
            fillTeam();
        }

        public void fillTeam()
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            teamName.Text = LG.getTeam(TID).getTeamName();
            for (int i = 0; i < 15; i++)
            {
                if (LG.getTeam(TID).getPlayer(i).getName() != "Empty")
                {
                    listitems = LG.getTeam(TID).getPlayer(i).getName();
                    t.Add(listitems);
                }
            }
            roster.ItemsSource = t;
        }
        
        private void qb_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT Name, Position FROM Players WHERE Position='QB' ORDER BY Name;";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listitems = reader.GetValue(1) + " - " + reader.GetValue(0);
                t.Add(listitems);
            }
            reader.Close();
            players.ItemsSource = t;
        }

        private void rb_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT Name, Position FROM Players WHERE Position='RB' ORDER BY Name;";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listitems = reader.GetValue(1) + " - " + reader.GetValue(0);
                t.Add(listitems);
            }
            reader.Close();
            players.ItemsSource = t;

        }

        private void wr_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT Name, Position FROM Players WHERE Position='WR' ORDER BY Name;";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listitems = reader.GetValue(1) + " - " + reader.GetValue(0);
                t.Add(listitems);
            }
            reader.Close();
            players.ItemsSource = t;

        }

        private void te_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT Name, Position FROM Players WHERE Position='TE' ORDER BY Name;";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listitems = reader.GetValue(1) + " - " + reader.GetValue(0);
                t.Add(listitems);
            }
            reader.Close();
            players.ItemsSource = t;

        }

        private void flex_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dst_Click(object sender, RoutedEventArgs e)
        {

        }

        private void k_Click(object sender, RoutedEventArgs e)
        {

        }

        private void draftSelected_Click(object sender, RoutedEventArgs e)
        {
            int pid = 0;
            string[] pi = players.SelectedItem.ToString().Split(' '); //pos, -, name
            Player p = new Player(pi[0], pi[2], LG.getTeam(TID));

            if (LG.getTeam(TID).draftPlayer(p))
            {
                //players.Items.Remove(players.SelectedItem);
                string playerName = pi[2] + " " + pi[3];
                //sql
                SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
                con.Open();
                string sql = "SELECT PID FROM Players WHERE Name='" + playerName + "';";
                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    pid = (int)reader.GetValue(0);
                }
                reader.Close();

                sql = "INSERT INTO Rosters (TID, FTeamName, PID, PlayerName, Position) VALUES (";
                sql += TID + ",'" + LG.getTeam(TID).getTeamName() + "'," + pid + ",'" + playerName + "','" + pi[0] + "');";
                command = new SqlCommand(sql, con);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Drafted Player Successful");
                }
                reader.Close();
            }
            else
                MessageBox.Show("Drafted Player Unsuccessful");
        }
    }
}
