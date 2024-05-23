using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SportfieldbookingWEB1.Pages.Reservas
{
    [Authorize]
    public class IndexModel : PageModel
    {
		private readonly SportFieldContext _context;
		public IndexModel(SportFieldContext context)
		{
			_context = context;
		}
		public IList<Reserva> Reservas { get; set; }
		public async Task OnGetAsync()
		{
			//if (_context.Reservas != null)
			//{
			Reservas = await _context.Reservas.ToListAsync();
			//}
		}
	}
}
