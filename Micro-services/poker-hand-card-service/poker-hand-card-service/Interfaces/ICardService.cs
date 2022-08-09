using poker_hand_card_service.Models;

namespace poker_hand_card_service.Interfaces
{
    public interface ICardService
    {
        Card[] _cardDeck { get; set; }
        PlayerHand[] GetCards();
        Winner EvaluateCards(PlayerHand[] playerHands);
    }
}
