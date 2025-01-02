import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter, Route, Routes } from "react-router";
import { StockContextProvider } from "./context/stockContext";
import "./index.css";
import HomePage from "./pages/Home/Home";
import Login from "./pages/Login/Login";
import StockList from "./pages/StockList/StockList";
import WatchList from "./pages/WatchList/WatchList";
// import { socketConnection } from "./signalR";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <StockContextProvider>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/" element={<HomePage />}>
            <Route index element={<StockList />} />
            <Route path="/watch-list" element={<WatchList />} />
            <Route path="*" element={<StockList />} />
          </Route>
        </Routes>
      </StockContextProvider>
    </BrowserRouter>
  </React.StrictMode>
);
