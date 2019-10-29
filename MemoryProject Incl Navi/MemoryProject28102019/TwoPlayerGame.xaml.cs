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

namespace MemoryProject28102019
{
    /// <summary>
    /// Interaction logic for TwoPlayerGame.xaml
    /// </summary>
    public partial class TwoPlayerGame : Page
    {
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        bool OnePlayerGameBool;
        MemoryGrid grid;

        Highscore hs;
        NameInput ni;
        string PlayerOneInput;
        string PlayerTwoInput;

        public TwoPlayerGame()
        {

        }
        public TwoPlayerGame(string PlayerOneInput, string PlayerTwoInput)
        {
            this.PlayerOneInput = PlayerOneInput;
            this.PlayerTwoInput = PlayerTwoInput;
            InitializeComponent();
            hs = new Highscore(/*highscoretb, currentscoretb, */player1score, player2score);
            ni = new NameInput( );
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS, hs, ni, false);
            WriteNames();

        }


        public void WriteNames()
        {
            UName1Label.Content = PlayerOneInput;
            UName2Label.Content = PlayerTwoInput;
        }

        string winner;
        int GameCount = 0;
        public void Save2PGame(int player1score, int player2score)
        {
            GameCount++;
            TextWriter tw = new StreamWriter("GameSaves.txt", true);

            if (player1score > player2score)
            {
                winner = PlayerOneInput;

            }
            if (player1score == player2score)
            {
                winner = "gelijkspel";

            }
            if (player1score < player2score)
            {
                winner = PlayerTwoInput;

            }

            tw.WriteLine("Spel " + GameCount + ": " + PlayerOneInput + " " + player1score + " " + PlayerTwoInput + " " + player2score + " " + "Winner: " + winner);
            tw.Close();
        }


        private void Restart_Click(Object sender, RoutedEventArgs e)
        {

            grid.Restart();

        }

        //private void NameInput_Click(Object sender, RoutedEventArgs e)
        //{
        //    ni.WriteNameInput();

        //}
    }
}
