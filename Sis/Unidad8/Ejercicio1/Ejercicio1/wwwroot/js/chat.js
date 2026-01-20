"use strict";

import { clsMensajeUsuario } from './clsMensajeUsuario.js';

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("RecibirMensaje", function (mensajeObj) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${mensajeObj.nombre} says ${mensajeObj.mensaje}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    var mensajeUsuario = new clsMensajeUsuario(user, message);

    connection.invoke("EnviarMensaje", {
        nombre: mensajeUsuario.getNombre(),
        mensaje: mensajeUsuario.getMensaje()
    }).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});