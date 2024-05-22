namespace SportfieldbookingWEB1.Model
{
    public class Pago
    {
        public int Id { get; set; }
        public int Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
    }
}
