﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, itemId) {
    var li = document.createElement("li");
    
    var thisItemId = document.getElementById("itemId").value;
    var commentsList = document.getElementById("messagesList");
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    if (itemId == thisItemId) {
        commentsList.appendChild(li);
        li.textContent = `${user}: ${message}`;
        document.getElementById("messageInput").value = '';
        
        commentsList.scrollTop = commentsList.scrollHeight;
    }
    
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var itemId = document.getElementById("itemId").value;
    connection.invoke("SendMessage", user, message, itemId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});