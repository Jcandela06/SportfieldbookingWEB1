using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;

namespace SportfieldbookingWEB1.Pages.Clientes
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
		public Cliente Cliente { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Clientes == null || Cliente == null)
			{
				return Page();
			}

			_context.Clientes.Add(Cliente);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
