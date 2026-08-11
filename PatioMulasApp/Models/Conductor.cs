namespace PatioMulasApp.Models
{
    public class Conductor
    {
        public int Id { get; set; }

        public string Cedula { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;
    }
}