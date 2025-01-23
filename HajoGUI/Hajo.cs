using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HajoGUI
{
    internal class Hajo
    {
        public string Nev { get; set; }
        public string Tipus { get; set; }
        public int Ev { get; set; }
        public Hajo(MySqlDataReader reader)
        {
            Nev = reader.GetString(0);
            Tipus = reader.GetString(1);
            Ev = reader.GetInt32(2);
        }
    }
}
