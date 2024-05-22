namespace SportfieldbookingWEB1.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Estado { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}
