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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for CreateLeague.xaml
    /// </summary>
    public partial class CreateLeague : Window
    {
        public CreateLeague()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            int LID = nextLID();
            int TID = nextTID();
            string leagueName = "league" + LID;
            string rosterName = "L" + LID + "_Roster";
            string[] teamName = new string[10];
            teamName[0] = team1.Text;
            teamName[1] = team2.Text;
            teamName[2] = team3.Text;
            teamName[3] = team4.Text;
            teamName[4] = team5.Text;
            teamName[5] = team6.Text;
            teamName[6] = team7.Text;
            teamName[7] = team8.Text;
            teamName[8] = team9.Text;
            teamName[9] = team10.Text;

            if (league.Text != null)
                leagueName = league.Text;

            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "INSERT INTO League (LID, LeagueName, TID, TeamName, UserName) VALUES (" +LID+",'"+league.Text+"',"+TID+",'"+teamName[0]+"','"+userName.Text+"');";
            TID++;
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            for (int i = 1; i < 10; i++)
            {
                sql = "INSERT INTO League (LID, LeagueName, TID, TeamName) VALUES ("+LID+",'"+league.Text+"',"+TID+",'"+teamName[i]+"');";
                command = new SqlCommand(sql, con);
                reader = command.ExecuteReader();
                reader.Close();
                TID++;
            }
            sql = "CREATE TABLE "+rosterName+"(TID int, FTeamName nvarchar(50), PID int, PlayerName nvarchar(50), Position nvarchar(50));";
            command = new SqlCommand(sql, con);
            reader = command.ExecuteReader();
            reader.Close();
            con.Close();

            MessageBox.Show("League table entry added, LID_Roster table created.");

            var page = new MyTeam(TID-9);
            page.Show();
            this.Close();
        }

        public int nextLID()
        {
            int nextLID = 1;
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT MAX(LID) FROM League;";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                nextLID = (int)reader.GetValue(0);
                nextLID++;
            }
            reader.Close();
            con.Close();
            return nextLID;
        }
        public int nextTID()
        {
            int nextTID = 1;
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            string sql = "SELECT MAX(TID) FROM League;";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                nextTID = (int)reader.GetValue(0);
                nextTID++;
            }
            reader.Close();
            con.Close();
            return nextTID;
        }
    }
}
