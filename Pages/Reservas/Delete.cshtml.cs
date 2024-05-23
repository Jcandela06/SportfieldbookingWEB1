using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;
using Microsoft.EntityFrameworkCore;

namespace SportfieldbookingWEB1.Pages.Reservas
{
    public class DeleteModel : PageModel
    {
		private readonly SportFieldContext _context;
		public DeleteModel(SportFieldContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Reserva Reserva { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var reserva = await _context.Reservas.FirstOrDefaultAsync(m => m.Id == id);


			if (reserva == null)
			{
				return NotFound();
			}

			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var reserva = await _context.Reservas.FindAsync(id);

			if (reserva != null)
			{
				Reserva = reserva;
				_context.Reservas.Remove(Reserva);
				await _context.SaveChangesAsync();

			}

			return RedirectToPage("./Index");
		}
	}
}
