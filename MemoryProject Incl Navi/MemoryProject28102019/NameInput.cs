using System.IO;
using System.Windows.Controls;

namespace MemoryProject28102019
{
    public class NameInput
    {
        TextBox UName1Input = new TextBox();
        TextBox UName2Input = new TextBox();
        Label UName1Label = new Label();
        Label UName2Label = new Label();
        string UName1;
        string UName2;


        //MemoryGrid grid;
        public NameInput()
        {
            //grid = new MemoryGrid(UName1, UName2);
        }

        public NameInput(Label UName1Label)
        {
            this.UName1Label = UName1Label;
        }




        public void WriteNameInput()
        {
            UName1 = UName1Input.Text;
            UName2 = UName2Input.Text;
            UName1Label.Content = UName1;
            UName2Label.Content = UName2;

        }
        string winner;
        int GameCount = 0;
        public void Save2PGame(int player1score, int player2score)
        {
            GameCount++;
            TextWriter tw = new StreamWriter("GameSaves.txt", true);

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

            tw.WriteLine("Spel " + GameCount + ": " + UName1 + " " + player1score + " " + UName2 + " " + player2score + " " + "Winner: " + winner);
            tw.Close();
        }










    }
}
