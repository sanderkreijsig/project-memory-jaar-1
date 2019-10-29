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
    /// Interaction logic for OnePlayerGame.xaml
    /// </summary>
    public partial class OnePlayerGame : Page
    {
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        string PlayerInput;
        bool OnePlayerGameBool;
        MemoryGrid grid;

        Highscore hs;
        NameInput ni;
        OnePlayerClass OPC;
        //MainWindow main;
        public OnePlayerGame(string PlayerInput)
        {

            this.PlayerInput = PlayerInput;

            InitializeComponent();
            hs = new Highscore(highscoretb, currentscoretb);
            //main = new MainWindow();
            //ni = new NameInput(UName1Label);
            grid = new MemoryGrid(GameGrid, NR_OF_COLS, NR_OF_ROWS, hs, ni, true);
            //OnePlayerGameBool = main.OnePlayerGameBool;
            OPC = new OnePlayerClass();
            PlayerNameInput();
        }

        private void PlayerNameInput()
        {
            UName3Label.Content = PlayerInput;
        }


        private void Restart_Click(Object sender, RoutedEventArgs e)
        {

            grid.Restart();

        }

        private void NameInput_Click(Object sender, RoutedEventArgs e)
        {
            ni.WriteNameInput();

        }
    }
}
