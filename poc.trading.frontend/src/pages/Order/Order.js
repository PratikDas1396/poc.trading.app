import { useContext, useMemo, useState } from "react";
import { Button } from "../../components/Button";
import { StockContext } from "../../context/stockContext";
import useApiHandle from "../../hooks/useApiHandler";
import API from "../../utils/ApiAxios";

export default function Order() {
  const [, fetchData] = useApiHandle();
  const { selectedStock, loginDetails, getWatchList, setSelectedStock } =
    useContext(StockContext);

  const [quantity, setQuantity] = useState(selectedStock?.availableQuantity);

  const quantityIsGraterThanTotal = useMemo(
    () => quantity > selectedStock?.totalQuantity,
    [quantity, selectedStock]
  );

  if (!selectedStock) return null;

  const { name, price, totalQuantity, id } = selectedStock;

  const handleSubmit = () => {
    fetchData(
      () =>
        API.post("api/Order/create", {
          stockId: id,
          id: loginDetails.id,
          userId: loginDetails.id,
          quantity,
          price,
        }),
      () => {
        getWatchList();
        setSelectedStock(null);
      },
      { successMsg: "Order successfully created!" }
    );
  };

  return (
    <div className="border-2 border-gray-50 border-solid rounded-md">
      <div className="text-left border-b-2 p-3">
        <div className="font-semibold">{name}</div>
        <div>{`Rs ${price} / per unit`}</div>
      </div>
      <div className="p-3 h-[300px]">
        <div className="flex justify-between flex-col	 mb-2">
          <span className="mt-2">Qty:</span>
          <div className="">
            <input
              value={quantity}
              type="number"
              className="block border-2 p-2 rounded-md w-full"
              onChange={(e) =>
                e.target.value >= 0 && setQuantity(e.target.value)
              }
            />
            {quantityIsGraterThanTotal && (
              <label className="text-xs text-red-500 font-semibold">{`quantity should be less than ${totalQuantity}`}</label>
            )}
          </div>
        </div>
        {quantity && (
          <div className="flex justify-between ">
            <span>Total Price:</span>
            <span>Rs. {price * quantity} </span>
          </div>
        )}
      </div>
      <div className="border-t-2 p-3">
        <Button
          disabled={quantityIsGraterThanTotal}
          name="Buy"
          className={"w-full"}
          onClick={handleSubmit}
        />
      </div>
    </div>
  );
}
