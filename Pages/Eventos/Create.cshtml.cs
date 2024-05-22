using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;

namespace SportfieldbookingWEB1.Pages.Eventos
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
		public Evento Evento { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Eventos == null || Evento == null)
			{
				return Page();
			}

			_context.Eventos.Add(Evento);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
