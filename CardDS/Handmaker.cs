using System;
using System.Collections.Generic;
using System.IO; // Import for File operations
using Newtonsoft.Json; // Import for JSON deserialization

namespace CSPproject
{
    public class HandMaker
    {
        public HandMaker() { }
        // Method to draw a card from the deck and add it to the hand
        public Hand Draw(Deck deck, Hand hand)
        {
            if (deck.Cards.Peek() != null)
            {
                // Draw the top card from the deck
                Card newCard = deck.Cards.Pop();
                // Add the new card to the hand
                hand.AddCard(newCard);
            } else
            {
                Console.WriteLine("No more cards in deck!");
            }
            return hand; // Return the updated hand
        }

        // Method to discard a specific card from the hand
        public Hand Discard(Hand hand, Card card)
        {   // Check if the deck is not empty
            if (hand.Cards.Count() > 0)
            {
                // Remove the specified card from the hand
                hand.RemoveCard(card);
                
            }
            else
            {
                Console.WriteLine("Empty Hand!");
            }
            return hand; // Return the updated hand
           
        }
    }
}

