using poker_hand_card_service.Interfaces;
using poker_hand_card_service.Models;
using System.Collections;

namespace poker_hand_card_service.Utils
{
    public enum HandType
    {
        Nothing,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    class CardValueComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return new CaseInsensitiveComparer().Compare(((Card)x).MyValue, ((Card)y).MyValue);
        }
    }

    public class HandEvaluator : IHandEvaluator
    {
        private int totalSpades { get; set; }
        private int totalClubs { get; set; }
        private int totalHearts { get; set; }
        private int totalDiamonds { get; set; }
        private Card[] cards;
        private HandValue handValue;

        public HandEvaluator()
        {
            SetInitialValues();
        }

        public PlayerHand EvaluatePlayerHand(PlayerHand playerHand)
        {
            cards = playerHand.Cards;
            Array.Sort(cards, new CardValueComparer());
            playerHand.MyHandType = EvaluateHand();
            playerHand.MyHandValues = handValue;
            SetInitialValues();
            return playerHand;
        }

        private HandType EvaluateHand()
        {
            getSuitTotals();
            if (StraightFlush())
                return HandType.StraightFlush;
            if (FourOfAKind())
                return HandType.FourOfAKind;
            else if (FullHouse())
                return HandType.FullHouse;
            else if (Flush())
                return HandType.Flush;
            else if (Straight())
                return HandType.Straight;
            else if (ThreeOfAKind())
                return HandType.ThreeOfAKind;
            else if (TwoPair())
                return HandType.TwoPair;
            else if (OnePair())
                return HandType.Pair;

            handValue.HighCard = (int)cards[4].MyValue;
            return HandType.Nothing;
        }

        private void getSuitTotals()
        {
            foreach (var card in cards)
            {
                if (card.MySuit == Card.SUIT.SPADES) totalSpades++;
                else if (card.MySuit == Card.SUIT.CLUBS) totalClubs++;
                else if (card.MySuit == Card.SUIT.HEARTS) totalHearts++;
                else if (card.MySuit == Card.SUIT.DIAMONDS) totalDiamonds++;
            }
        }

        private bool StraightFlush()
        {
            if (Straight() && Flush())
            {
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool FourOfAKind()
        {
            if (cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[0].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[0].MyValue * 4;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue && cards[1].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                handValue.HighCard = (int)cards[0].MyValue;
                return true;
            }
            return false;
        }
        private bool FullHouse()
        {
            if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue) ||
                (cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue))
            {
                handValue.Total = (int)(cards[0].MyValue) + (int)(cards[1].MyValue) + (int)(cards[2].MyValue)
                     + (int)(cards[3].MyValue) + (int)(cards[4].MyValue);
                return true;
            }
            return false;
        }
        private bool Flush()
        {
            if (totalSpades == 5 || totalClubs == 5 || totalHearts == 5 || totalDiamonds == 5)
            {
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool Straight()
        {
            if (cards[0].MyValue + 1 == cards[1].MyValue &&
                cards[1].MyValue + 1 == cards[2].MyValue &&
                cards[2].MyValue + 1 == cards[3].MyValue &&
                cards[3].MyValue + 1 == cards[4].MyValue)
            {
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool ThreeOfAKind()
        {
            if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue) ||
                    (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue))
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                handValue.HighCard = (int)cards[1].MyValue;
                return true;
            }
            return false;
        }
        private bool TwoPair()
        {
            if (cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }
            else if (cards[0].MyValue == cards[1].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[0].MyValue;
                return true;
            }
            return false;
        }
        private bool OnePair()
        {
            if (cards[0].MyValue == cards[1].MyValue)
            {
                handValue.Total = (int)cards[0].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[2].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[3].MyValue * 2;
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }
            return false;
        }

        private void SetInitialValues()
        {
            totalSpades = 0;
            totalClubs = 0;
            totalHearts = 0;
            totalDiamonds = 0;
            cards = new Card[5];
            handValue = new HandValue();
        }
    }
}
