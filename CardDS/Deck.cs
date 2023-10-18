using System;
using CSPproject;
using System.Reflection.Metadata;

using System.Collections.Generic; // Import the namespace for LinkedList<T>

namespace CSPproject
{
    public class Deck
    {
        // Declare a field or property to store the linked list of cards
        public Stack<Card> Cards { get; set; }



        // Add methods and functionality for the Deck class as needed
    }

    public class getdeck
    {
        public static readonly Random random = new Random();  // Static instance of Random
        public static Card CopyCard(Card original)
        {
            return new Card
            {
                CardName = original.CardName,
                Description = original.Description,
                Attack = original.Attack,
                Health = original.Health,
                Skill = original.Skill,
                Texture = original.Texture,
                BorderColor = original.BorderColor,
                Probability = original.Probability
            };
        }

        public static Card DrawRandomCardWithReplacement(List<Card> pool)
        {
            int randomIndex = random.Next(pool.Count);
            Card originalCard = pool[randomIndex];
            return CopyCard(originalCard);
        }


        public static Stack<Card> CreateRandomDeck(List<Card> pool, int numberOfCards = 25)
        {
            Stack<Card> deck = new Stack<Card>();

            for (int i = 0; i < numberOfCards; i++)
            {
                deck.Push(DrawRandomCardWithReplacement(pool));
            }
            Stack<Card> temp = deck;
            return deck;
        }

        //public static void Main(string[] args)
        //{

        //    DeckMaker deckMaker = new DeckMaker();
        //    List<Card> cardPool = deckMaker.DeserializeCards(); // Deserialize cards from the JSON file

        //    Stack<Card> deck1 = CreateRandomDeck(cardPool);
        //    Stack<Card> deck2 = CreateRandomDeck(cardPool);
        //    Console.WriteLine("Random Deck of 25 Cards:");
        //    Console.WriteLine("deck 1:");
        //    foreach (Card card in deck1)
        //    {
        //        Console.WriteLine(card);
        //    }

        //    Console.WriteLine("deck 2:");
        //    foreach (Card card in deck2)
        //    {
        //        Console.WriteLine(card);
        //    }

        //public static void Main(string[] args)
        //{
        //    DeckMaker deckMaker = new DeckMaker();
        //    List<Card> cardPool = deckMaker.DeserializeCards();  // Deserialize cards from the JSON file.


        //    Stack<Card> deck1 = CreateRandomDeck(cardPool);
        //    Stack<Card> deck2 = CreateRandomDeck(cardPool);

        //    Hand hand1 = new Hand(deck1);
        //    Hand hand2 = new Hand(deck2);

        //    Console.WriteLine("deck 1:");
        //    hand1.DisplayHand();
        //    Console.WriteLine("deck 2:");
        //    hand2.DisplayHand();

        //}


    }



    }









