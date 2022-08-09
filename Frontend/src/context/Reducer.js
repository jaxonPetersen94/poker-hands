const Reducer = (state, action) => {
  switch (action.type) {
    case "GET_CARDS":
      return {
        ...state,
        cardsDealt: false,
        isFetching: true,
        error: false,
      };
    case "GET_CARDS_SUCCESS":
      return {
        ...state,
        cardsDealt: true,
        playerOneHand: action.payload[0],
        playerTwoHand: action.payload[1],
        isFetching: false,
        error: false,
      };
    case "GET_CARDS_FAILURE":
      return {
        ...state,
        cardsDealt: false,
        playerOneHand: [],
        playerTwoHand: [],
        isFetching: false,
        error: action.payload,
      };
    case "EVALUATE_CARDS":
      return {
        ...state,
        isFetching: true,
        error: false,
      };
    case "EVALUATE_CARDS_SUCCESS":
      return {
        ...state,
        isWinner: action.payload.isWinner,
        winnerName: action.payload.winnerName,
        winnerHandType: action.payload.winnerHandType,
        winnerHighCard: action.payload.winnerHighCard,
        isFetching: false,
        error: false,
      };
    case "EVALUATE_CARDS_FAILURE":
      return {
        ...state,
        isWinner: false,
        isFetching: false,
        error: action.payload,
      };
    case "GET_CARDS_AGAIN":
      return {
        ...state,
        cardsDealt: false,
        isWinner: false,
        isFetching: true,
        error: false,
      };
    case "GET_CARDS_AGAIN_SUCCESS":
      return {
        ...state,
        cardsDealt: true,
        playerOneHand: action.payload[0],
        playerTwoHand: action.payload[1],
        isFetching: false,
        error: false,
      };
    case "GET_CARDS_AGAIN_FAILURE":
      return {
        ...state,
        cardsDealt: false,
        isFetching: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default Reducer;
