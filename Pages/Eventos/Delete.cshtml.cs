using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;
using Microsoft.EntityFrameworkCore;

namespace SportfieldbookingWEB1.Pages.Eventos
{
    public class DeleteModel : PageModel
    {
		private readonly SportFieldContext _context;
		public DeleteModel(SportFieldContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Evento Evento { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var evento = await _context.Eventos.FirstOrDefaultAsync(m => m.Id == id);


			if (evento == null)
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

			var evento = await _context.Eventos.FindAsync(id);

			if (evento != null)
			{
				Evento = evento;
				_context.Eventos.Remove(Evento);
				await _context.SaveChangesAsync();

			}

			return RedirectToPage("./Index");
		}
	}
}
