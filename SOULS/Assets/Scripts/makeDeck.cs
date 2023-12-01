using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.IO;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Card : ScriptableObject
{
    public string cardName;
    public int id;
    public int idObj;
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

    public int globalId = 0;


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
        c1.probability = 1; //good? card
        c1.idObj = 0;
        Cards.Add(c1);

        Card c2 = ScriptableObject.CreateInstance<Card>();
        c2.cardName = "Lenny the Lawyer";
        c2.id = 2;
        c2.attack = 2;
        c2.health = 4;
        c2.skill = null;
        c2.texture = 1;
        c2.borderColor = null;
        c2.probability = 1; //mid card
        c2.idObj = 0;
        Cards.Add(c2);

        Card c3 = ScriptableObject.CreateInstance<Card>();
        c3.cardName = "Misha the Mechanic";
        c3.id = 3;
        c3.attack = 3;
        c3.health = 2;
        c3.skill = null;
        c3.texture = 1;
        c3.borderColor = null;
        c3.probability = 1; //mid card
        c3.idObj = 0;
        Cards.Add(c3);

        Card c4 = ScriptableObject.CreateInstance<Card>();
        c4.cardName = "Natalie the Nurse";
        c4.id = 4;
        c4.attack = 1;
        c4.health = 6;
        c4.skill = null;
        c4.texture = 1;
        c4.borderColor = null;
        c4.probability = 1; //good? card
        c4.idObj = 0;
        Cards.Add(c4);

        Card c5 = ScriptableObject.CreateInstance<Card>();
        c5.cardName = "Paul the Policeman";
        c5.id = 5;
        c5.attack = 3;
        c5.health = 3;
        c5.skill = null;
        c5.texture = 1;
        c5.borderColor = null;
        c5.probability = 1; //mid card
        c5.idObj = 0;
        Cards.Add(c5);

        Card c6 = ScriptableObject.CreateInstance<Card>();
        c6.cardName = "Taylor the Teacher";
        c6.id = 6;
        c6.attack = 2;
        c6.health = 4;
        c6.skill = null;
        c6.texture = 1;
        c6.borderColor = null;
        c6.probability = 1; //mid card
        c6.idObj = 0;
        Cards.Add(c6);

        Card c7 = ScriptableObject.CreateInstance<Card>();
        c7.cardName = "Jerry the Judge";
        c7.id = 7;
        c7.attack = 4;
        c7.health = 3;
        c7.skill = null;
        c7.texture = 1;
        c7.borderColor = null;
        c7.probability = 1; //good card
        c7.idObj = 0;
        Cards.Add(c7);

        Card c8 = ScriptableObject.CreateInstance<Card>();
        c8.cardName = "Wendy the Waitress";
        c8.id = 8;
        c8.attack = 2;
        c8.health = 3;
        c8.skill = null;
        c8.texture = 1;
        c8.borderColor = null;
        c8.probability = 1; //mid card
        c8.idObj = 0;
        Cards.Add(c8);

        Card c9 = ScriptableObject.CreateInstance<Card>();
        c9.cardName = "Demarco the Detective";
        c9.id = 9;
        c9.attack = 4;
        c9.health = 2;
        c9.skill = null;
        c9.texture = 1;
        c9.borderColor = null;
        c9.probability = 1; //upper-mid card
        c9.idObj = 0;
        Cards.Add(c9);
        
        Card c10 = ScriptableObject.CreateInstance<Card>();
        c10.cardName = "Pedro the Plumber";
        c10.id = 10;
        c10.attack = 2;
        c10.health = 2;
        c10.skill = null;
        c10.texture = 1;
        c10.borderColor = null;
        c10.probability = 1; //mid card
        c10.idObj = 0;
        Cards.Add(c10);

        Card c11 = ScriptableObject.CreateInstance<Card>();
        c11.cardName = "Chaz the Chef";
        c11.id = 11;
        c11.attack = 2;
        c11.health = 5;
        c11.skill = null;
        c11.texture = 1;
        c11.borderColor = null;
        c11.probability = 1; //good card
        c11.idObj = 0;
        Cards.Add(c11);

        Card c12 = ScriptableObject.CreateInstance<Card>();
        c12.cardName = "Perry the Pilot";
        c12.id = 12;
        c12.attack = 2;
        c12.health = 3;
        c12.skill = null;
        c12.texture = 1;
        c12.borderColor = null;
        c12.probability = 1; //mid card
        c12.idObj = 0;
        Cards.Add(c12);

        Card c13 = ScriptableObject.CreateInstance<Card>();
        c13.cardName = "Don the Developer";
        c13.id = 12;
        c13.attack = 1;
        c13.health = 2;
        c13.skill = null;
        c13.texture = 1;
        c13.borderColor = null;
        c13.probability = 1; //bad card
        c13.idObj = 0;
        Cards.Add(c13);
    }

    public Card DrawRandom()
    {
        var rand = new System.Random();
        int r = rand.Next(0, 13);        //number of cards in Awake()
        Card temp = ScriptableObject.CreateInstance<Card>();
        temp.cardName = Cards[r].cardName;
        temp.id = Cards[r].id;
        temp.attack = Cards[r].attack;
        temp.health = Cards[r].health;
        temp.skill = Cards[r].skill;
        temp.texture = Cards[r].texture;
        temp.borderColor = Cards[r].borderColor;
        temp.probability = Cards[r].probability;

        //idObj is unique for each card
        temp.idObj = globalId;
        globalId = globalId + 1;

        return temp;

    }

    public Stack<Card> CreateRandomDeck(int numberOfCards)
    {
        Stack<Card> st = new Stack<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            var rand = new System.Random();
            double d = rand.NextDouble(0, 1);
            Card temp = ScriptableObject.CreateInstance<Card>();
            int r;
            if (d < 0.05)
            {
                r = 0;
            }
            else if (d < 0.15)
            {
                r = 1;
            }
            else if (d < 0.25)
            {
                r = 2;
            }
            else if (d < 0.30)
            {
                r = 3;
            }
            else if (d < 0.37)
            {
                r = 4;
            }
            else if (d < 0.46) {
                r = 5;
            } 

            else if (d < 0.55) {
                r = 6;
            } 

            else if (d < 0.62) {
                r = 7;
            } 
            else if (d < 0.66) {
                r = 8;
            } 
            else if (d < 0.73) {
                r = 9;
            } 
            else if (d < 0.79) {
                r = 10;
            } 
            else if (d < 0.9) {
                r = 11;
            } 
            else
            {
                r = 12;
            }// 11 9 4 1 stronger

            temp.cardName = Cards[r].cardName;
            temp.id = Cards[r].id;
            temp.attack = Cards[r].attack;
            temp.health = Cards[r].health;
            temp.skill = Cards[r].skill;
            temp.texture = Cards[r].texture;
            temp.borderColor = Cards[r].borderColor;
            temp.probability = Cards[r].probability;

            //idObj is unique for each card
            temp.idObj = globalId;
            globalId = globalId + 1;

            st.Push(temp);
        }
        Stack<Card> deck = st;
        return deck;
    }
    public Stack<Card> CreateRandomDeck(int numberOfCards)
    {
        Stack<Card> st = new Stack<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            var rand = new System.Random();
            double d = rand.NextDouble(0, 1);
            Card temp = ScriptableObject.CreateInstance<Card>();
            int r;
            if (d < 0.05)
            {
                r = 0;
            }
            else if (d < 0.15)
            {
                r = 1;
            }
            else if (d < 0.25)
            {
                r = 2;
            }
            else if (d < 0.30)
            {
                r = 3;
            }
            else if (d < 0.37)
            {
                r = 4;
            }
            else if (d < 0.46) {
                r = 5;
            } 

            else if (d < 0.55) {
                r = 6;
            } 

            else if (d < 0.62) {
                r = 7;
            } 
            else if (d < 0.66) {
                r = 8;
            } 
            else if (d < 0.73) {
                r = 9;
            } 
            else if (d < 0.79) {
                r = 10;
            } 
            else if (d < 0.9) {
                r = 11;
            } 
            else
            {
                r = 12;
            }// 11 9 4 1 stronger

            temp.cardName = Cards[r].cardName;
            temp.id = Cards[r].id;
            temp.attack = Cards[r].attack;
            temp.health = Cards[r].health;
            temp.skill = Cards[r].skill;
            temp.texture = Cards[r].texture;
            temp.borderColor = Cards[r].borderColor;
            temp.probability = Cards[r].probability;

            //idObj is unique for each card
            temp.idObj = globalId;
            globalId = globalId + 1;

            st.Push(temp);
        }
        Stack<Card> deck = st;
        return deck;
    }
    //depreciated
    /*public Stack<Card> CreateRandomDeck(int numberOfCards)
    {
        Stack<Card> st = new Stack<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            var rand = new System.Random();
            int r = rand.Next(0, 13);       //number of cards in Awake()
            Card temp = ScriptableObject.CreateInstance<Card>();
            temp.cardName = Cards[r].cardName;
            temp.id = Cards[r].id;
            temp.attack = Cards[r].attack;
            temp.health = Cards[r].health;
            temp.skill = Cards[r].skill;
            temp.texture = Cards[r].texture;
            temp.borderColor = Cards[r].borderColor;
            temp.probability = Cards[r].probability;

            //idObj is unique for each card
            temp.idObj = globalId;
            globalId = globalId + 1;

            st.Push(temp);
        }
        Stack<Card> deck = st;
        return deck;
    }*/

    public void Draw(string hand, string deck, int draw_amount){
        Debug.Log(Decks[deck].Count);
        if (Decks[deck].Count == 1) return;
        while (Decks[deck].Peek() != null && draw_amount > 0) {
            Hands[hand].Add(Decks[deck].Pop());
            draw_amount -= 1;
        }
    }

    public void Discard(string hand, int index) {
        
        if (index +1 > Hands[hand].Count) return;
        Hands[hand].RemoveAt(index);
    }

}

