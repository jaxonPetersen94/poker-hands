import styled from "styled-components";

export const HomeContainer = styled.div`
  height: 100vh;
  display: flex;
  flex-direction: column;
`;

export const TitleContainer = styled.div`
  display: block;
  text-align: center;
  padding: 40px 0 0 0;
`;
export const Title = styled.h1`
  color: white;
  font-size: 32pt;
`;

export const BodyContainer = styled.div`
  height: 100%;
  display: block;
`;

export const GameScaler = styled.div`
  width: 64%;
  margin: 40px auto;
  display: flex;
  min-width: 512px;
  justify-content: center;
  align-items: center;
  position: relative;
  &:after {
    padding-top: 56.25%;
    display: block;
    content: "";
  }
  border-radius: 16px;
  background-color: #2a513e;
`;

export const GameContainer = styled.div`
  height: 96%;
  width: 96%;
  position: absolute;
`;
