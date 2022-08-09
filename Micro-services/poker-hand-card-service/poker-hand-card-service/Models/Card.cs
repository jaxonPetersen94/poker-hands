using System.Text.Json.Serialization;

namespace poker_hand_card_service.Models
{
    public class Card
    {
        public int Id { get; set; }

        public enum SUIT
        {
            SPADES,
            CLUBS,
            HEARTS,
            DIAMONDS
        }

        public enum VALUE 
        {
            TWO = 2,
            THREE = 3,
            FOUR = 4,
            FIVE = 5,
            SIX = 6,
            SEVEN = 7,
            EIGHT = 8,
            NINE = 9,
            TEN = 10,
            JACK = 11,
            QUEEN = 12,
            KING = 13,
            ACE = 14,
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SUIT MySuit { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public VALUE MyValue { get; set; }
    }
}
