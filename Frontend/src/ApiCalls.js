import axios from "axios";

export const getCardsCall = async (dispatch) => {
  dispatch({ type: "GET_CARDS" });
  try {
    const res = await axios.get("/Card");
    dispatch({ type: "GET_CARDS_SUCCESS", payload: res.data });
  } catch (err) {
    dispatch({ type: "GET_CARDS_FAILURE", payload: err });
  }
};

export const evaluateCardsCall = async (pokerHands, dispatch) => {
  dispatch({ type: "EVALUATE_CARDS" });
  try {
    const res = await axios.post("/Card", pokerHands);
    dispatch({ type: "EVALUATE_CARDS_SUCCESS", payload: res.data });
  } catch (err) {
    dispatch({ type: "EVALUATE_CARDS_FAILURE", payload: err });
  }
};

export const getCardsAgainCall = async (dispatch) => {
  dispatch({ type: "GET_CARDS_AGAIN" });
  try {
    const res = await axios.get("/Card");
    dispatch({ type: "GET_CARDS_AGAIN_SUCCESS", payload: res.data });
  } catch (err) {
    dispatch({ type: "GET_CARDS_AGAIN_FAILURE", payload: err });
  }
};
