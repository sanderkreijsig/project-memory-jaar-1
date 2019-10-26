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

    
    public class NameInput
    {
        
        TextBox UName1Input = new TextBox();
        TextBox UName2Input = new TextBox();
        Label UName1Label = new Label();
        Label UName2Label = new Label();
        string UName1;
        string UName2;
        
        
        MemoryGrid grid;
        public NameInput()
        {
            grid = new MemoryGrid(UName1, UName2);
        }

        public NameInput(TextBox UName1Input, TextBox UName2Input, Label UName1Label, Label UName2Label)
        {
            this.UName1Input = UName1Input;
            this.UName2Input = UName2Input;
            this.UName1Label = UName1Label;
            this.UName2Label = UName2Label;
            
        }
     

        public void WriteNameInput()
        {
            UName1 = UName1Input.Text;
            UName2 = UName2Input.Text;
            UName1Label.Content = UName1;
            UName2Label.Content = UName2;
            
        }
        string winner;
        public void Save2PGame(int player1score, int player2score)
        {
        
            TextWriter tw = new StreamWriter("GameSaves.txt");
            if (player1score > player2score)
            {
                winner = UName1;
                
            }
            if (player1score == player2score)
            {
                winner = "gelijkspel";
                
            }
            if (player1score < player2score)
            {
                winner = UName2;
                
            }
            tw.WriteLine(UName1 + " " + player1score);
                tw.WriteLine(UName2 + " " + player2score);
                tw.WriteLine("de winner is " + winner);
                tw.Close();
            }

   
            
                
                
               

        


    }
}
