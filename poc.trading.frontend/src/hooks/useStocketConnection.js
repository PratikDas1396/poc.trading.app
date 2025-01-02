import {
  HttpTransportType,
  HubConnectionBuilder,
  LogLevel,
} from "@microsoft/signalr";

export default function useSocketConnection() {
  const initializeConn = async () => {
    try {
      const conn = new HubConnectionBuilder()
        .withUrl(`https://sr.avyanz.in/trading-app/tradingHub`, {
          //   skipNegotiation: true, // skipNegotiation as we specify WebSockets
          transport:
            HttpTransportType.WebSockets |
            HttpTransportType.ServerSentEvents |
            HttpTransportType.LongPolling,
          withCredentials: true,
          accessTokenFactory: () => localStorage.getItem("token"),
        })
        .configureLogging(LogLevel.Information)
        .build();

      conn.on("stock-update", (data, msg) => {
        console.log({ data, msg });
      });

      await conn.start();
      //   await conn.invoke("stock-update");
    } catch (error) {
      console.log({ error });
    }
  };

  return [initializeConn];
}
