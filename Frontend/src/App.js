import React from "react";
import Home from "./pages/home/Home";
import { ContextProvider } from "./context/Context";

function App() {
  return (
    <ContextProvider>
      <Home />
    </ContextProvider>
  );
}

export default App;
