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
    /// Interaction logic for OnePlayerGame.xaml
    /// </summary>
    public partial class OnePlayerGame : Page
    {
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        string PlayerInput;
        string PlayerInputGetrimt;

        MemoryGrid grid;
        Highscore hs;
                
        
        public OnePlayerGame(string PlayerInput)
        {
            PlayerInputGetrimt = PlayerInput.Replace(" ", string.Empty);
            this.PlayerInput = PlayerInputGetrimt;
            
            InitializeComponent();

            hs = new Highscore(highscoretb, currentscoretb, PlayerInputGetrimt);
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS, hs, /*ni, */true);
                                    
            PlayerNameInput();
        }

        /// <summary>
        /// Methode die de ingevoerde naam laat zien tijdens het spel.
        /// </summary>
        private void PlayerNameInput()
        {
            UName3Label.Content = PlayerInput;
        }


        /// <summary>
        /// Click event die de restartmethode oproept.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Restart_Click(Object sender, RoutedEventArgs e)
        {

            grid.Restart();

        }
        
    }
}

