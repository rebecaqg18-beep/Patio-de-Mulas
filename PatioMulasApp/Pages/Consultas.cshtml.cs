using Microsoft.AspNetCore.Mvc.RazorPages;
using PatioMulasApp.Data;
using PatioMulasApp.Models;

namespace PatioMulasApp.Pages
{
    public class ConsultasModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ConsultasModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

        public List<Unidad> Unidades { get; set; } = new List<Unidad>();

        public List<Conductor> Conductores { get; set; } = new List<Conductor>();

        public string Tipo { get; set; } = "";


        public void OnGet(string Tipo)
        {
            this.Tipo = Tipo ?? "";

            Unidades = _context.Unidades.ToList();

            Conductores = _context.Conductores.ToList();

            var consulta = _context.Movimientos.AsQueryable();

            if (!string.IsNullOrEmpty(this.Tipo))
            {
                consulta = consulta.Where(m =>
                    m.TipoMovimiento == this.Tipo);
            }

            Movimientos = consulta
                .OrderByDescending(m => m.FechaHora)
                .ToList();
        }
    }
}