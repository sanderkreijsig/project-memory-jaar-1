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
        //bool OnePlayerGameBool;
        MemoryGrid grid;

        Highscore hs;
        NameInput ni;
        string PlayerOneInput;
        string PlayerTwoInput;


        public TwoPlayerGame()
        {
            InitializeComponent();
        }
        public TwoPlayerGame(string PlayerOneInput, string PlayerTwoInput)
        {
            this.PlayerOneInput = PlayerOneInput;
            this.PlayerTwoInput = PlayerTwoInput;
            InitializeComponent();
            hs = new Highscore(/*highscoretb, currentscoretb, */player1score, player2score);
            ni = new NameInput( );
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS, hs, ni, false, this);
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

            MessageBox.Show(winner + " heeft gewonnen!");
            tw.WriteLine("Spel " + GameCount + ": " + PlayerOneInput + " " + player1score + " " + PlayerTwoInput + " " + player2score + " " + "Winner: " + winner);
            tw.Close();
        }


        private void Restart_Click(Object sender, RoutedEventArgs e)
        {

            grid.Restart();

        }
        
        public void WriteTurnDisplay(bool CurrentPlayer)
        {
            

            if (CurrentPlayer == true)
            {
                TurnDisplayLabel.Content = PlayerOneInput;
            }
            if (CurrentPlayer == false)
            {
                TurnDisplayLabel.Content = PlayerTwoInput;
            }
        }

        /// <summary>
        /// stelt de progressbar gelijk aan de score
        /// </summary>
        /// <param name="player1score">Dit is de score van player 1 en dit wordt gegenereerd in de memory grid</param>
        /// <param name="player2score">Dit is de score van player 2 en dit wordt gegenereerd in de memory grid</param>
        public void Visualscoredisplay(int player1score, int player2score)
        {
            progressp1.Value = player1score;
            progressp2.Value = player2score;
        }



        //private void NameInput_Click(Object sender, RoutedEventArgs e)
        //{
        //    ni.WriteNameInput();

        //}
    }
}
