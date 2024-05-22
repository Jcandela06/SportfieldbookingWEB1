namespace SportfieldbookingWEB1.Model
{
    public class Evento
    {
        public int Id { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Descripcion { get; set; }
    }
}
