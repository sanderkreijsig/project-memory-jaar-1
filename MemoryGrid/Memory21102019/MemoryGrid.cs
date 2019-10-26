using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Memory21102019
{
    //test voor github
    public class MemoryGrid
    {
        private Grid grid;
        private int cols;
        private int rows;
        private Highscore hs;
        private NameInput ni;
        bool CurrentPlayer = true;
        string username1;
        string username2;

        public MemoryGrid(Grid grid, int cols, int rows, Highscore hs, NameInput ni)
        {
            this.hs = hs;
            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            this.ni = ni;
            initializeGameGrid(cols, rows);
            AddImages();
            hs.ReadHighscore();
            

            Image image = new Image();
            image.MouseDown += new MouseButtonEventHandler(CardClick);
        }

        public MemoryGrid(string UName1, string UName2)
        {
            username1 = UName1;
            username2 = UName2;
        }


        //GameGridMaken
        private void initializeGameGrid(int cols, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        //add Card Background.
        private void AddImages()
        {
            List<ImageSource> images = GetImageList();
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("Icons/Plaatje0.png", UriKind.Relative));
                    backgroundImage.Tag = images.First();
                    images.RemoveAt(0);
                    backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                }
            }
        }
        
        static int numberOfClicks = 0;
        private Image card;
        int score;

        int finishCounter = 0;
        private Image Image1;
        private Image Image2;
        private void CardClick(Object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
            numberOfClicks++;

            checkCards(card);
            GameFinish();
        }

        private void checkCards(Image card)
        {

            this.card = card;
            if (numberOfClicks < 2 || numberOfClicks == 2)
            {

                if (this.Image1 == null)
                {
                    Image1 = card;
                    Image1.IsEnabled = false;
                }
                else if (this.Image2 == null)
                {
                    Image2 = card;
                    Image1.IsEnabled = true;
                }
            }

            if (numberOfClicks == 2)
            {
                checkPair();
                numberOfClicks = 0;
                Image1 = null;
                Image2 = null;
            }
        }


        int player1score;
        int player2score;
        private void checkPair()
        {
            string plaatjedir = Convert.ToString(Image1.Tag);
            string plaatjedir2 = Convert.ToString(Image2.Tag);
            if (plaatjedir == plaatjedir2)
            {
                score += 500;
                finishCounter++;
                Image1.IsEnabled = false;
                Image2.IsEnabled = false;
                if (CurrentPlayer == true)
                {
                    player1score += 500;
                }
                else
                {
                    player2score += 500;
                }
            }
            else
            {
                resetCards(Image1, Image2);
                score -= 100;
                if (CurrentPlayer == true)
                {
                    CurrentPlayer = false;
                    MessageBox.Show("Speler 2 is aan de beurt");
                    player1score -= 100;
                }
                else
                {
                    CurrentPlayer = true;
                    MessageBox.Show("Speler 1 is aan de beurt");
                    player2score -= 100;
                }


            }
            hs.WriteCurrentscore(score);
            hs.WriteHighscore(score);
            hs.ReadHighscore();
            hs.WriteMultiscore(player1score, player2score);
        }

        
        private void GameFinish()
        {
            
            if (finishCounter == 8)
            {
                
                hs.WriteHighscore(score);
                hs.ReadHighscore();
                if (player1score > player2score)
                {
                    
                    MessageBox.Show("Speler 1 heeft gewonnen, yeah!!");
                }
                if (player1score == player2score)
                {
                    
                    MessageBox.Show("No Winner, Noobs");
                }
                if (player1score < player2score)
                {
                   
                    MessageBox.Show("Speler 2 heeft gewonnen, yeah!!");
                }
                
                ni.Save2PGame(player1score, player2score);
            }
        }
        private bool hasDelay;
        private async void resetCards(Image card1, Image card2)
        {
            this.Image1 = card1;
            this.Image2 = card2;

            hasDelay = true;
            await Task.Delay(1000);

            card1.Source = new BitmapImage(new Uri("Icons/Plaatje0.png", UriKind.Relative));
            card2.Source = new BitmapImage(new Uri("Icons/Plaatje0.png", UriKind.Relative));
            hasDelay = false;
        }

        //Lijst met plaatjes
        private List<ImageSource> GetImageList()
        {
            List<ImageSource> images = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Icons/" + imageNr + ".png", UriKind.Relative));
                images.Add(source);
            }
            //shuffle
            Random random = new Random();
            for (int i = 0; i < (rows * cols); i++)
            {
                int r = random.Next(0, (rows * cols));
                ImageSource temp = images[r];
                images[r] = images[i];
                images[i] = temp;
            }

            return images;
        }

        public void Restart()
        {
            grid.Children.Clear();
            AddImages();
            finishCounter = 0;
            score = 0;
            player1score = 0;
            player2score = 0;
            hs.WriteMultiscore(player1score, player2score);
            hs.WriteCurrentscore(score);
        }

        
    }
}
    
    


