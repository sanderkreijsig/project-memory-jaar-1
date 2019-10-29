//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;

//namespace MemoryProject28102019
//{
//    public class TwoPlayerClass
//    {
//        bool CurrentPlayer = new bool();
//        int player1score = new int();
//        int player2score = new int();

//        MemoryGrid grid;
//        TwoPlayerClass tpc;



//        public TwoPlayerClass(bool CurrentPlayer, int player1score, int player2score)
//        {
//            this.CurrentPlayer = CurrentPlayer;
//            this.player1score = player1score;
//            this.player2score = player2score;
//        }

        
//        public void ScoreToWitchPlayer()
//        {
//            if (CurrentPlayer == true)
//            {
//                player1score += 500;
//            }
//            else
//            {
//                player2score += 500;
//            }
//        }

//        public void NextPlayer()
//        {
//            if (CurrentPlayer == true)
//            {
//                CurrentPlayer = false;
//                MessageBox.Show("Speler 2 is aan de beurt");
//                player1score -= 100;
//            }
//            else
//            {
//                CurrentPlayer = true;
//                MessageBox.Show("Speler 1 is aan de beurt");
//                player2score -= 100;
//            }
//        }

//        public void WhosTheWinner()
//        {
//            if (player1score > player2score)
//            {

//                MessageBox.Show("Speler 1 heeft gewonnen, yeah!!");
//            }
//            if (player1score == player2score)
//            {

//                MessageBox.Show("No Winner, Noobs");
//            }
//            if (player1score < player2score)
//            {

//                MessageBox.Show("Speler 2 heeft gewonnen, yeah!!");
//            }
//        }

        
//    }
//}
