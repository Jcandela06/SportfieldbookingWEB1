using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;
using Microsoft.EntityFrameworkCore;

namespace SportfieldbookingWEB1.Pages.Eventos
{
    public class EditModel : PageModel
    {
		private readonly SportFieldContext _context;

		public EditModel(SportFieldContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Evento Evento { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Eventos == null)
			{
				return NotFound();
			}

			var evento = await _context.Eventos.FirstOrDefaultAsync(m => m.Id == id);
			if (evento == null)
			{
				return NotFound();
			}
			Evento = evento;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Evento).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EventoExists(Evento.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool EventoExists(int id)
		{
			return (_context.Eventos?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
