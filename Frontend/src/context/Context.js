import { createContext, useReducer } from "react";
import Reducer from "./Reducer";

const INITIAL_STATE = {
  cardsDealt: false,
  playerOneHand: [],
  playerTwoHand: [],
  isWinner: false,
  winnerName: "",
  winnerHandType: "",
  winnerHighCard: "",
  isFetching: false,
  error: false,
};

export const Context = createContext(INITIAL_STATE);

export const ContextProvider = ({ children }) => {
  const [state, dispatch] = useReducer(Reducer, INITIAL_STATE);

  return (
    <Context.Provider
      value={{
        cardsDealt: state.cardsDealt,
        playerOneHand: state.playerOneHand,
        playerTwoHand: state.playerTwoHand,
        isWinner: state.isWinner,
        winnerName: state.winnerName,
        winnerHandType: state.winnerHandType,
        winnerHighCard: state.winnerHighCard,
        isFetching: state.isFetching,
        error: state.error,
        dispatch,
      }}
    >
      {children}
    </Context.Provider>
  );
};
