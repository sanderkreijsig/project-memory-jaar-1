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
    class Highscore
    {
        TextBlock HighscoreTextBox = new TextBlock();
        
        public Highscore()
        {
            
        }
        public Highscore(TextBlock tb)
        {
            HighscoreTextBox = tb;
        }

        static int score;
        public static void Score()
        {
           score = MemoryGrid.gamescoreOuput();
        }
        public void ReadHighscore()
        {
            if (!File.Exists("highscores.txt"))
            {
                TextWriter tw = new StreamWriter("highscores.txt");
                tw.Write("300");
                tw.Close();
            }

            TextReader tr = new StreamReader("highscores.txt");

            HighscoreTextBox.Text = tr.ReadLine();
            tr.Close();


        }

       

        public void WriteHighscore()
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
