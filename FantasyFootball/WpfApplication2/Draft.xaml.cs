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
                    listitems = LG.getTeam(TID).getPlayer(i).getPosition() + " - " + LG.getTeam(TID).getPlayer(i).getName();
                    t.Add(listitems);
                }
            }
            roster.ItemsSource = t;
        }
        
        private void all_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT Name, Position FROM Players WHERE Position='QB' OR Position='RB' OR Position='WR' OR Position='TE' ";
            sql += "OR Position='DST' OR Position='K' AND Name NOT IN (SELECT PlayerName FROM Rosters WHERE LID=" + LG.getLID() + ");";

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

        private void qb_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT Name, Position FROM Players WHERE Position='QB' AND Name NOT IN (SELECT PlayerName FROM Rosters WHERE LID=" + LG.getLID() + ");";
            
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
            string sql = "SELECT Name, Position FROM Players WHERE Position='RB' AND Name NOT IN (SELECT PlayerName FROM Rosters WHERE LID=" + LG.getLID() + ");";
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
            string sql = "SELECT Name, Position FROM Players WHERE Position='WR' AND Name NOT IN (SELECT PlayerName FROM Rosters WHERE LID=" + LG.getLID() + ");";
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
            string sql = "SELECT Name, Position FROM Players WHERE Position='TE' AND Name NOT IN (SELECT PlayerName FROM Rosters WHERE LID=" + LG.getLID() + ");";
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
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT Name, Position FROM Players WHERE Position='RB' OR Position='WR' ";
            sql += "OR Position='TE' AND Name NOT IN (SELECT PlayerName FROM Rosters WHERE LID=" + LG.getLID() + ");";

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

        private void dst_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT Name, Position FROM Players WHERE Position='DST' AND Name NOT IN (SELECT PlayerName FROM Rosters WHERE LID=" + LG.getLID() + ");";

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

        private void k_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT Name, Position FROM Players WHERE Position='K' ORDER BY Name;";
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

        private void draftSelected_Click(object sender, RoutedEventArgs e)
        {
            int pid = 0;
            if (players.SelectedItem == null)
            {
                return;
            }
            string[] pi = players.SelectedItem.ToString().Split(' '); //pos, -, name
            string playerName = pi[2] + " " + pi[3];
            Player p = new Player(playerName, pi[0], LG.getTeam(TID));

            if (LG.getTeam(TID).draftPlayer(p))
            {
                int posIndex = LG.getTeam(TID).setPosition(p);
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

                sql = "INSERT INTO Rosters (LID, TID, FTeamName, PID, PlayerName, Position, PositionIndex) VALUES (";
                sql += LG.getLID() + "," + TID + ",'" + LG.getTeam(TID).getTeamName() + "'," + pid + ",'" + playerName + "','" + pi[0] + "'," + posIndex + ");";
                command = new SqlCommand(sql, con);
                reader = command.ExecuteReader();
                reader.Close();
                TID = LG.getPickTID();
                fillTeam();
                this.all_Click(sender, e);
            }
            else
                MessageBox.Show("Drafted Player Unsuccessful");
        }

    }
}
