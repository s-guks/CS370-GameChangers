using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Card : ScriptableObject
{
    public string cardName;
    public int id;
    public int attack;
    public int health;
    public string? skill;
    public int texture;
    public string? borderColor;
    public int probability;
}

public class makeDeck : MonoBehaviour {

    public Dictionary<string, Stack<Card>> Decks;
    public Dictionary<string, List<Card>> Hands;
    public List<Card> Cards;


    public void GameStart()
    {
        Decks = new(0);
        Hands = new(0);
        Decks.Add("deck1", CreateRandomDeck(25));
        Decks.Add("deck2", CreateRandomDeck(25));
        Hands.Add("hand1", new List<Card>());
        Hands.Add("hand2", new List<Card>());
        Draw("hand1", "deck1", 4);
        Draw("hand2", "deck2", 4);
    }

    void Awake()
    {
        
        Cards = new(0);

        Card c1 = ScriptableObject.CreateInstance<Card>();
        c1.cardName = "Bob the Butcher";
        c1.id = 1;
        c1.attack = 5;
        c1.health = 1;
        c1.skill = null;
        c1.texture = 1;
        c1.borderColor = null;
        c1.probability = 1;
        Cards.Add(c1);

        Card c2 = ScriptableObject.CreateInstance<Card>();
        c2.cardName = "Lenny the Lawyer";
        c2.id = 2;
        c2.attack = 2;
        c2.health = 4;
        c2.skill = null;
        c2.texture = 1;
        c2.borderColor = null;
        c2.probability = 1;
        Cards.Add(c2);

        Card c3 = ScriptableObject.CreateInstance<Card>();
        c3.cardName = "Misha the Mechanic";
        c3.id = 3;
        c3.attack = 3;
        c3.health = 2;
        c3.skill = null;
        c3.texture = 1;
        c3.borderColor = null;
        c3.probability = 1;
        Cards.Add(c3);

        Card c4 = ScriptableObject.CreateInstance<Card>();
        c4.cardName = "Natalie the Nurse";
        c4.id = 4;
        c4.attack = 2;
        c4.health = 5;
        c4.skill = null;
        c4.texture = 1;
        c4.borderColor = null;
        c4.probability = 1;
        Cards.Add(c4);

        Card c5 = ScriptableObject.CreateInstance<Card>();
        c5.cardName = "Paul the Policeman";
        c5.id = 5;
        c5.attack = 3;
        c5.health = 3;
        c5.skill = null;
        c5.texture = 1;
        c5.borderColor = null;
        c5.probability = 1;
        Cards.Add(c5);
       
    }

    public Card DrawRandom()
    {
        var rand = new System.Random();
        int r = rand.Next(0, 5);
        Card temp = ScriptableObject.CreateInstance<Card>();
        temp.cardName = Cards[r].cardName;
        temp.id = Cards[r].id;
        temp.attack = Cards[r].attack;
        temp.health = Cards[r].health;
        temp.skill = Cards[r].skill;
        temp.texture = Cards[r].texture;
        temp.borderColor = Cards[r].borderColor;
        temp.probability = Cards[r].probability;

        return temp;

    }

    public Stack<Card> CreateRandomDeck(int numberOfCards)
    {
        Stack<Card> st = new Stack<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            var rand = new System.Random();
            int r = rand.Next(0, 5);
            Card temp = ScriptableObject.CreateInstance<Card>();
            temp.cardName = Cards[r].cardName;
            temp.id = Cards[r].id;
            temp.attack = Cards[r].attack;
            temp.health = Cards[r].health;
            temp.skill = Cards[r].skill;
            temp.texture = Cards[r].texture;
            temp.borderColor = Cards[r].borderColor;
            temp.probability = Cards[r].probability;
            st.Push(temp);
        }
        Stack<Card> deck = st;
        return deck;
    }

    public void Draw(string hand, string deck, int draw_amount){
        if (Decks[deck].Peek() == null) return;
        while (Decks[deck].Peek() != null && draw_amount > 0) {
            Hands[hand].Add(Decks[deck].Pop());
            draw_amount--;
        }
    }

    public void Discard(string hand, int index) {
        
        if (index +1 > Hands[hand].Count) return;
        Hands[hand].RemoveAt(index);
    }

}

