using System.Collections.Generic;

namespace CSPproject
{
    public class Hand
    {
        public List<Card> Cards;

        public Hand()
        {
            Cards = new List<Card>();
        }

        // Method to add a card to the hand
        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        // Method to remove a card from the hand
        public void RemoveCard(Card card)
        {
            Cards.Remove(card);
        }

        // Method to get the list of cards in the hand
        public List<Card> GetCards()
        {
            return Cards;
        }
    }
}

