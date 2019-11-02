using System;
using System.IO;
using System.Windows.Controls;
using System.Linq;
using System.Collections.Generic;

namespace MemoryProject28102019
{
    public class Highscore
    {
        TextBlock HighscoreTextBox = new TextBlock();
        TextBlock CurrentscoreTextBox = new TextBlock();
        TextBlock Player1TextBox = new TextBlock();
        TextBlock Player2TextBox = new TextBlock();
        string PlayerInputGetrimt;

        public Highscore()
        {

        }

        /// <summary>
        /// Overload constructor met variabelen voor de OnePlayerGame
        /// </summary>
        /// <param name="tb">TextBlock in het spelscherm waar de highscore wordt laten zien</param>
        /// <param name="tb2">TextBock in het spelscherm waar de huidige score wordt laten zien</param>
        /// <param name="PlayerInputGetrimt">De getrimde versie van de naaminvoer van de speler</param>
        public Highscore(TextBlock tb, TextBlock tb2, string PlayerInputGetrimt)
        {
            HighscoreTextBox = tb;
            CurrentscoreTextBox = tb2;
            this.PlayerInputGetrimt = PlayerInputGetrimt;

        }

        /// <summary>
        /// Overload constructor met variabelen voor de TwoPlayerGame
        /// </summary>
        /// <param name="ps1tb">TextBlock waar de naam van player 1 in staat</param>
        /// <param name="ps2tb">TextBlock waar de naam van player 2 in staat</param>        
        public Highscore(TextBlock ps1tb, TextBlock ps2tb)
        {
            Player1TextBox = ps1tb;
            Player2TextBox = ps2tb;
        }

        /// <summary>
        /// Methode die de huidige score in een TextBlock schrijft
        /// </summary>
        /// <param name="score">score die wordt gegenereerd in een andere class</param>
        public void WriteCurrentscore(int score)
        {
            CurrentscoreTextBox.Text = Convert.ToString(score);

        }

        /// <summary>
        /// Methode die de respectievelijke scores laat zien in een game met 2 spelers
        /// </summary>
        /// <param name="player1score">Score van speler 1</param>
        /// <param name="player2score">Score van speler 2</param>
        public void WriteMultiscore(int player1score, int player2score)
        {
            Player1TextBox.Text = Convert.ToString(player1score);
            Player2TextBox.Text = Convert.ToString(player2score);
        }

        /// <summary>
        /// Methode die een highscore.txt aanmaakt als deze nog niet bestaat, 
        /// de huidige scores in het textbestand in een array zet, de namen van de scores splitst, deze score sorteert, en daarna laat zien in het spel scherm.
        /// </summary>
        public void ReadHighscore()
        {
            if (!File.Exists("highscores.txt"))
            {
                TextWriter tw = new StreamWriter("highscores.txt");
                tw.WriteLine("AAA 000");
                tw.WriteLine("AAA 000");
                tw.WriteLine("AAA 000");
                tw.WriteLine("AAA 000");
                tw.WriteLine("AAA 000");
                tw.Close();
            }

            TextReader tr = new StreamReader("highscores.txt");
            List<string> lines = File.ReadLines("highscores.txt").ToList();
            var parsedPersons = from s in lines
                                select new
                                {
                                    Score = int.Parse(s.Split(' ')[1]),
                                    Name = s.Split(' ')[0]
                                };
            var sortedPersons = parsedPersons.OrderByDescending(o => o.Score).ThenBy(i => i.Name);
            var result = (from s in sortedPersons
                          select s.Name + " " + s.Score).ToArray();

            string output = result[0];
            string outputScore = output.Substring(output.IndexOf(' ') + 1);
            HighscoreTextBox.Text = outputScore;
            tr.Close();
        }


        /// <summary>
        /// Methode die nieuwe scores aan highscores.txt toevoegd
        /// </summary>
        /// <param name="score">de behaalde scores</param>
        public void WriteHighscore(int score)
        {
                TextWriter tw = new StreamWriter("highscores.txt", true);
                tw.WriteLine(PlayerInputGetrimt + " " + score);
                tw.Close();
        }
    }
}
