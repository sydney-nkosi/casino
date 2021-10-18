using System;
using System.Collections.Generic;
using System.Linq;

namespace casino.Models
{
    public class Deck
    {
        private List<Card> deck;

        public Deck()
        {
            deck = new List<Card>(52);
            for (int suit = 0; suit < 4; suit++)
            {
                for(int value = 1; value <= 13; value++)
                {
                    deck.Add(new Card((CasinoEnums.Suit)suit, (CasinoEnums.Value)value));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            deck = deck.Select(x => new { value = x, order = random.Next() })
                       .OrderBy(x => x.order).Select(x => x.value).ToList();
        }

        public Card Deal()
        {
            Card card = deck.FirstOrDefault();

            if (deck.Any())
            {
                deck.RemoveAt(0);
            }
            return card;
        }

        public void PrintDeck()
        {
            deck.ForEach(card =>
            {
                Console.WriteLine(card.ToString());
            });
        }
    }
}
