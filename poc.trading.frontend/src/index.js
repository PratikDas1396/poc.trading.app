import React, { useEffect } from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter, Outlet, Route, Routes } from "react-router";
import Header from "./components/Header";
import { StockContextProvider } from "./context/stockContext";
import "./index.css";
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

function HomePage() {
  // useEffect(() => {
  //   socketConnection.on("send", (data) => {
  //     console.log(data);
  //   });

  //   socketConnection
  //     .start()
  //     .then(() => socketConnection.invoke("send", "Hello"));
  // }, []);

  return (
    <>
      <Header />
      <Outlet />
    </>
  );
}
