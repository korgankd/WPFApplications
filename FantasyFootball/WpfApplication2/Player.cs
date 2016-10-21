using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfApplication2
{
    public class Player
    {
        string _name;
        string _position;
        Team tm;

        public Player()
        {

        }
        public Player(string Name, string Position, Team team)
        {
            _name = Name;
            _position = Position;
            tm = team;
        }
        public string getName()
        {
            if (_name == null)
            {
                return "Empty";
            }
            return _name;
        }

        public string getPosition()
        {
            if (_position == null)
            {
                return "Empty";
            }
            return _position;
        }
    }
}
