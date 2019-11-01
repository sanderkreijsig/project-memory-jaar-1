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

namespace MemoryProject28102019
{
    /// <summary>
    /// Interaction logic for OnePlayerInput.xaml
    /// </summary>
    public partial class OnePlayerInput : Page
    {
        
        public OnePlayerInput()
        {
            InitializeComponent();
        }

        private void StartOnePlayerBTN_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(PlayerInput.Text)))
            {
                MessageBox.Show("U bent vergeten een naam in te vullen!");
            }
            else
            {
            OnePlayerGame onePlayerGame = new OnePlayerGame(PlayerInput.Text);
            this.NavigationService.Navigate(onePlayerGame);
            }
            
        }

        private void PlayerInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
