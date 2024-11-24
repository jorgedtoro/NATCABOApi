// Services/IKPIService.cs
using System;

namespace NATCABOSede.Services
{
    public interface IKPIService
    {
        double CalcularPPM(double paquetesTotales, double minutosTrabajados, int numeroPersonas);
        double CalcularPM(double paquetesTotales, double minutosTrabajados);
        double CalcularExtrapeso(double pesoReal, double pesoObjetivo);
        double CalcularFTT(int paquetesTotales, int paquetesRechazados);
        DateTime GetHoraInicioLote(DateTime horaInicio);
        DateTime CalcularHoraFin(DateTime horaInicio, int paquetesProducidos, double mediaPaquetesPorMinuto);
        double CalcularPorcentajePedido(int paquetesProducidos, int paquetesTotales);
        double CalcularCosteMOD(double tiempoTotal, double costoHora, int numeroPaquetes, double pesoMinimo);
    }
}