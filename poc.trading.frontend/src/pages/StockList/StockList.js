import { useContext, useEffect } from "react";
import { LinkButton } from "../../components/Button";
import Table from "../../components/Table";
import { StockContext } from "../../context/stockContext";
import API from "../../utils/ApiAxios";
import useApiHandle from "../../hooks/useApiHandler";

export default function StockList() {
  const { stockList, setStockList, loginDetails } = useContext(StockContext);
  const [, fetchData] = useApiHandle();

  useEffect(() => {
    fetchData(() => API.get(`/api/stock/GetAll`), setStockList);
  }, []);

  const handleAddToWatchList = ({ id }) => {
    fetchData(
      () =>
        API.post(`/api/Watchlist/add`, {
          userId: loginDetails.id,
          stockId: id,
        }),
      null,
      { successMsg: "Stock successfully added to watch list" }
    );
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
            name="Add"
            onClick={() => handleAddToWatchList(item)}
            className="cursor-pointer font-medium text-indigo-500 hover:text-green-500"
          />
        </div>
      ),
    },
  ];

  return (
    <div className="w-[40%] m-auto">
      <Table columnDefs={columnDefs} data={stockList} />
    </div>
  );
}
