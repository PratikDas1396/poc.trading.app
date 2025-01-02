import React, { createContext, useEffect, useState } from "react";
import { useNavigate } from "react-router";
import Alert from "../components/Alert";
import API from "../utils/ApiAxios";

export const StockContext = createContext();

export const StockContextProvider = (props) => {
  const navigate = useNavigate();

  const [stockList, setStockList] = useState([]);
  const [loginDetails, setLoginDetails] = useState(null);
  const [watchList, setWatchList] = useState([]);
  const [alert, setAlert] = useState(null);
  const [selectedStock, setSelectedStock] = useState(null);

  useEffect(() => {
    const result = localStorage.getItem("user");
    if (!result) {
      navigate("/login");
      return;
    }
    setLoginDetails(JSON.parse(result));
  }, []);

  const handleLogout = () => {
    setLoginDetails(null);
    localStorage.clear();
    navigate("/login");
  };

  const setLoginInfo = async (loginData, { userName }) => {
    if (loginData?.token) {
      localStorage.setItem("token", loginData?.token);
      try {
        const userRes = await API.get(`api/User/${userName}`);
        if (userRes?.data?.id) {
          localStorage.setItem("user", JSON.stringify(userRes.data));
          setLoginDetails(userRes.data);
          navigate("/stock-list");
        }
      } catch (error) {}
    }
  };

  const getWatchList = async () => {
    return await API.get(`/api/Watchlist/${loginDetails.id}`);
  };

  return (
    <StockContext.Provider
      value={{
        stockList,
        setStockList,
        watchList,
        setWatchList,
        alert,
        setAlert,
        loginDetails,
        setLoginInfo,
        selectedStock,
        setSelectedStock,
        getWatchList,
        handleLogout,
      }}>
      <Alert />
      {props.children}
    </StockContext.Provider>
  );
};
