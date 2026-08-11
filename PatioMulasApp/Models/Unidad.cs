namespace PatioMulasApp.Models
{
    public class Unidad
    {
        public int Id { get; set; }

        public string Placa { get; set; } = "";

        public string Marca { get; set; } = "";

        public string Modelo { get; set; } = "";

        public int Año { get; set; }

        public string Estado { get; set; } = "";
    }
}