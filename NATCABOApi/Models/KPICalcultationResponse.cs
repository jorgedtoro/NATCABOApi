// Models/KPICalculationResponse.cs
namespace NATCABOSede.Models
{
    public class KPICalculationResponse
    {
        public double PPM { get; set; }
        public double PM { get; set; }
        public double Extrapeso { get; set; }
        public double FTT { get; set; }
        public DateTime HoraInicioLote { get; set; }
        public DateTime HoraFinAproximada { get; set; }
        public double PorcentajePedido { get; set; }
        public double CosteMOD { get; set; }
    }
}