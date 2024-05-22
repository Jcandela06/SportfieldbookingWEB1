using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;
using Microsoft.EntityFrameworkCore;

namespace SportfieldbookingWEB1.Pages.Reservas
{
    public class EditModel : PageModel
    {
		private readonly SportFieldContext _context;

		public EditModel(SportFieldContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Reserva Reserva { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Reservas == null)
			{
				return NotFound();
			}

			var reserva = await _context.Reservas.FirstOrDefaultAsync(m => m.Id == id);
			if (reserva == null)
			{
				return NotFound();
			}
			Reserva = reserva;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Reserva).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ReservaExists(Reserva.Id))
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

		private bool ReservaExists(int id)
		{
			return (_context.Reservas?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
