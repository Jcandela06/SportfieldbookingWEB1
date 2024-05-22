using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportfieldbookingWEB1.Data;
using SportfieldbookingWEB1.Model;

namespace SportfieldbookingWEB1.Pages.Pagos
{
    public class IndexModel : PageModel
    {
        private readonly SportFieldContext _context;
        public IndexModel(SportFieldContext context)
        {
            _context = context;
        }
        public IList<Pago> Pagos { get; set; }
        public async Task OnGetAsync()
        {
            //if (_context.Categories != null)
            //{
            Pagos = await _context.Pagos.ToListAsync();
            //}
        }
    }
}
