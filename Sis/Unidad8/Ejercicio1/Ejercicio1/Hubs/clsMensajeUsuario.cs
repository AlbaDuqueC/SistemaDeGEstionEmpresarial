namespace SignalRChat.Hubs
{
    public class clsMensajeUsuario
    {

        public string usuario {  get; set; }
        public string mensaje { get; set; }

        private clsMensajeUsuario()
        {
            this.usuario = "";
            this.mensaje = "";
        }
        private clsMensajeUsuario(string usuario, string mensaje)
        {
            this.usuario=usuario;
            this.mensaje=mensaje;
        }
      
    }
}
