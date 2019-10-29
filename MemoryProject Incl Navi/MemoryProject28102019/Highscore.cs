using System;
using System.IO;
using System.Windows.Controls;

namespace MemoryProject28102019
{
    public class Highscore
    {
        TextBlock HighscoreTextBox = new TextBlock();
        TextBlock CurrentscoreTextBox = new TextBlock();
        TextBlock Player1TextBox = new TextBlock();
        TextBlock Player2TextBox = new TextBlock();



        public Highscore()
        {

        }

        public Highscore(TextBlock tb, TextBlock tb2)
        {
            HighscoreTextBox = tb;
            CurrentscoreTextBox = tb2;

        }
        public Highscore(TextBlock tb, TextBlock tb2, TextBlock ps1tb, TextBlock ps2tb)
        {
            HighscoreTextBox = tb;
            CurrentscoreTextBox = tb2;
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
                tw.Write("0");
                tw.Close();
            }

            TextReader tr = new StreamReader("highscores.txt");

            HighscoreTextBox.Text = tr.ReadLine();
            tr.Close();


        }



        public void WriteHighscore(int score)
        {
            if (score >= Convert.ToInt32(HighscoreTextBox.Text))
            {
                TextWriter tw = new StreamWriter("highscores.txt");
                tw.WriteLine(score);
                tw.Close();

            }
        }
    }
}
