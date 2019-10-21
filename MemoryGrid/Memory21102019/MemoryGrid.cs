using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Linq;

namespace Memory21102019
{
    public class MemoryGrid
    {
        private Grid grid;
        private int cols;
        private int rows;

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            this.cols = cols;
            this.rows = rows;
            initializeGameGrid(cols, rows);
            AddImages();

            Image image = new Image();
            image.MouseDown += new MouseButtonEventHandler(CardClick);
            
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="rows"></param>
        
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
            List<ImageSource> images =  GetImageList();
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

        private void CardClick(Object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
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

    }
}
    
    


