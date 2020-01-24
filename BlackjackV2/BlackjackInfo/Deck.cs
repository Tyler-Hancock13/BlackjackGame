using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackInfo
{
    public class Deck
    {
        private List<Card> deck = new List<Card>();

        public Deck()
        {
            MakeDeck();
        }

        private void MakeDeck()
        {
            // there are 4 suits
            for (int pickASuit = 0; pickASuit <= 3; pickASuit++)
            {
                // there are 13 cards per suit
                for (int pickAValue = 0; pickAValue <= 12; pickAValue++)
                {
                    // create a card for the current suit and value
                    Card newCard = new Card((Suit)pickASuit, (FaceValue)pickAValue);
                    
                    // add the card to the deck
                    deck.Add(newCard);
                }
            }
        }

        public void Shuffle()
        {
            Random rGen = new Random();
            List<Card> newDeck = new List<Card>();
            while (deck.Count > 0)
            {
                int removeIndex = rGen.Next(0, (deck.Count));
                Card removeObject = deck[removeIndex];
                deck.RemoveAt(removeIndex);
                //  Add the removed card to the new deck.
                newDeck.Add(removeObject);
            }

            //  replace the old deck with the new deck
            deck = newDeck;
        }

        public Hand DealHand(int number)
        {
            if (deck.Count == 0)
            {
                throw new ConstraintException("There are no cards left in the deck. Redeal.");
            }

            Hand hand = new Hand();
            if (deck.Count >= number)
            {
                for (int handIndex = 0; handIndex < number; handIndex++)
                {
                    hand.AddCard(deck[0]);
                    deck.RemoveAt(0);
                }
            }
            else
            {
                for (int handIndex = 0; handIndex <= deck.Count; handIndex++)
                {
                    hand.AddCard(deck[0]);
                    deck.RemoveAt(0);
                }
            }
            return hand;

        }

        public Card DrawOneCard()
        {
            Card topCard;
            if ((deck.Count > 0))
            {
                topCard = deck[0];
                deck.RemoveAt(0);
            }
            else
            {
                throw new ArgumentException("There are no cards in the deck - deal again");
            }
            
            return topCard;
        }
    }
}