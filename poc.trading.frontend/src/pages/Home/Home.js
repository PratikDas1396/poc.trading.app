import react, { useEffect } from "react";
import { Outlet } from "react-router";
import Header from "../../components/Header";
import useSocketConnection from "../../hooks/useStocketConnection";

export default function HomePage() {
  const [initializeConn] = useSocketConnection();

  useEffect(() => {
    initializeConn();
  }, []);

  return (
    <>
      <Header />
      <Outlet />
    </>
  );
}
