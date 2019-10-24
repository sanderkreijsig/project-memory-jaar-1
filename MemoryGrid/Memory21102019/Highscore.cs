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
using System;

namespace Memory21102019
{
    public class Highscore
    {
        TextBlock HighscoreTextBox = new TextBlock();
        TextBlock CurrentscoreTextBox = new TextBlock();



        public Highscore()
        {
            
        }
        public Highscore(TextBlock tb, TextBlock tb2)
        {
            HighscoreTextBox = tb;
            CurrentscoreTextBox = tb2;
        }

        public void WriteCurrentscore(int score)
        {
            CurrentscoreTextBox.Text = Convert.ToString(score);
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
