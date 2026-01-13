using System.ComponentModel;

namespace unam.Application.DTOs
{
    public class SolicitudDTO
    {

        public int Id { get; set; }
        public string TipoSolicitud { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;

        public int Edad { get; set; }

        public string NoDocumento { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;

        public string Padres { get; set; } = string.Empty;

        public string Domicilio { get; set; } = string.Empty;

        public string NumeroTelefono { get; set; } = string.Empty;

        [DefaultValue(false)]
        public bool IsAprobada { get; set; } = false; //verificar si la solicitud fue aprobada
        public DateTime FechaSolicitud { get; set; }
        //propiedad de navegacion
        public int UsuarioID { get; set; }

    }
}


