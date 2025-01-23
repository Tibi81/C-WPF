using MySql.Data.MySqlClient;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HajoGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Hajo> adatok = new List<Hajo>();
        private readonly string connects = "Server=localhost; Database=hajok1;Uid=root;password='';";
        private readonly MySqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            conn = new MySqlConnection(connects);
            conn.Open();
            string lekerdezes1 = "SELECT nev, tipus, ev FROM hajo;";
            MySqlCommand cmd = new MySqlCommand(lekerdezes1, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Hajo x = new Hajo(dr);
                adatok.Add(x);
            }
            dr.Close();
            Dtg1.ItemsSource = adatok;  
        }
       

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            int index = Dtg1.SelectedIndex + 1;
            string lekerdezes2 = $"SELECT tulajdonos.tnev FROM hajo, tulajdonos WHERE hajo.tid = tulajdonos.id AND hajo.id = {index};";
            MySqlCommand cmd = new MySqlCommand(lekerdezes2, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txt1.Text = dr.GetString(0);
            dr.Close();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            string lekerdezes2 = "SELECT COUNT(*) FROM hajo WHERE uzemel = 1;";
            MySqlCommand cmd = new MySqlCommand(lekerdezes2, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txt2.Text = dr.GetInt32(0).ToString();
            dr.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Dtg1.SelectedIndex + 1;
            string lekerdezes2 = $"SELECT tipus FROM hajo, tulajdonos WHERE hajo.tid = tulajdonos.id AND hajo.id = {index};";
            MySqlCommand cmd = new MySqlCommand(lekerdezes2, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lbl1.Content = dr.GetString(0);
            dr.Close();
        }
    }
}