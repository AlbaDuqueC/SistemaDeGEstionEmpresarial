namespace SignalRChat.wwwroot.js
{
   // wwwroot/js/clsMensajeUsuario.js
export class clsMensajeUsuario {
    constructor(nombre, mensaje) {
        this.nombre = nombre;
        this.mensaje = mensaje;
    }

    getNombre() {
        return this.nombre;
    }

    setNombre(nombre) {
        this.nombre = nombre;
    }

    getMensaje() {
        return this.mensaje;
    }

    setMensaje(mensaje) {
        this.mensaje = mensaje;
    }
}
}
