using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MyTeam.xaml
    /// </summary>
    public partial class MyTeam : Window
    {
        public MyTeam()
        {
            InitializeComponent();
        }

        public MyTeam(int tid)
        {
            InitializeComponent();
            fillTeam(tid);
        }
        

        public void fillTeam(int tid)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KentDatabase;Integrated Security=SSPI");
            con.Open();
            //string sql = "SELECT * FROM League WHERE LID=" + tid + ";";
            //SqlCommand command = new SqlCommand(sql, con);
            //SqlDataReader reader = command.ExecuteReader();
            int lid = 2;
            //int lid = (int)reader.GetValue(1);
            //MessageBox.Show("" + reader.GetValue(0));

            League LG = new League(lid, con);
            //reader.Close();

            teamName.Text = LG.getTeam(tid).getTeamName();
            /*
            qbName.Text = LG.getTeam(tid).getPlayer(0).getName();
            rb1Name.Text = LG.getTeam(tid).getPlayer(1).getName();
            rb2Name.Text = LG.getTeam(tid).getPlayer(2).getName();
            wr1Name.Text = LG.getTeam(tid).getPlayer(3).getName();
            wr2Name.Text = LG.getTeam(tid).getPlayer(4).getName();
            teName.Text = LG.getTeam(tid).getPlayer(5).getName();
            flexName.Text = LG.getTeam(tid).getPlayer(6).getName();
            dstName.Text = LG.getTeam(tid).getPlayer(7).getName();
            kName.Text = LG.getTeam(tid).getPlayer(8).getName();
            */
        }
        
        private void but_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
