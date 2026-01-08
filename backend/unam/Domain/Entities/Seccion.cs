namespace unam.Domain.Entities
{
    public class Seccion
    {
        public int Id { get; set; }

        public string NombreSeccion { get; set; } = string.Empty;

        public int CupoDisponible { get; set; }
        public int? MaestroAsignadoId { get; set; }
        public Maestro? Maestro { get; set; } 

    }
}
