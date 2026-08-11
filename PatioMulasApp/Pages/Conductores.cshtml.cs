using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatioMulasApp.Data;
using PatioMulasApp.Models;

namespace PatioMulasApp.Pages
{
    public class ConductoresModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ConductoresModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conductor Conductor { get; set; } = new Conductor();

        public List<Conductor> Conductores { get; set; } = new List<Conductor>();

        [BindProperty(SupportsGet = true)]
        public string? Buscar { get; set; }

        public void OnGet()
        {
            CargarConductores();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CargarConductores();
                return Page();
            }

            _context.Conductores.Add(Conductor);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditarAsync(int id)
        {
            var conductor = await _context.Conductores.FindAsync(id);

            if (conductor == null)
            {
                return NotFound();
            }

            Conductor = conductor;

            CargarConductores();

            return Page();
        }

        public async Task<IActionResult> OnPostGuardarCambiosAsync()
        {
            if (!ModelState.IsValid)
            {
                CargarConductores();
                return Page();
            }

            var conductorExistente =
                await _context.Conductores.FindAsync(Conductor.Id);

            if (conductorExistente == null)
            {
                return NotFound();
            }

            conductorExistente.Cedula = Conductor.Cedula;
            conductorExistente.Nombre = Conductor.Nombre;
            conductorExistente.Apellido = Conductor.Apellido;
            conductorExistente.Telefono = Conductor.Telefono;
            conductorExistente.Estado = Conductor.Estado;

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            var conductor =
                await _context.Conductores.FindAsync(id);

            if (conductor == null)
            {
                return NotFound();
            }

            _context.Conductores.Remove(conductor);

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        private void CargarConductores()
        {
            if (string.IsNullOrWhiteSpace(Buscar))
            {
                Conductores = _context.Conductores.ToList();
            }
            else
            {
                Conductores = _context.Conductores
                    .Where(c =>
                        c.Cedula.Contains(Buscar) ||
                        c.Nombre.Contains(Buscar) ||
                        c.Apellido.Contains(Buscar))
                    .ToList();
            }
        }
    }
}