using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;
using Microsoft.EntityFrameworkCore;

namespace SportfieldbookingWEB1.Pages.Eventos
{
    public class IndexModel : PageModel
    {
        private readonly SportFieldContext _context;
        public IndexModel(SportFieldContext context)
        {
            _context = context;
        }
        public IList<Evento> Eventos { get; set; }
        public async Task OnGetAsync()
        {
            //if (_context.Eventos != null)
            //{
            Eventos = await _context.Eventos.ToListAsync();
            //}
        }
    }
}
