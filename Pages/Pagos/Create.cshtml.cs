using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;

namespace SportfieldbookingWEB1.Pages.Pagos
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
		public Pago Pago { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Pagos == null || Pago == null)
			{
				return Page();
			}

			_context.Pagos.Add(Pago);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
