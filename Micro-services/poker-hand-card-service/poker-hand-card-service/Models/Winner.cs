namespace poker_hand_card_service.Models
{
    public class Winner
    {
        public string WinnerName { get; set; }
        public string WinnerHandType { get; set; }
        public string WinnerHighCard { get; set; }
        public bool IsWinner { get; set; }
    }
}
