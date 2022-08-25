using poker_hand_card_service.Interfaces;
using poker_hand_card_service.Models;

namespace poker_hand_card_service.Utils
{
    public class Deck : IDeck
    {
        public Card[] cardDeck { get; set; }

        public Deck()
        {
            cardDeck = new Card[52];
            int suitToUse = 0, valueToUse = 2;
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
            ShuffleDeck();
        }

        private void ShuffleDeck()
        {
            Random rnd = new Random();
            cardDeck = cardDeck.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}
