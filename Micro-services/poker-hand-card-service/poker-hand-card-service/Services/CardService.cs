using poker_hand_card_service.Interfaces;
using poker_hand_card_service.Models;
using poker_hand_card_service.Utils;

namespace poker_hand_card_service.Services
{
    public class CardService : ICardService
    {
        private readonly IDeck _deckService;
        private readonly IHandEvaluator _handEvaluator;

        public CardService(IDeck deck, IHandEvaluator handEvaluator)
        {
            _deckService = deck;
            _handEvaluator = handEvaluator;
        }

        public PlayerHand[] GetCards()
        {
            PlayerHand[] playerHands = { 
                new PlayerHand() { Cards = new Card[5], playerName = "Ted" },
                new PlayerHand() { Cards = new Card[5], playerName = "Louis" } 
            };
            int cardsDealt = 0;
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    playerHands[0].Cards[cardsDealt / 2] = _deckService.cardDeck[i];
                }
                else
                {
                    playerHands[1].Cards[cardsDealt / 2] = _deckService.cardDeck[i];
                }
                cardsDealt++;
            }
            return playerHands;
        }

        public Winner EvaluateCards(PlayerHand[] playerHands)
        {
            for (int i = 0; i < playerHands.Length; i++)
            {
                playerHands[i] = _handEvaluator.EvaluatePlayerHand(playerHands[i]);
            }
            int winnerIndex = ComparePlayerHands(playerHands);
            return Winner(winnerIndex, playerHands);
        }

        private int ComparePlayerHands(PlayerHand[] playerHands)
        {
            int winnerIndex = 0;
            HandType bestHandType = playerHands[0].MyHandType;
            int highestHandValue = playerHands[0].MyHandValues.Total, highestCard = playerHands[0].MyHandValues.HighCard;
            for (int i = 1; i < playerHands.Length; i++)
            {
                if (playerHands[i].MyHandType >= bestHandType)
                {
                    if (playerHands[i].MyHandType > bestHandType)
                    {
                        highestHandValue = playerHands[i].MyHandValues.Total;
                        highestCard = playerHands[i].MyHandValues.HighCard;
                        bestHandType = playerHands[i].MyHandType;
                        winnerIndex = i;
                    }
                    else
                    {
                        if (playerHands[i].MyHandValues.Total >= highestHandValue)
                        {
                            if (playerHands[i].MyHandValues.Total > highestHandValue)
                            {
                                highestHandValue = playerHands[i].MyHandValues.Total;
                                highestCard = playerHands[i].MyHandValues.HighCard;
                                winnerIndex = i;
                            }
                            else
                            {
                                if (playerHands[i].MyHandValues.HighCard >= highestCard)
                                {
                                    if (playerHands[i].MyHandValues.HighCard > highestCard)
                                    {
                                        winnerIndex = i;
                                    }
                                    else
                                    {
                                        winnerIndex = -1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return winnerIndex;
        }

        private Winner Winner(int winnerIndex, PlayerHand[] playerHands)
        {
            if (winnerIndex == -1)
                return new Winner() { IsWinner = true, WinnerName = "Tie Game", WinnerHandType = "", WinnerHighCard = "0" };
            return new Winner()
            {
                IsWinner = true,
                WinnerName = playerHands[winnerIndex].playerName,
                WinnerHandType = $"{playerHands[winnerIndex].MyHandType}",
                WinnerHighCard = $"{(Card.VALUE)playerHands[winnerIndex].MyHandValues.HighCard}",
            };
        }
    }
}

