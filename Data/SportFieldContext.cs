using Microsoft.EntityFrameworkCore;
using SportfieldbookingWEB1.Model;

namespace SportfieldbookingWEB1.Data
{
    public class SportFieldContext:DbContext
    {
        public SportFieldContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Campo> Campos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Pago> Pagos { get; set; }




    }
}
