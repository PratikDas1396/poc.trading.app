import { useState } from "react";
import Button from "../../components/Button";
import { postApi } from "../../utils/Api";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const navigate = useNavigate();
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async () => {
    const res = await postApi({
      url: "api/User/login",
      payload: {
        userName,
        password,
      },
    });
    console.log({ res });
    if (res.token) {
      localStorage.setItem("token", res.token);
      navigate("/stockList");
    }
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
