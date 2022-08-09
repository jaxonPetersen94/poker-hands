using poker_hand_card_service.Interfaces;
using poker_hand_card_service.Models;

namespace poker_hand_card_service.Data
{
    public class Deck : IDeck
    {  
        public enum CardSuit 
        { 
            spades = 0,
            clubs = 1,
            hearts = 2,
            diamonds = 3,
        };

        public enum CardValue
        {
            two = 2,
            three = 3,
            four = 4,
            five = 5,
            six = 6,
            seven = 7,
            eight = 8,
            nine = 9,
            ten = 10,
            jack = 11,
            queen = 12,
            king = 13,
            ace = 14
        };

        public Card[] cardDeck { get; set; }

        public Deck()
        {
            int suitToUse = 0, valueToUse = 2;
            cardDeck = new Card[52];
            for (int i = 0; i < 52; i++)
            {
                if (i != 0 && i % 13 == 0)
                {
                    suitToUse++;
                    valueToUse = 2;
                }

                var cardId = int.Parse($"{valueToUse}{suitToUse}");

                cardDeck[i] = new Card() { MyValue = (Card.VALUE)valueToUse, MySuit = (Card.SUIT)suitToUse, Id = cardId };
                valueToUse++;
            }
        }

        public void ShuffleDeck()
        {
            Random rnd = new Random();
            cardDeck = cardDeck.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}
