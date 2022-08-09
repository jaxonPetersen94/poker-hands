using poker_hand_card_service.Utils;

namespace poker_hand_card_service.Models
{
    public class PlayerHand
    {
        public string playerName { get; set; }
        public Card[] Cards { get; set; }
        public HandType MyHandType { get; set; }
        public HandValue MyHandValues { get; set; }
    }
}
