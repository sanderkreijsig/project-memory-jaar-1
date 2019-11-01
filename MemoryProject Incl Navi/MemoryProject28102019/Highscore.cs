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

        public Highscore(TextBlock tb, TextBlock tb2, string PlayerInputGetrimt)
        {
            HighscoreTextBox = tb;
            CurrentscoreTextBox = tb2;
            this.PlayerInputGetrimt = PlayerInputGetrimt;

        }
        public Highscore(/*TextBlock tb, TextBlock tb2, */TextBlock ps1tb, TextBlock ps2tb)
        {
            //HighscoreTextBox = tb;
            //CurrentscoreTextBox = tb2;
            Player1TextBox = ps1tb;
            Player2TextBox = ps2tb;
        }

        public void WriteCurrentscore(int score)
        {
            CurrentscoreTextBox.Text = Convert.ToString(score);

        }

        public void WriteMultiscore(int player1score, int player2score)
        {
            Player1TextBox.Text = Convert.ToString(player1score);
            Player2TextBox.Text = Convert.ToString(player2score);
        }



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



        public void WriteHighscore(int score)
        {
            if (score >= Convert.ToInt32(HighscoreTextBox.Text))
            {
                TextWriter tw = new StreamWriter("highscores.txt", true);
                tw.WriteLine(PlayerInputGetrimt + " " + score);
                tw.Close();
            }
        }
    }
}
