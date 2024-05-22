using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;

namespace SportfieldbookingWEB1.Pages.Campos
{
    public class CreateModel : PageModel
    {
		private readonly SportFieldContext _context;
		public CreateModel(SportFieldContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Campo Campo { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Campos == null || Campo == null)
			{
				return Page();
			}

			_context.Campos.Add(Campo);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
