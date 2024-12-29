import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import { BrowserRouter, Routes, Route } from "react-router";
import StockList from "./pages/StockList/StockList";
import WatchList from "./pages/WatchList/WatchList";
import Login from "./pages/Login/Login";
import { StockContext, StockContextProvider } from "./context/stockContext";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route
          path="/stockList"
          element={
            <StockContextProvider>
              <StockList />
            </StockContextProvider>
          }
        />
        <Route
          path="/watchList"
          element={
            <StockContextProvider>
              <WatchList />
            </StockContextProvider>
          }
        />
        <Route path="/" element={<App />} />
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);
