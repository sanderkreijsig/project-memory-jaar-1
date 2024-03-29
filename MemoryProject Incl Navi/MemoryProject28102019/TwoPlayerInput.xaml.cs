﻿using System;
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

namespace MemoryProject28102019
{
    /// <summary>
    /// Interaction logic for TwoPlayerInput.xaml
    /// </summary>
    public partial class TwoPlayerInput : Page
    {



        public TwoPlayerInput()
        {
            InitializeComponent();


        }

        private void StartTwoPlayerBTN_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(PlayerOneInput.Text)) || (string.IsNullOrEmpty(PlayerTwoInput.Text))) 
            {
                MessageBox.Show("U bent vergeten alle namen in te vullen!");
            }
            else
            {
                TwoPlayerGame TwoPlayerGame = new TwoPlayerGame(PlayerOneInput.Text, PlayerTwoInput.Text);
                this.NavigationService.Navigate(TwoPlayerGame);
            }
            

        }
    }
}
