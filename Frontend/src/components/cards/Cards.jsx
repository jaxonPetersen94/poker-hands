import React from "react";
import { Card } from "./Cards.styled";

function Cards(playerHand) {
  return playerHand.cards.map((card) => {
    return (
      <Card key={card.id}>
        {card.myValue}
        <br />
        {card.mySuit}
      </Card>
    );
  });
}

export default Cards;
