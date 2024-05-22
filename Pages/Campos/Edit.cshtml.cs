using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;
using Microsoft.EntityFrameworkCore;

namespace SportfieldbookingWEB1.Pages.Campos
{
    public class EditModel : PageModel
    {
		private readonly SportFieldContext _context;

		public EditModel(SportFieldContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Campo Campo { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Campos == null)
			{
				return NotFound();
			}

			var campo = await _context.Campos.FirstOrDefaultAsync(m => m.Id == id);
			if (campo == null)
			{
				return NotFound();
			}
			Campo = campo;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Attach(Campo).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CampoExists(Campo.Id))
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

		private bool CampoExists(int id)
		{
			return (_context.Campos?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
