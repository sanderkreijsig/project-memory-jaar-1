using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Memory21102019
{
    public class TwoPlayerVersie
    {

        public bool CurrentPlayer = true;

        public TwoPlayerVersie()
        {
            
        }

        public TwoPlayerVersie(bool CurrentPlayer = true)
        {

        }
        
        public void WhoseTurn()

        {
            bool CurrentPlayer = true;   
            
            if (CurrentPlayer == true)
            {
                CurrentPlayer = false;
                MessageBox.Show("Speler 2 is aan de beurt");
            }
            else
            {
                CurrentPlayer = true;
                MessageBox.Show("Speler 1 is aan de beurt");

            }
        }
    }
}
