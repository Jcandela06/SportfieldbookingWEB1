using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;

namespace SportfieldbookingWEB1.Pages.Pagos
{
    public class EditModel : PageModel
    {
		private readonly SportFieldContext _context;

		public EditModel(SportFieldContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Pago Pago { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Pagos == null)
			{
				return NotFound();
			}

			var pago = await _context.Pagos.FirstOrDefaultAsync(m => m.Id == id);
			if (pago == null)
			{
				return NotFound();
			}
			Pago = pago;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Pago).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CategoryExists(Pago.Id))
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

		private bool CategoryExists(int id)
		{
			return (_context.Pagos?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
