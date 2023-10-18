using System;
using System.Collections.Generic;

namespace CSPproject
{
    public class Card
    {
        public string CardName { get; set; }
        public string Description { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public string Skill { get; set; }
        public int Texture { get; set; }
        public string BorderColor { get; set; }
        public int Probability { get; set; }

        public override string ToString()
        {
            return $"{CardName} - {Description} (Attack: {Attack}, Health: {Health}, Skill: {Skill ?? "None"}, Texture: {Texture}, BorderColor: {BorderColor ?? "None"}, Probability: {Probability})";
        }
    }
    




    public class Program
    {
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

        public static List<T> Shuffle<T>(List<T> inputList) where T : Card
        {
            List<T> copiedList = new List<T>(inputList.Count);
            foreach (T card in inputList)
            {
                copiedList.Add((T)CopyCard(card));
            }

            int n = copiedList.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                T temp = copiedList[i];
                copiedList[i] = copiedList[j];
                copiedList[j] = temp;
            }
            return copiedList;
        }

        public static readonly Random random = new Random();

        public static Card DrawRandomCardWithReplacement(List<Card> pool)
        {
            int randomIndex = random.Next(pool.Count);
            Card originalCard = pool[randomIndex];
            return CopyCard(originalCard);
        }



        public static void Main(string[] args)
        {
            DeckMaker deckMaker = new DeckMaker();
            List<Card> cardList = deckMaker.DeserializeCards(); // Deserialize cards from the JSON file.

            List<Card> shuffledCards = Shuffle(cardList);

            Console.WriteLine("Shuffled Deck:");
            foreach (Card card in shuffledCards)
            {
                Console.WriteLine(card);
            }
        }

    }
}
