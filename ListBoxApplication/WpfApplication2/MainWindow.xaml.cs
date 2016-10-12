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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string listitems = "";
            for (int i = 0; i < list.Items.Count; i++)
            {
                listitems = list.Items[i].ToString();
                t.Add(listitems);
            }
            string line;
            line = input.Text;
            if (line != null)
            {
                t.Add(line);
                list.ItemsSource = t;
            }
            else
            {
                list.ItemsSource = t;
            }
            input.Text = "";

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Object> t = new ObservableCollection<Object>();
            string line = list.SelectedItem.ToString();
            string listitems = "";
            for (int i = 0; i < list.Items.Count; i++)
            {
                listitems = list.Items[i].ToString();
                if (listitems != line)
                {
                    t.Add(listitems);
                }
            }
            list.ItemsSource = t;

        }
    }
}
