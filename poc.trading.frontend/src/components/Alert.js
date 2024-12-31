import { useContext, useEffect } from "react";
import { StockContext } from "../context/stockContext";

export const StatusConstant = {
  success: "text-green-500 shadow-green-100 border-2 border-green-200",
  error: "text-red-500 shadow-red-100 border-2 border-red-200",
};
export default function Alert() {
  const { alert, setAlert } = useContext(StockContext);
  const { status, content } = alert ?? {};

  useEffect(() => {
    const timer = setTimeout(() => setAlert(null), 2000);
    return () => clearTimeout(timer);
  }, [alert]);

  return status ? (
    <div className="absolute w-full ">
      <div
        className={`mt-[75px] p-3 m-4 rounded-md float-right w-[30%] shadow-lg bg-white ${status}`}>
        {content}
      </div>
    </div>
  ) : (
    <></>
  );
}
