using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfApplication2
{
    public class Team
    {
        string leagueName, teamName;
        int LID, TID;
        Player QB, RB1, RB2, WR1, WR2, TE, FLEX, DST, K;
        Player[] bench = new Player[6];
        Player[] roster = new Player[15];
        League lg;

        public Team(string Name)
        {
            teamName = Name;
        }

        public Team(string Name, int tid, League league, SqlConnection con)
        {
            teamName = Name;
            TID = tid;
            lg = league;
            LID = lg.getLID();
            string[] names = new string[15];
            string[] positions = new string[15];
            string sql = "SELECT PlayerName, Position FROM Rosters WHERE TID=" + tid + ";";
            SqlCommand command2 = new SqlCommand(sql, con);
            SqlDataReader reader2 = command2.ExecuteReader();
            int i = 0;
            while (reader2.Read() && i < 15)
            {
                names[i] = (string)reader2.GetValue(0);
                positions[i] = (string)reader2.GetValue(1);
                i++;
            }
            reader2.Close();
            for (i = 0; i < 10; i++)
            {
                roster[i] = new Player(names[i],positions[i], this);
            }
        }

        public void pick(Player pick)
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
                return new Player("Empty", "RB", this);
            }
            return roster[index];
        }
        
        public Boolean draftPlayer(Player p)
        {
            for (int i = 0; i < 15; i++)
            {
                if (roster[i].getName() == "Empty")
                {
                    roster[i] = p;
                    return true;
                }
            }
            return false;
        }
    }
}
