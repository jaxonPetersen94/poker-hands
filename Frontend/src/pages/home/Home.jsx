import React, { useContext } from "react";
import {
  HomeContainer,
  TitleContainer,
  Title,
  BodyContainer,
  GameScaler,
  GameContainer,
} from "./Home.styled";
import Game from "../../components/game/Game";
import { Context } from "../../context/Context";
import Interaction from "../../components/interaction/Interaction";

function Home() {
  const { cardsDealt } = useContext(Context);

  return (
    <HomeContainer>
      <TitleContainer>
        <Title>Poker Hands</Title>
      </TitleContainer>
      <BodyContainer>
        <GameScaler>
          <GameContainer>{cardsDealt ? <Game /> : <Interaction />}</GameContainer>
        </GameScaler>
      </BodyContainer>
    </HomeContainer>
  );
}

export default Home;
