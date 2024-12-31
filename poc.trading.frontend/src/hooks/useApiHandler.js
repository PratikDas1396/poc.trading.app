import { useContext, useState } from "react";
import { StockContext } from "../context/stockContext";
import { StatusConstant } from "../components/Alert";
import { useNavigate } from "react-router";

export default function useApiHandle() {
  const navigate = useNavigate();
  const { setAlert, setLoginDetails } = useContext(StockContext);
  const [isLoading, setLoading] = useState(false);
  const [dataLocal, setLocalData] = useState(null);

  const fetchData = async (callback, setData, params = {}) => {
    const { successMsg, errorMsg = "Something went wrong!" } = params;
    try {
      setLoading(true);
      const res = await callback();
      setData?.(res.data);
      setLocalData(res.data);
      setLoading(false);
      console.log({ successMsg });
      if (successMsg) {
        setAlert({
          status: StatusConstant.success,
          content: successMsg,
        });
      }
      return {
        data: res.data,
        isError: false,
      };
    } catch (err) {
      setLoading(false);
      setAlert({
        status: StatusConstant.error,
        content: errorMsg,
      });
      if (err.status === 401) {
        setLoginDetails?.(null);
        localStorage.clear();
        navigate("/login");
      }
      return {
        isError: true,
      };
    }
  };

  return [isLoading, fetchData, dataLocal];
}
