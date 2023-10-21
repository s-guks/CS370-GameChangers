//WIP

using System;
using System.Collections;
using CSPproject;
using Newtonsoft.Json;
namespace CSPproject
{
    public class DeckMaker
    {
        public List<Card> DeserializeCards()
        {//Have to replace json file path with local path
            string jsonFilePath = "Cards.json"; // Assuming the filename is "cardsjson.json"
            string jsonData = File.ReadAllText(jsonFilePath);

            CardsContainer container = JsonConvert.DeserializeObject<CardsContainer>(jsonData);

            return container.Cards;
        }
        public static readonly Random random = new Random();


        public LinkedList<Card> StartShuffle()
        {
            List<Card> rawCards = DeserializeCards();
            List<Card> shuffledCards = Program.Shuffle(rawCards);
            LinkedList<Card> linkedCards = new LinkedList<Card>(shuffledCards);
            return linkedCards;
        }
        





    }
}

