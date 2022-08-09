export const GetCards = () => ({
  type: "GET_CARDS",
});

export const GetCardsSuccess = (cards) => ({
  type: "GET_CARDS_SUCCESS",
  payload: cards,
});

export const GetCardsFailure = (error) => ({
  type: "GET_CARDS_FAILURE",
  payload: error,
});

export const EvaluateCards = (cards) => ({
  type: "EVALUATE_CARDS",
});

export const EvaluateCardsSuccess = (winner) => ({
  type: "EVALUATE_CARDS",
  payload: winner,
});

export const EvaluateCardsFailure = (error) => ({
  type: "EVALUATE_CARDS_FAILURE",
  payload: error,
});
