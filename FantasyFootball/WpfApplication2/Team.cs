using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfApplication2
{
    class Team
    {
        string leagueName, teamName;
        int LID, TID;
        Player QB, RB1, RB2, WR1, WR2, TE, FLEX, DST, K;
        Player[] bench = new Player[6];
        Player[] roster = new Player[15];

        public Team(string Name)
        {
            teamName = Name;
        }

        public Team(string Name, int tid, int lid, SqlConnection con)
        {
            teamName = Name;
            TID = tid;
            LID = lid;
            string[] names = new string[10];
            string[] positions = new string[10];
            string sql = "SELECT PlayerName, Position FROM Rosters WHERE TID=" + tid + ";";
            SqlCommand command2 = new SqlCommand(sql, con);
            SqlDataReader reader2 = command2.ExecuteReader();
            int i = 0;
            while (reader2.Read() && i < 10)
            {
                names[i] = (string)reader2.GetValue(0);
                positions[i] = (string)reader2.GetValue(1);
                i++;
            }
            reader2.Close();
            for (i = 0; i < 10; i++)
            {
                roster[i] = new Player(names[i],positions[i]);
            }
        }

        public void pick(SqlConnection conn, int teamID)
        {

        }
        public void draftPlayer(Player pick)
        {
        }

        public int getTID()
        {
            return this.TID;
        }

        public string getTeamName()
        {
            return this.teamName;
        }

        public Player getPlayer(int index)
        {
            if (roster[index] == null)
            {
                return new Player("empty", "RB");
            }
            return roster[index];
        }
    }
}
