using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackInfo
{
    public class Player
    {
        public int Hand = 0;
        
        public bool isStanding = false;
        public Hand hand = new Hand();
        public bool hasBlackjack = false;

        public bool Bust
        {
            get
            {
                return hand.currentSum > 21;
            }
        }
    }
}
