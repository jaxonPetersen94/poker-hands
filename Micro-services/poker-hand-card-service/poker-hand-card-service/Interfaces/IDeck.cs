using poker_hand_card_service.Models;

namespace poker_hand_card_service.Interfaces
{
    public interface IDeck
    {
        Card[] cardDeck { get; set; }
    }
}
