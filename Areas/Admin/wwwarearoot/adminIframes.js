"use strict";

const connection = new signalR.HubConnectionBuilder()
  .withUrl("/adminChat")
  .build();

const chatDom = document.getElementById("chats");

connection.on("ClientConnected", function(iframeSrc, connectionId) {
  var iframe = document.createElement("iframe");
  iframe.src = iframeSrc;
  iframe.height = "40vh";
  iframe.width = "300px";
  var div = document.createElement("div");
  div.classList.add("col");
  div.id = connectionId;
  div.appendChild(iframe);
  chatDom.appendChild(div);
});

connection.on("ClientDisconnected", function(connectionId) {
  chatDom.querySelectorAll("*").forEach(e => {
    if (e.id === connectionId) {
      e.parentElement.remove();
    }
  });
});

connection
  .start()
  .then(function() {
    setInterval(function() {
      connection
        .invoke("SignalAdminOnline")
        .error(e => alert("connection failed"));
    }, 5000);
  })
  .catch(function(err) {
    return console.error(err.toString());
  });
