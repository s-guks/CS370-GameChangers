using System;
using System.Collections.Generic;

namespace CSPproject
{
    public class Hand
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

        // Constructor: If a deck is provided, draw 4 cards from the top
        public Hand(Stack<Card> deck = null)
        {
            if (deck != null)
            {
                DrawFromDeck(deck, 4);
            }
        }

        public void DrawFromDeck(Stack<Card> deck, int numberOfCards = 1)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                if (deck.Count > 0)
                {
                    Cards.Add(deck.Pop());
                }
                else
                {
                    Console.WriteLine("The deck is empty!");
                    break;
                }
            }
        }

        public void DisplayHand()
        {
            Console.WriteLine("Cards in hand:");
            foreach (Card card in Cards)
            {
                Console.WriteLine(card);
            }
        }
    }
}
