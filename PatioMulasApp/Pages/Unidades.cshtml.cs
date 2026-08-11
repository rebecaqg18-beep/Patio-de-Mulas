using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatioMulasApp.Data;
using PatioMulasApp.Models;

namespace PatioMulasApp.Pages
{
    public class UnidadesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UnidadesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Unidad Unidad { get; set; } = new Unidad();

        public List<Unidad> Unidades { get; set; } = new List<Unidad>();

        [BindProperty(SupportsGet = true)]
        public string? BuscarPlaca { get; set; }

        public void OnGet()
        {
            CargarUnidades();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CargarUnidades();
                return Page();
            }

            _context.Unidades.Add(Unidad);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditarAsync(int id)
        {
            var unidad = await _context.Unidades.FindAsync(id);

            if (unidad == null)
            {
                return NotFound();
            }

            Unidad = unidad;

            CargarUnidades();

            return Page();
        }

        public async Task<IActionResult> OnPostGuardarCambiosAsync()
        {
            if (!ModelState.IsValid)
            {
                CargarUnidades();
                return Page();
            }

            var unidadExistente = await _context.Unidades.FindAsync(Unidad.Id);

            if (unidadExistente == null)
            {
                return NotFound();
            }

            unidadExistente.Placa = Unidad.Placa;
            unidadExistente.Marca = Unidad.Marca;
            unidadExistente.Modelo = Unidad.Modelo;
            unidadExistente.Año = Unidad.Año;
            unidadExistente.Estado = Unidad.Estado;

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            var unidad = await _context.Unidades.FindAsync(id);

            if (unidad == null)
            {
                return NotFound();
            }

            _context.Unidades.Remove(unidad);

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        private void CargarUnidades()
        {
            if (string.IsNullOrWhiteSpace(BuscarPlaca))
            {
                Unidades = _context.Unidades.ToList();
            }
            else
            {
                Unidades = _context.Unidades
                    .Where(u => u.Placa.Contains(BuscarPlaca))
                    .ToList();
            }
        }
    }
}