"use strict";

const connection = new signalR.HubConnectionBuilder()
  .withUrl("/adminChat")
  .build();

function sendMessage(message) {
  connection.invoke("SendMessage", message).catch(function(err) {
    return console.error(err.toString());
  });
}
var connectionId = document.getElementById("");
function sendMessageFromAdmin(message) {}

setAdminOnline(false);
function initialize() {}

function receiveMessage(user, message) {}

function setAdminOnline(adminOnline) {
  var domElement = document.getElementById("adminOnline");
  if (adminOnline) {
    domElement.innerText = "Admin er online";
  } else {
    domElement.innerText = "Admin er ikke online";
  }
}

connection.on("ReceiveMessage", function(user, message) {
  var domElement = document.getElementById("messageList");
  var child = document.createElement("div");
  child.className = "chat-bubble";
  child.innerHTML = message;
  domElement.appendChild(child);
});

var adminOnlineTimeout;
connection.on("SignalAdminOnline", function() {
  setAdminOnline(true);
  if (adminOnlineTimeout) clearTimeout(adminOnlineTimeout);
  setTimeout(() => setAdminOnline(false), 6000);
});

connection
  .start()
  .then(initialize)
  .catch(function(err) {
    return console.error(err.toString());
  });

document
  .getElementById("sendButton")
  .addEventListener("click", function(event) {
    var message = getMessageFromForm();
    sendMessage(message);
  });

// Setup rich text editor
tinymce.init({
  selector: "#editor"
});
function getMessageFromForm() {
  return tinymce.get("editor").getContent();
}
