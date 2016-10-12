using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfApplication2
{
    class Player
    {
        string _name;
        string _position;

        public Player()
        {

        }
        public Player(string Name, string Position)
        {
            _name = Name;
            _position = Position;
        }
        public string getName()
        {
            if (_name == null)
            {
                return "empty";
            }
            return _name;
        }
    }
}
