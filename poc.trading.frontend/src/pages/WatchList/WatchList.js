import { useContext, useEffect } from "react";
import { LinkButton } from "../../components/Button";
import Table from "../../components/Table";
import { StockContext } from "../../context/stockContext";
import useApiHandle from "../../hooks/useApiHandler";
import API from "../../utils/ApiAxios";
import Order from "../Order/Order";

export default function WatchList() {
  const {
    watchList,
    setWatchList,
    loginDetails,
    setSelectedStock,
    getWatchList,
  } = useContext(StockContext);
  const [, fetchData] = useApiHandle();

  useEffect(() => {
    console.log("loginDetails", loginDetails);
    if (loginDetails) fetchData(getWatchList, setWatchList);
  }, [loginDetails]);

  const handleDelete = async ({ id }) => {
    const data = await fetchData(() => {
      return API.post(`/api/Watchlist/delete`, {
        userId: loginDetails.id,
        stockId: id,
      });
    });
    if (!data.isError) {
      fetchData(getWatchList, setWatchList, {
        successMsg: "Stock deleted from watch list",
      });
    }
  };

  const columnDefs = [
    {
      title: "Stock name",
      field: "name",
    },
    {
      title: "Price",
      field: "price",
      cellRenderer: (item) => <label>{`Rs ${item.price}`}</label>,
      align: "right",
      width: "5",
    },
    {
      title: "Total quantity",
      field: "totalQuantity",
      align: "right",
    },
    {
      title: "Available quantity",
      field: "availableQuantity",
      align: "right",
    },
    {
      title: "",
      field: "id",
      cellRenderer: (item) => (
        <div className="w-full flex justify-center">
          <LinkButton
            name="Delete"
            onClick={() => handleDelete(item)}
            className="cursor-pointer font-medium text-red-500 hover:text-red-300"
          />
        </div>
      ),
    },
  ];

  const handleRowClick = (data) => setSelectedStock(data);

  return (
    <div className="flex mx-auto w-[60%] gap-5">
      <div className="w-[60%]">
        <Table
          columnDefs={columnDefs}
          data={watchList}
          onRowClick={handleRowClick}
        />
      </div>
      <div className="w-[40%]">
        <Order />
      </div>
    </div>
  );
}
