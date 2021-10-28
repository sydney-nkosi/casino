using System;
using System.Collections.Generic;

namespace casino.Models
{
    public class Card
    {
        private readonly CasinoEnums.Suit _suit;
        private readonly CasinoEnums.Value _value;

        public Card(CasinoEnums.Suit suit, CasinoEnums.Value value)
        {
            _suit = suit;
            _value = value;
        }
        
        public override string ToString()
        {
            return $"Card [suit = {_suit}, value = {_value}]";
        }

        public int GetValue()
        {
            int value = (int)_value;
            return value <= 10 ? value : 10; //Note that J, Q & K = 10 as per rules.
        }

        public CasinoEnums.Suit GetSuit()
        {
            return _suit;
        }
    }
}
