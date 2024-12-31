import { useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button } from "../../components/Button";
import { StockContext } from "../../context/stockContext";
import useApiHandle from "../../hooks/useApiHandler";
import API from "../../utils/ApiAxios";

export default function Login() {
  const { setLoginInfo } = useContext(StockContext);
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [, fetchData] = useApiHandle();

  const handleLogin = async () => {
    fetchData(
      () => API.post("api/User/login", { userName, password }),
      (data) => setLoginInfo(data, { userName })
    );
  };

  return (
    <div className="flex justify-center p-52 h-full">
      <div className="w-[30%] m-auto">
        <div className="flex justify-between mb-3">
          <span>Username</span>
          <input
            type="text"
            className="border-2 p-1 rounded-md"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
          />
        </div>
        <div className="flex justify-between mb-3">
          <span>Password</span>
          <input
            type="password"
            className="border-2 p-1 rounded-md"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <Button
          disabled={!userName || !password}
          name="Login"
          className="w-full mt-8 bg-blue-500"
          onClick={handleLogin}
        />
      </div>
    </div>
  );
}
