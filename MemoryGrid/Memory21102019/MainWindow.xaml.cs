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
using System.IO;

namespace Memory21102019
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        MemoryGrid grid;

        Highscore hs;
        NameInput ni;

        

        public MainWindow()
        {
            InitializeComponent();
            hs = new Highscore(highscoretb, currentscoretb, player1score, player2score);
            ni = new NameInput(UName1Input, UName2Input, UName1Label, UName2Label);
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS, hs);        
            
        }
                    
                  
        private void Restart_Click(Object sender, RoutedEventArgs e)
        {
            
            grid.Restart();
            
        }

        private void NameInput_Click(Object sender, RoutedEventArgs e)
        {

            ni.WriteNameInput();
        }
    }
}
