using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatioMulasApp.Data;
using PatioMulasApp.Models;

namespace PatioMulasApp.Pages
{
    public class MovimientosModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MovimientosModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movimiento Movimiento { get; set; } = new Movimiento();

        public List<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

        public List<Unidad> Unidades { get; set; } = new List<Unidad>();

        public List<Conductor> Conductores { get; set; } = new List<Conductor>();


        public void OnGet()
        {
            CargarDatos();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CargarDatos();
                return Page();
            }

            _context.Movimientos.Add(Movimiento);

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }


        private void CargarDatos()
        {
            Unidades = _context.Unidades.ToList();

            Conductores = _context.Conductores.ToList();

            Movimientos = _context.Movimientos
                .OrderByDescending(m => m.FechaHora)
                .ToList();
        }
    }
}