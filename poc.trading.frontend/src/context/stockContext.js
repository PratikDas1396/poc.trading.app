import React, { createContext, useState } from "react";

export const StockContext = createContext();

export const StockContextProvider = (props) => {
  const [stockList, setStockList] = useState([]);
  const [watchList, setWatchList] = useState([]);
  return (
    <StockContext.Provider
      value={{
        stockList,
        setStockList,
        watchList,
        setWatchList,
      }}>
      {props.children}
    </StockContext.Provider>
  );
};
