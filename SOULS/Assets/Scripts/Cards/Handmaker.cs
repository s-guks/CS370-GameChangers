using System;
using System.Collections.Generic;

namespace CSPproject
{
    public class HandMaker
    {
        public Hand Draw(Deck deck, Hand hand)
        {
            if (deck.Cards.Count > 0)
            {
                Card newCard = deck.Cards.Pop();
                hand.AddCard(newCard);
            }
            else
            {
                Console.WriteLine("No more cards in deck!");
            }
            return hand;
        }

        public Hand Discard(Hand hand, Card card)
        {
            if (hand.Cards.Contains(card))
            {
                hand.RemoveCard(card);
            }
            else
            {
                Console.WriteLine("Card not found in hand!");
            }
            return hand;
        }
    }
}
