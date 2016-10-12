using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Team
    {
        string teamName;
        Player[] roster = new Player[15];
        Player[] starters = new Player[9];
        Player[] bench = new Player[6];

        public Team(string Name)
        {
            teamName = Name;
        }

        public void pick(SqlConnection conn, int teamID)
        {
            string playerID;
            string playerName;
            string playerPosition;
            Player pick;
            SqlCommand command;
            SqlDataReader reader;

            Console.WriteLine("Team 1 Select Player by Player ID");
            playerID = Console.ReadLine();
            command = new SqlCommand("SELECT * FROM Players WHERE PID=" + playerID, conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                playerName = (string)reader.GetValue(1);
                playerPosition = (string)reader.GetValue(3);
                reader.Close();

                pick = new Player(playerName, playerPosition);
                string com = "INSERT INTO Rosters (TID, FTeamName, PID, PlayerName, Position) VALUES ("+teamID+",'"+this.teamName+"'," + playerID + ",'" + playerName + "','" + playerPosition + "');";
                command = new SqlCommand(com, conn);
                reader = command.ExecuteReader();
                Console.WriteLine("Team {0} selects {1} {2}", this.teamName, playerName, playerPosition);
                draftPlayer(pick);
            }
            reader.Close();
        }
        public void draftPlayer(Player pick)
        {
            for(int i = 0; i < 15; i++)
            {
                if(roster[i] == null)
                {
                    roster[i] = pick;
                    i = 16;
                    Console.WriteLine(teamName + " drafted " + pick.getName());
                }
            }
        }
    }
}
