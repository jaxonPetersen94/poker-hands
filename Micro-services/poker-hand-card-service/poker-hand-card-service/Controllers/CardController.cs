using Microsoft.AspNetCore.Mvc;
using poker_hand_card_service.Interfaces;
using poker_hand_card_service.Models;

namespace poker_hand_card_service.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public PlayerHand[] Get()
        {
            return _cardService.GetCards();
        }

        [HttpPost]
        public Winner Evaluate([FromBody]PlayerHand[] playerHands)
        {
            return _cardService.EvaluateCards(playerHands);
        }
    }
}
