namespace SportfieldbookingWEB1.Model
{
    public class Campo
    {
        //hola
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Ubicacion { get; set; }
        public int TarifaHora { get; set; }
        public ICollection<Reserva>? Reservas { get; set; }
        public ICollection<Evento>? Eventos { get; set; }

    }
}
