using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackInfo
{
    public class Game
    {
        public Player player = new Player();
        public Dealer dealer = new Dealer();
        Deck aDeck = new Deck();

        
        public void StartGame()
        {
            StartingHand();
        }

        public Hand StartingHand()
        {
            
            player.hand = aDeck.DealHand(2);
            dealer.hand = aDeck.DealHand(2);
            
            return player.hand;
        }

        public Hand DealerStartingHand()
        {
            dealer.hand = aDeck.DealHand(1);
            return dealer.hand;
        }

        public Hand DealerHit()
        {
                aDeck.DrawOneCard();
                dealer.hand.AddCard(aDeck.DrawOneCard());
            
            return dealer.hand;
        }

        
        public Hand Setup()
        {
            aDeck.Shuffle();
            Hand aHand = new Hand();
            aHand = StartingHand();
            return aHand;
            
        }

        

        

        public Hand PlayerHit()
        {
            if (!player.Bust)
            {
                player.hand.AddCard(aDeck.DrawOneCard());
            }
            return player.hand;
        }

        public Hand PlayerStand()
        {
            if (!player.Bust)
            {
                player.isStanding = true;
            }
            return player.hand;
        }

        public bool CheckForBlackjack()
        {
            if(player.hand.currentSum == 21)
            {
                player.hasBlackjack = true;
            }
            return player.hasBlackjack;
        }

        private void CardValues(Card drawn, int currentSum)
        {
            if (drawn.FaceValue == FaceValue.Ace)
            {
                if (currentSum <= 10)
                {
                    currentSum += 11;
                }
                else
                {
                    currentSum += 1;
                }
            }
            else if (drawn.FaceValue == FaceValue.Jack || drawn.FaceValue == FaceValue.Queen || drawn.FaceValue == FaceValue.King)
            {
                currentSum += 10;
            }
            else
            {
                currentSum += (int)drawn.FaceValue;
            }
        }

    }
}
