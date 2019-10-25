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

namespace Memory21102019
{
    /// <summary>
    /// Interaction logic for playername.xaml
    /// </summary>
    public partial class playername : Page
    {
        public playername()
        {
            InitializeComponent();
        }



      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Playernameref.Content = new Home();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Playernameref.Content = new MainWindow();
        }
    }
}
