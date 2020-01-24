using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackInfo
{
    public class Hand
    {
        public int currentSum = 0;
        private List<Card> cards = new List<Card>();
        //Dictionary<FaceValue, int> cards = new Dictionary<FaceValue, int>();
        
            

        public int Count
        {
            get
            {
                return cards.Count();
            }
        }


        public Card this[int index]
        {
            get
            {
                return cards[index];
            }
        }


        public void AddCard(Card newCard)
        {
            // the List<T>.Contains method cannot be used since it only checks if the same reference object exists
            if (ContainsCard(newCard))
            {
                throw new ConstraintException(newCard.FaceValue.ToString() + " of " +
                    newCard.Suit.ToString() + " already exists in the Hands");
            }
            currentSum += (int) newCard.FaceValue;
            cards.Add(newCard);

        }


        private bool ContainsCard(Card cardToCheck)
        {
            foreach (Card card in cards)
            {
                if (card.FaceValue == cardToCheck.FaceValue && card.Suit == cardToCheck.Suit)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveCard(Card theCard)
        {
            if (cards.Contains(theCard))
            {
                cards.Remove(theCard);
            }
            else
            {
                throw new ConstraintException(theCard.FaceValue.ToString() + " of " +
                    theCard.Suit.ToString() + " does not exist in the Hand");
            }
        }

        public void RemoveCard(int index)
        {
            if (index <= cards.Count - 1)
            {
                cards.RemoveAt(index);
            }
            else
            {
                throw new DataException("Index value exceeds the number of cards in the hand.");
            }
            
        }

        public void RemoveCard(Suit theSuit, FaceValue theFaceValue)
        {
            foreach (Card card in cards)
            {
                if (card.Suit == theSuit && card.FaceValue == theFaceValue)
                {
                    cards.Remove(card);
                    return;
                }
            }
            throw new DataException(theFaceValue.ToString() + " of " + theSuit.ToString() + " does not exist in the Hand.");
        }
    }
}
