using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace MemoryProject28102019
{
    public class MemoryGrid
    {
        
        private Grid grid;
        private int cols;
        private int rows;
        private Highscore hs;
        bool CurrentPlayer = true;
        int player1score;
        int player2score;
        private bool OnePlayerGameBool;
        TwoPlayerGame tpg;

        public MemoryGrid(Grid grid, int cols, int rows, Highscore hs, bool OnePlayerGameBool, TwoPlayerGame tpg)
        {
            this.tpg = tpg;
            this.initClass(grid, cols,rows,hs,OnePlayerGameBool);
        }

        public MemoryGrid(Grid grid, int cols, int rows, Highscore hs, bool OnePlayerGameBool)
        {
            this.initClass(grid, cols, rows, hs, OnePlayerGameBool);
        }

        public void initClass(Grid grid, int cols, int rows, Highscore hs, bool OnePlayerGameBool)
        { 
            this.hs = hs;
            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            initializeGameGrid(cols, rows);
            AddImages();
            SaveGame();
            
            hs.ReadHighscore();
            
            this.OnePlayerGameBool = OnePlayerGameBool;
            if (OnePlayerGameBool == false)
            {
                tpg.WriteTurnDisplay(CurrentPlayer);
            }
            
            Image image = new Image();
            image.MouseDown += new MouseButtonEventHandler(CardClick);
            
        }


        /// <summary>
        ///ForLoop om het speelveld aan te maken. 
        /// </summary>
        /// <param name="cols">Aantal kolommen voor het speelveld</param>
        /// <param name="rows">Aantal rijen voor het speelveld</param>
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

        /// <summary>
        /// Slaat de huidige staat van het speelveld op in een textbestand.
        /// </summary>
        private void SaveGame()
        {
            List<ImageSource> imagesPlace = GetImageList();
            TextWriter tw = new StreamWriter("locatieplaatjes.txt");
            for (int i = 0; i < imagesPlace.Count; i++)
            {
                tw.WriteLine(imagesPlace[i]);

            }
            tw.WriteLine();
            tw.Close();
        }

        /// <summary>
        /// Methode voor het inladen van alle plaatjes op de acherkant. Voegt een click functie toe aan deze plaatjes.
        /// </summary>
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

        /// <summary>
        /// Click event voor het klikken van de plaatjes/kaartjes. Houdt bij hoe vaak er klikt is, voert de checkCards methode uit, en checkt of het spel is afgelopen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardClick(Object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            if (numberOfClicks < 2)
            {
                ImageSource front = (ImageSource)card.Tag;
                card.Source = front;
                numberOfClicks++;

                checkCards(card);
                GameFinish();
            }
            
        }
        
        /// <summary>
        /// Zorgt dat de plaatjes blijven staan als er nog geen 2 zijn aangeklikt. Als er wel twee zijn aangeklikt wordt de checkpair methode uitgevoerd.
        /// </summary>
        /// <param name="card">de geklikte kaart</param>
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
               
                Image1 = null;
                Image2 = null;
                
            }
        }



        
        /// <summary>
        /// Methode die checkt of de plaatjes gelijk zijn, als dit het geval is kijkt hij wie er aan de beurt is, deelt de punten uit aan de juiste speler, houdt bij hoeveel zetten er zijn geweest.
        /// Als de plaatjes niet gelijk zijn geeft hij strafpunten aan de juiste speler, reset de kaartjes, en verandert de beurt. Updatet de scores.
        /// </summary>
        private void checkPair()
        {
            string plaatjedir = Convert.ToString(Image1.Tag);
            string plaatjedir2 = Convert.ToString(Image2.Tag);
            if (plaatjedir == plaatjedir2)
            {
                if (OnePlayerGameBool == true)
                {
                    score += 500;
                }
                if (OnePlayerGameBool == false)
                {
                    if (CurrentPlayer == true)
                    {
                        player1score += 500;
                    }
                    else
                    {
                        player2score += 500;
                    }
                }
                
                finishCounter++;
                Image1.IsEnabled = false;
                Image2.IsEnabled = false;
                numberOfClicks = 0;

            }
            else
            {
                resetCards(Image1, Image2);
                if (score >= 100)
                {
                score -= 100;
                }
                
                if (OnePlayerGameBool == false)
                {
                    if (CurrentPlayer == true)
                    {
                        
                        CurrentPlayer = false;     
                        
                        if (player1score >= 100)
                        {
                            player1score -= 100;
                        }
                            
                           
                    }
                    else
                    {
                        
                        CurrentPlayer = true;

                        if (player2score >= 100)
                        {
                            player2score -= 100;
                        }
                    }
                }


            }
            if (OnePlayerGameBool == false)
            {
                tpg.WriteTurnDisplay(CurrentPlayer);
                tpg.Visualscoredisplay(player1score, player2score);
                hs.WriteMultiscore(player1score, player2score);
            }
            else
            {
                hs.WriteCurrentscore(score);
                hs.ReadHighscore();
            }
            
            
        }

        /// <summary>
        /// Methode die checkt of het spel klaar is, als dit het geval is schrijft hij highscores op bij een 1 player game. Bij een 2 player game worden de scores en winnaar opgeslagen.
        /// </summary>
        private void GameFinish()
        {

            if (finishCounter == 8)
            {
                if (OnePlayerGameBool == true)
                {
                hs.WriteHighscore(score);
                hs.ReadHighscore();
                }
                if (OnePlayerGameBool == false)
                {
                    tpg.Save2PGame(player1score, player2score);
                }
                else
                {
                    MessageBox.Show("Gewonnen, gefeliciteerd!");
                }
            }
        }
        
        /// <summary>
        /// Draait de kaarten terug naar de achtergrond na een delay, als deze niet hetzelfde zijn.
        /// </summary>
        /// <param name="card1">De image die eerst geklikt was</param>
        /// <param name="card2">De image die als tweede geklikt is</param>
        private async void resetCards(Image card1, Image card2)
        {
            this.Image1 = card1;
            this.Image2 = card2;

            
            await Task.Delay(1000);

            card1.Source = new BitmapImage(new Uri("Icons/Plaatje0.png", UriKind.Relative));
            card2.Source = new BitmapImage(new Uri("Icons/Plaatje0.png", UriKind.Relative));
            numberOfClicks = 0;

        }

        /// <summary>
        /// Voegt de plaatjes aan een lijst toe, en zorgt dat dezelfde plaatjes dezelfde naam krijgen. Daarna worden deze geshuffeld.
        /// </summary>
        /// <returns>Een geshuffelde lijst met plaatjes</returns>
        private List<ImageSource> GetImageList()
        {
            List<ImageSource> images = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Icons/" + imageNr + ".png", UriKind.Relative));
                images.Add(source);
            }
            
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
        
        /// <summary>
        /// Methode voor het resetten van het speelveld en alle relevante variabelen.
        /// </summary>
        public void Restart()
        {
            grid.Children.Clear();
            AddImages();
            SaveGame();
            finishCounter = 0;
            score = 0;
            player1score = 0;
            player2score = 0;
            hs.WriteMultiscore(player1score, player2score);
            hs.WriteCurrentscore(score);
            CurrentPlayer = true;
            if (OnePlayerGameBool == false)
            { 
                tpg.WriteTurnDisplay(CurrentPlayer);
                tpg.Visualscoredisplay(player1score, player2score);
            }
        }



    }
}



