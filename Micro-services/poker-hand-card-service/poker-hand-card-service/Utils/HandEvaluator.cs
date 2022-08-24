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
        private Card[] cards;
        private HandValue handValue;

        public HandEvaluator()
        {
            cards = new Card[5];
            handValue = new HandValue();
        }

        public PlayerHand EvaluatePlayerHand(PlayerHand playerHand)
        {
            cards = playerHand.Cards;
            Array.Sort(cards, new CardValueComparer());
            playerHand.MyHandType = EvaluateHand();
            playerHand.MyHandValues = handValue;
            return playerHand;
        }

        private HandType EvaluateHand()
        {
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
            for (int i = 0; i < 1; i++)
            {
                if (cards[i].MyValue == cards[i+1].MyValue && cards[i].MyValue == cards[i+2].MyValue && cards[i].MyValue == cards[i+3].MyValue)
                {
                    handValue.Total = (int)cards[i].MyValue * 4;
                    handValue.HighCard = i == 0 ? (int)cards[4].MyValue : (int)cards[0].MyValue;
                    return true;
                }
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
            for (int i = 0; i < cards.Length-1; i++)
            {
                if (cards[i].MySuit == cards[i + 1].MySuit) continue;
                return false;
            }
            handValue.Total = (int)cards[4].MyValue;
            return true;
        }
        private bool Straight()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].MyValue + 1 == cards[i + 1].MyValue) continue;
                return false;
            }
            handValue.Total = (int)cards[4].MyValue;
            return true;
        }
        private bool ThreeOfAKind()
        {
            for (int i = 0; i < 2; i++)
            {
                if (cards[i].MyValue == cards[i+1].MyValue && cards[i].MyValue == cards[i+2].MyValue)
                {
                    handValue.Total = (int)cards[2].MyValue * 3;
                    handValue.HighCard = i + 2 == 4 ? (int)cards[1].MyValue : (int)cards[4].MyValue;
                    return true;
                }
            }
            return false;
        }
        private bool TwoPair()
        {
            int highCard = 6;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 2; j < 3; j++)
                {
                    highCard -= 2;
                    if (i == 1) j++;
                    if (cards[i].MyValue == cards[i+1].MyValue && cards[j].MyValue == cards[j+1].MyValue)
                    {
                        handValue.Total = ((int)cards[i].MyValue * 2) + ((int)cards[j].MyValue * 2);
                        handValue.HighCard = (int)cards[highCard].MyValue;
                        return true;
                    }
                }
            }
            return false;
        }
        private bool OnePair()
        {
            for (int i = 0; i < cards.Length-1; i++)
            {
                if (cards[i].MyValue == cards[i+1].MyValue)
                {
                    handValue.Total = (int)cards[i].MyValue * 2;
                    handValue.HighCard = i + 1 == 4 ? (int)cards[2].MyValue : (int)cards[4].MyValue;
                    return true;
                }
            }
            return false;
        }
    }
}
