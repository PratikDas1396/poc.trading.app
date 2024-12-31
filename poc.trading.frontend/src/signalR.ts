const signalR = require("@microsoft/signalr");

export const socketConnection = new signalR.HubConnectionBuilder()
  .withUrl("/tradingHub")
  .build();

socketConnection.on("send", (data) => {
  console.log(data);
});

socketConnection.start().then(() => socketConnection.invoke("send", "Hello"));
