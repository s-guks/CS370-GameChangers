//WIP

using System;
using System.Collections;
using CSPproject;
using Newtonsoft.Json;
namespace CSPproject
{
    public class DeckMaker
    {

        public static List<Card> Shuffle(List<Card> list)
        {
            Random _random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public List<Card> deserializeCards()
        {

            string jsonFilePath = "CardDS/Cards.json";
            string jsonData = File.ReadAllText(jsonFilePath);

            Card c = JsonConvert.DeserializeObject<Card>(jsonData);


            //cardList = JsonConvert.DeserializeObject<List<Card>>(jsonData);
            return new List<Card>();
        }

        public LinkedList<Card> startShuffle()
        {
            List<Card> rawCards = deserializeCards();
            List<Card> shuffledCards = Shuffle(rawCards);
            LinkedList<Card> linkedCards = new LinkedList<Card>(shuffledCards);
            return linkedCards;
        }
    }
}