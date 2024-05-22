using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;

namespace SportfieldbookingWEB1.Pages.Pagos
{
    public class DeleteModel : PageModel
    {
		private readonly SportFieldContext _context;
		public DeleteModel(SportFieldContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Pago Pago { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pago = await _context.Pagos.FirstOrDefaultAsync(m => m.Id == id);


			if (pago == null)
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

			var pago = await _context.Pagos.FindAsync(id);

			if (pago != null)
			{
				Pago = pago;
				_context.Pagos.Remove(Pago);
				await _context.SaveChangesAsync();

			}

			return RedirectToPage("./Index");
		}
	}
}
