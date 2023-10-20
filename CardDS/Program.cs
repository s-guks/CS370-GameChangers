using System;
namespace CSPproject {
    class Program
    {
        static void Main()
        {
            HandMaker hm = new HandMaker();
            Deck d = new Deck();
            Hand h = new Hand();
            Stack <Card> s= new Stack<Card>();
            Card c1 = new Card();
            c1.Attack = "fire";
            c1.Health = "fire";
            c1.Name = "fire";
            c1.Description = "fire";

            Card c2 = new Card();
            c2.Attack = "WATER";
            c2.Health = "w";
            c2.Name = "water";
            c2.Description = "water";

            Card c3 = new Card();
            c3.Attack = "light";
            c3.Health = "light";
            c3.Name = "light";
            c3.Description = "light";

            s.Push(c1);
            s.Push(c2);
            s.Push(c3);

            d.Cards = s;

            for(int i = 0; i<=3; i++)  h = hm.Draw(d, h);
            h = hm.Discard(h, c1);
            h = hm.Discard(h, c2);
            h = hm.Discard(h, c3);

            Console.WriteLine("a");
        }
    }
}