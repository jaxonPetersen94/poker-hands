import React, { useContext } from "react";
import { InteractionContainer, InteractionWindow, InteractionButton } from "./Interaction.styled";
import { Context } from "../../context/Context";
import { getCardsCall } from "../../ApiCalls";

function Interaction() {
  const { dispatch } = useContext(Context);

  const handleClick = () => {
    getCardsCall(dispatch);
  };

  return (
    <InteractionContainer>
      <InteractionWindow>
        <InteractionButton style={{ height: "30%", width: "56.5%" }} onClick={handleClick}>
          Deal Cards
        </InteractionButton>
      </InteractionWindow>
    </InteractionContainer>
  );
}

export default Interaction;
