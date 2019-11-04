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
        MemoryGrid grid;
        Highscore hs;
        
        string PlayerOneInput;
        string PlayerTwoInput;
        string winner;
        int GameCount = 0;

        public TwoPlayerGame(string PlayerOneInput, string PlayerTwoInput)
        {
            this.PlayerOneInput = PlayerOneInput;
            this.PlayerTwoInput = PlayerTwoInput;
            InitializeComponent();
            hs = new Highscore(player1score, player2score);
            
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS, hs, /*ni, */false, this);
            WriteNames();
            
        }

        /// <summary>
        /// Methode die de ingevoerde namen laat zien tijdens het spel.
        /// </summary>
        public void WriteNames()
        {
            UName1Label.Content = PlayerOneInput;
            UName2Label.Content = PlayerTwoInput;
        }

        

        /// <summary>
        /// Methode die relevante gegevens(Gamecount, namen, scores, en winnaar) van een 2 speler spel opslaat in een tekstbestand nadat het spel is afgelopen.
        /// </summary>
        /// <param name="player1score"></param>
        /// <param name="player2score"></param>
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
            tw.WriteLine("Spel " + GameCount + ": " + PlayerOneInput + " " + player1score + " " + PlayerTwoInput + " " + player2score + " " + "Winnaar: " + winner);
            tw.Close();
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
        
        /// <summary>
        /// Methode voor het laten zien wie er aan de beurt is.
        /// </summary>
        /// <param name="CurrentPlayer">Bool die bepaalt/bijhoudt wie er aan de beurt is</param>
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
                
    }
}
