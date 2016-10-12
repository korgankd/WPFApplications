using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfApplication2
{
    class League
    {
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
            reader.Close();
            for (i = 0; i < 10; i++)
            {
                teams[i] = new Team(teamNames[i], tids[i], LID, con);
            }
        }

        public Team getTeam(int tid)
        {
            for(int i = 0; i < 10; i++)
            {
                if (teams[i].getTID() == tid)
                {
                    return teams[i];
                }
            }
            return new Team("No Team");
        }
    }
}
