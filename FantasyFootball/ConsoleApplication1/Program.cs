using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ConsoleApplication1
{
    class Program
    {
        static Team[] teams = new Team[10];

        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            Program.createTeams();
            Program.Draft(con);
        }

        public static void Draft(SqlConnection conn)
        {

            //show player list (first 10)
            conn.Open();
            Program.displayPlayers(conn);


            //round 1
            teams[0].pick(conn,1);
            teams[1].pick(conn,2);
            teams[2].pick(conn,3);
            teams[3].pick(conn,4);
            teams[4].pick(conn,5);
            teams[5].pick(conn,6);
            teams[6].pick(conn,7);
            teams[7].pick(conn,8);
            teams[8].pick(conn,9);
            teams[9].pick(conn,10);


            conn.Close();
            Console.ReadLine();
        }

        public static void displayPlayers(SqlConnection conn)
        {
            SqlCommand command;
            SqlDataReader reader;
            command = new SqlCommand("SELECT * FROM Players", conn);
            reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read() && i < 10)
            {
                Console.WriteLine("{0} {1}", reader.GetValue(0), reader.GetValue(1));
                i++;
            }
            reader.Close();
            command = new SqlCommand("TRUNCATE TABLE Rosters;", conn);
            reader = command.ExecuteReader();
            reader.Close();
        }

        public static void createTeams()
        {
            teams[0] = new Team("Team1");
            teams[1] = new Team("Team2");
            teams[2] = new Team("Team3");
            teams[3] = new Team("Team4");
            teams[4] = new Team("Team5");
            teams[5] = new Team("Team6");
            teams[6] = new Team("Team7");
            teams[7] = new Team("Team8");
            teams[8] = new Team("Team9");
            teams[9] = new Team("Team10");
        }
        
    }
}
