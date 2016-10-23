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
        int TID = 0;
        League LG;
        public MyTeam()
        {
            InitializeComponent();
        }
        
        public MyTeam(League lg, int tid)
        {
            LG = lg;
            TID = tid;
            InitializeComponent();
            fillTeam();
        }
        
        public void fillTeam()
        {
            teamName.Text = LG.getTeam(TID).getTeamName();
            qb1Name.Text = LG.getTeam(TID).getPlayer(0).getName();
            rb1Name.Text = LG.getTeam(TID).getPlayer(1).getName();
            rb2Name.Text = LG.getTeam(TID).getPlayer(2).getName();
            wr1Name.Text = LG.getTeam(TID).getPlayer(3).getName();
            wr2Name.Text = LG.getTeam(TID).getPlayer(4).getName();
            teName.Text = LG.getTeam(TID).getPlayer(5).getName();
            flexName.Text = LG.getTeam(TID).getPlayer(6).getName();
            dstName.Text = LG.getTeam(TID).getPlayer(7).getName();
            kName.Text = LG.getTeam(TID).getPlayer(8).getName();
        }

        private void draft_Click(object sender, RoutedEventArgs e)
        {
            var page = new Draft(LG);
            page.Show();
            this.Close();
        }

        private void team1_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(0).getTID();
            fillTeam();
        }

        private void team2_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(1).getTID();
            fillTeam();
        }
        private void team3_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(2).getTID();
            fillTeam();
        }

        private void team4_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(3).getTID();
            fillTeam();
        }

        private void team5_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(4).getTID();
            fillTeam();
        }

        private void team6_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(5).getTID();
            fillTeam();
        }

        private void team7_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(6).getTID();
            fillTeam();
        }

        private void team8_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(7).getTID();
            fillTeam();
        }

        private void team9_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(8).getTID();
            fillTeam();
        }

        private void team10_Selected(object sender, RoutedEventArgs e)
        {
            TID = LG.getTeamByIndex(9).getTID();
            fillTeam();
        }
    }
}
