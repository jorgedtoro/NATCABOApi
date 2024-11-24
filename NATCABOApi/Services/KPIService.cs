// Services/KPIService.cs
using System;

namespace NATCABOSede.Services
{
    public class KPIService : IKPIService
    {
        public double CalcularPPM(double paquetesTotales, double minutosTrabajados, int numeroPersonas)
        {
            if (minutosTrabajados <= 0 || numeroPersonas <= 0)
                throw new ArgumentException("Los minutos trabajados y el número de personas deben ser mayores a 0.");

            return paquetesTotales / (minutosTrabajados * numeroPersonas);
        }

        public double CalcularPM(double paquetesTotales, double minutosTrabajados)
        {
            if (minutosTrabajados <= 0)
                throw new ArgumentException("Los minutos trabajados deben ser mayores a 0.");

            return paquetesTotales / minutosTrabajados;
        }

        public double CalcularExtrapeso(double pesoReal, double pesoObjetivo)
        {
            return pesoReal - pesoObjetivo;
        }

        public double CalcularFTT(int paquetesTotales, int paquetesRechazados)
        {
            if (paquetesTotales <= 0)
                return 0;

            return ((double)(paquetesTotales - paquetesRechazados) / paquetesTotales) * 100;
        }

        public DateTime GetHoraInicioLote(DateTime horaInicio)
        {
            return horaInicio;
        }

        public DateTime CalcularHoraFin(DateTime horaInicio, int paquetesProducidos, double mediaPaquetesPorMinuto)
        {
            if (mediaPaquetesPorMinuto <= 0)
                throw new ArgumentException("La media de paquetes por minuto debe ser mayor a 0.");

            double minutosRestantes = paquetesProducidos / mediaPaquetesPorMinuto;
            return horaInicio.AddMinutes(minutosRestantes);
        }

        public double CalcularPorcentajePedido(int paquetesProducidos, int paquetesTotales)
        {
            if (paquetesTotales <= 0)
                throw new ArgumentException("El número total de paquetes debe ser mayor a 0.");

            return (double)paquetesProducidos / paquetesTotales * 100;
        }

        public double CalcularCosteMOD(double tiempoTotal, double costoHora, int numeroPaquetes, double pesoMinimo)
        {
            if (tiempoTotal <= 0 || costoHora <= 0 || numeroPaquetes <= 0 || pesoMinimo <= 0)
                throw new ArgumentException("Todos los valores deben ser mayores a 0.");

            double totalCosto = tiempoTotal * costoHora;
            double totalProduccion = numeroPaquetes * pesoMinimo;

            return totalCosto / totalProduccion;
        }
    }
}