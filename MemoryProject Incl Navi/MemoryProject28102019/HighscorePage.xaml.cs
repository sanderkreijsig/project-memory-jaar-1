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
    /// Interaction logic for HighscorePage.xaml
    /// </summary>
    public partial class HighscorePage : Page
    {
        public HighscorePage()
        {
            InitializeComponent();
            SortHigscoreList();
            //ReadHighscore();

        }

        private void SortHigscoreList()
        {
            //if (!File.Exists("highscores.txt"))
            //{
            //    TextWriter tw = new StreamWriter("highscores.txt");
            //    tw.WriteLine("AAA 000");
            //    tw.WriteLine("AAA 000");
            //    tw.WriteLine("AAA 000");
            //    tw.WriteLine("AAA 000");
            //    tw.WriteLine("AAA 000");
            //    tw.Close();
            //}

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
            
                HighscoreScore0.Text = "1." + " " + result[0];
                HighscoreScore1.Text = "2." + " " + result[1];
                HighscoreScore2.Text = "3." + " " + result[2];
                HighscoreScore3.Text = "4." + " " + result[3];
                HighscoreScore4.Text = "5." + " " + result[4];

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

            HighscoreScore0.Text = tr.ReadLine();
            tr.Close();


        }
    }
}
