using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;
using Microsoft.EntityFrameworkCore;

namespace SportfieldbookingWEB1.Pages.Campos
{
    public class DeleteModel : PageModel
    {
		private readonly SportFieldContext _context;
		public DeleteModel(SportFieldContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Campo Campo { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var campo = await _context.Campos.FirstOrDefaultAsync(m => m.Id == id);


			if (campo == null)
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

			var campo = await _context.Campos.FindAsync(id);

			if (campo != null)
			{
				Campo = campo;
				_context.Campos.Remove(Campo);
				await _context.SaveChangesAsync();

			}

			return RedirectToPage("./Index");
		}
	}
}
