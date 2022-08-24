import React, { useContext } from "react";
import { PlayerName, CardContainer, TableCenterContainer } from "./Game.styled";
import { InteractionButton } from "../interaction/Interaction.styled";
import Cards from "../../components/cards/Cards";
import { Context } from "../../context/Context";
import { evaluateCardsCall, getCardsAgainCall } from "../../ApiCalls";

function Game() {
  const {
    playerOneHand,
    playerTwoHand,
    isWinner,
    winnerName,
    winnerHandType,
    winnerHighCard,
    dispatch,
  } = useContext(Context);

  const evaluateCards = () => {
    const pokerHands = [{ ...playerOneHand }, { ...playerTwoHand }];
    evaluateCardsCall(pokerHands, dispatch);
  };

  const dealAgain = () => {
    getCardsAgainCall(dispatch);
  };

  return (
    <>
      <PlayerName>{playerOneHand.playerName}</PlayerName>
      <CardContainer>
        <Cards {...playerOneHand} />
      </CardContainer>
      <TableCenterContainer>
        {isWinner ? (
          <>
            <>
              {`Winner: ${winnerName}!`}
              {winnerHandType !== "" && (
                <>
                  <br />
                  {`Hand: ${winnerHandType}`}
                </>
              )}
              {winnerHighCard !== "0" && (
                <>
                  <br />
                  {`High-Card: ${winnerHighCard}`}
                </>
              )}
            </>
            <br />
            <br />
            <InteractionButton style={{ height: "25%", width: "20%" }} onClick={dealAgain}>
              Deal Again?
            </InteractionButton>
          </>
        ) : (
          <InteractionButton style={{ height: "25%", width: "16%" }} onClick={evaluateCards}>
            Evaluate
          </InteractionButton>
        )}
      </TableCenterContainer>
      <PlayerName>{playerTwoHand.playerName}</PlayerName>
      <CardContainer>
        <Cards {...playerTwoHand} />
      </CardContainer>
    </>
  );
}

export default Game;
