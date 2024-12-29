import StockItem from "../../components/SockItem";
import { StockContext } from "../../context/stockContext";
import { useContext, useEffect } from "react";
import axios from "axios";
import { AddToWatchListIcon } from "../../components/Icons";
import { authGetApi, authPostApi } from "../../utils/Api";

export default function StockList() {
  const stockContext = useContext(StockContext);

  useEffect(() => {
    (async () => {
      const res = await authGetApi({ url: `/api/stock/GetAll` });
      console.log({ res });
      stockContext.setStockList(res);
    })();
  }, []);

  const handleAddToWatchList = async () => {
    const res = await authPostApi({
      url: `/api/Watchlist/add`,
      payload: {
        userId: "2290ca93-5e08-4263-a8f3-30032c41bc8a",
        stockId: "171d9ec5-0ba5-4eb0-abbc-4ddaa0402cdb",
      },
    });
    console.log({ res });
  };

  return (
    <div className="w-[40%] m-auto">
      <StockItem
        action={
          <AddToWatchListIcon
            onClick={handleAddToWatchList}
            className="cursor-pointer stroke-2 stroke-indigo-500 hover:stroke-green-500"
          />
        }
      />
    </div>
  );
}
