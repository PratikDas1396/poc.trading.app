import { useContext } from "react";
import { useNavigate } from "react-router";
import { StockContext } from "../context/stockContext";

const NavMenu = [
  {
    name: "Stock list",
    path: "/stock-list",
  },
  {
    name: "Watch list",
    path: "/watch-list",
  },
];

export default function Header() {
  const navigate = useNavigate();
  const { handleLogout } = useContext(StockContext);

  return (
    <div className="grid grid-cols-12 p-4 sticky top-0 border-b border-b-gray-300 mb-5 bg-white">
      <div className="col-span-1">
        <h4 className="">Trading app</h4>
      </div>
      <div className="col-span-10">
        {NavMenu?.map((menu) => (
          <label
            key={menu.name}
            className="cursor-pointer hover:text-gray-600 px-4"
            onClick={() => {
              navigate(menu.path);
            }}>
            {menu.name}
          </label>
        ))}
      </div>
      <div className="col-span-1 text-right">
        <label
          className="cursor-pointer hover:text-gray-600"
          onClick={handleLogout}>
          Logout
        </label>
      </div>
    </div>
  );
}
