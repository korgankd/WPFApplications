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
        string teamName;
        int LID, TID;
        Player QB, RB1, RB2, WR1, WR2, TE, FLEX, DST, K;
        Player[] bench = new Player[10];
        Player[] roster = new Player[15];
        League LG;

        public Team(string Name)
        {
            teamName = Name;
        }

        public Team(string Name, int tid, League league, SqlConnection con)
        {
            int[] positionIndex = new int[15];
            teamName = Name;
            TID = tid;
            LG = league;
            LID = LG.getLID();
            string[] names = new string[15];
            string[] positions = new string[15];
            string sql = "SELECT PlayerName, Position, PositionIndex FROM Rosters WHERE TID=" + tid + ";";
            SqlCommand command2 = new SqlCommand(sql, con);
            SqlDataReader reader2 = command2.ExecuteReader();
            int i = 0;
            while (reader2.Read() && i < 15)
            {
                names[i] = (string)reader2.GetValue(0);
                positions[i] = (string)reader2.GetValue(1);
                positionIndex[i] = (int)reader2.GetValue(2);
                i++;
            }
            reader2.Close();
            for (i = 0; i < 10; i++)
            {
                roster[i] = new Player(names[i],positions[i], this);
                setPosition(roster[i], positionIndex[i]);
            }
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
                    LG.playerDrafted();
                    return true;
                }
            }
            return false;
        }

        //setting position when drafting, needs to check what position slots are available in order to WRITE to db
        public int setPosition(Player p)
        {
            int pos = 0;
            switch (p.getPosition())
            {
                case "QB":
                    if (QB == null)
                    {
                        QB = p;
                        pos = 1;
                    }
                    break;
                case "RB":
                    if (RB1 == null)
                    {
                        RB1 = p;
                        pos = 2;
                    }
                    else if (RB2 == null)
                    {
                        RB2 = p;
                        pos = 3;
                    }
                    else if (FLEX == null)
                    {
                        FLEX = p;
                        pos = 7;
                        break;
                    }
                    break;
                case "WR":
                    if (WR1 == null)
                    {
                        WR1 = p;
                        pos = 4;
                    }
                    else if (WR2 == null)
                    {
                        WR2 = p;
                        pos = 5;
                    }
                    else if (FLEX == null)
                    {
                        FLEX = p;
                        pos = 7;
                    }
                    break;
                case "TE":
                    if (TE == null)
                    {
                        TE = p;
                        pos = 6;
                    }
                    else if (FLEX == null)
                    {
                        FLEX = p;
                        pos = 7;
                    }
                    break;
                case "DST":
                    if (DST == null)
                    {
                        DST = p;
                        pos = 8;
                    }
                    break;
                case "K":
                    if (K == null)
                    {
                        K = p;
                        pos = 9;
                    }
                    break;
            }
            if (pos == 0)
            {
                for(int i = 0; i < 10; i++)
                {
                    if (bench[i] == null)
                        bench[i] = p;
                }
            }
            return pos;
        }

        //setting position when instantiating? needs to get position slot after READ from db
        public void setPosition(Player p, int pi)
        {
            switch(pi)
            {
                case 0:
                    for (int i = 0; i < 10; i++)
                    {
                        if (bench[i] == null)
                        {
                            bench[i] = p;
                            return;
                        }
                    }
                    break;
                case 1:
                    QB = p;
                    break;
                case 2:
                    RB1 = p;
                    break;
                case 3:
                    RB2 = p;
                    break;
                case 4:
                    WR1 = p;
                    break;
                case 5:
                    WR2 = p;
                    break;
                case 6:
                    TE = p;
                    break;
                case 7:
                    FLEX = p;
                    break;
                case 8:
                    DST = p;
                    break;
                case 9:
                    K = p;
                    break;
            }
        }

        public Player getQB()
        {
            if (QB == null)
                return new Player("Empty", "QB", this);
            return QB;
        }

        public Player getRB1()
        {
            if (RB1 == null)
                return new Player("Empty", "RB", this);
            return RB1;
        }

        public Player getRB2()
        {
            if (RB2 == null)
                return new Player("Empty", "RB", this);
            return RB2;
        }
    
        public Player getWR1()
        {
            if (WR1 == null)
                return new Player("Empty", "WR", this);
            return WR1;
        }

        public Player getWR2()
        {
            if (WR2 == null)
                return new Player("Empty", "WR", this);
            return WR2;
        }

        public Player getTE()
        {
            if (TE == null)
                return new Player("Empty", "TE", this);
            return TE;
        }

        public Player getFLEX()
        {
            if (FLEX == null)
                return new Player("Empty", "RB", this);
            return FLEX;
        }

        public Player getDST()
        {
            if (DST == null)
                return new Player("Empty", "DST", this);
            return DST;
        }

        public Player getK()
        {
            if (K == null)
                return new Player("Empty", "K", this);
            return K;
        }

        public Player getBench(int i)
        {
            if (bench[i] == null)
                return new Player("Empty", "RB", this);
            return bench[i];
        }
    }
}
