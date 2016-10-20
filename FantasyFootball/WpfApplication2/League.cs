using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfApplication2
{
    public class League
    {
        int pickNum;
        int[] draftOrder;
        string leagueName;
        int leagueID;
        Team[] teams = new Team[10];

        public League(int LID, SqlConnection con)
        {
            leagueID = LID;
            string[] teamNames = new string[10];
            int[] tids = new int[10];
            string sql = "SELECT TeamName, TID FROM League WHERE LID=" + leagueID + ";";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read() && i < 10)
            {
                teamNames[i] = (string)reader.GetValue(0);
                tids[i] = (int)reader.GetValue(1);
                i++;
            }
            draftOrder = setDraftOrder(tids[0]);
            reader.Close();
            for (i = 0; i < 10; i++)
            {
                teams[i] = new Team(teamNames[i], tids[i], this, con);
            }

            sql = "SELECT COUNT(*) FROM Rosters;";
            command = new SqlCommand(sql, con);
            pickNum = (int)command.ExecuteScalar();
        }

        public Team getTeam(int tid)
        {
            for (int i = 0; i < 10; i++)
            {
                if (teams[i].getTID() == tid)
                {
                    return teams[i];
                }
            }
            return new Team("No Team");
        }

        public int getLID()
        {
            return leagueID;
        }

        public int[] setDraftOrder(int firstTID)
        {
            Boolean snake = false;  //true when snake drafting in decending order
            int j = firstTID;
            int[] pick = new int[150];
            for (int i = 0; i < 150; i++)
            {
                pick[i] = j;
                if (snake)
                {
                    j--;
                }
                else
                {
                    j++;
                }
                if (j == firstTID + 10)
                {
                    j--;
                    snake = true;
                }
                else if (j == firstTID - 1)
                {
                    j++;
                    snake = false;
                }
            }
            return pick;
        }

        public int getPickNum()
        {
            return pickNum;
        }

        public int getPickTID()
        {
            return draftOrder[pickNum];
        }

        public void playerDrafted()
        {
            pickNum++;
        }
    }
}
