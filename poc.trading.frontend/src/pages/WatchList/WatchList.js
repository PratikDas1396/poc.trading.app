import { useContext, useEffect } from "react";
import StockItem from "../../components/SockItem";
import { StockContext } from "../../context/stockContext";
import Order from "../Order/Order";
import { DeleteFromWatchListIcon } from "../../components/Icons";
import { authGetApi, authPostApi } from "../../utils/Api";

export default function WatchList() {
  const { watchList, setWatchList } = useContext(StockContext);

  useEffect(() => {
    (async () => {
      const res = await authGetApi({
        url: `/api/Watchlist/2290ca93-5e08-4263-a8f3-30032c41bc8a`,
      });
      console.log({ res });
      setWatchList(res);
    })();
  }, []);

  const handleDelete = async () => {
    const res = await authPostApi({
      url: `/api/Watchlist/delete`,
      payload: {
        userId: "2290ca93-5e08-4263-a8f3-30032c41bc8a",
        stockId: "171d9ec5-0ba5-4eb0-abbc-4ddaa0402cdb",
      },
    });
    console.log({ res });
  };

  return (
    <div className="flex mx-auto w-[60%] gap-5">
      <div className="w-[60%]">
        <StockItem
          action={
            <DeleteFromWatchListIcon
              onClick={handleDelete}
              className="cursor-pointer stroke-2 stroke-red-300 hover:stroke-red-500"
            />
          }
        />
      </div>
      <div className="w-[40%]">
        <Order />
      </div>
    </div>
  );
}
