// Models/KPICalculationRequest.cs
namespace NATCABOSede.Models
{
    public class KPICalculationRequest
    {
        public double PaquetesTotales { get; set; }
        public double MinutosTrabajados { get; set; }
        public int NumeroPersonas { get; set; }
        public double PesoReal { get; set; }
        public double PesoObjetivo { get; set; }
        public int PaquetesRechazados { get; set; }
        public DateTime HoraInicio { get; set; }
        public int PaquetesProducidos { get; set; }
        public double MediaPaquetesPorMinuto { get; set; }
        public int PaquetesTotalesPedido { get; set; }
        public double TiempoTotal { get; set; }
        public double CostoHora { get; set; }
        public int NumeroPaquetes { get; set; }
        public double PesoMinimo { get; set; }
    }
}