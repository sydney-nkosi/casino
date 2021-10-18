using System;
using System.Collections.Generic;
using System.Linq;

namespace casino.Models
{
    public class Hand
    {
        private List<Card> hand;

        public Hand()
        {
            InitiateHand();
        }

        private void InitiateHand()
        {
            hand = new List<Card>();
        }

        public void ResetHand()
        {
            InitiateHand();
        }

        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        public int GetValue()
        {
            return hand.Sum(card => card.GetValue());
        }

        public Card GetCard(int index)
        {
            return hand.Where((card, i) => i == index).FirstOrDefault();
        }

        public void PrintHand()
        {
            hand.ForEach(card =>
            {
                Console.WriteLine(card.ToString());
            });
        }
    }
}
