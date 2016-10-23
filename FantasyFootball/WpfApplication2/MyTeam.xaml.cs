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
            qb1Name.Text = LG.getTeam(TID).getQB().getName();
            rb1Name.Text = LG.getTeam(TID).getRB1().getName();
            rb2Name.Text = LG.getTeam(TID).getRB2().getName();
            wr1Name.Text = LG.getTeam(TID).getWR1().getName();
            wr2Name.Text = LG.getTeam(TID).getWR2().getName();
            teName.Text = LG.getTeam(TID).getTE().getName();
            flexName.Text = LG.getTeam(TID).getFLEX().getName();
            dstName.Text = LG.getTeam(TID).getDST().getName();
            kName.Text = LG.getTeam(TID).getK().getName();
            bench1.Text = LG.getTeam(TID).getBench(0).getName();
            bench2.Text = LG.getTeam(TID).getBench(1).getName();
            bench3.Text = LG.getTeam(TID).getBench(2).getName();
            bench4.Text = LG.getTeam(TID).getBench(3).getName();
            bench5.Text = LG.getTeam(TID).getBench(4).getName();
            bench6.Text = LG.getTeam(TID).getBench(5).getName();
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
