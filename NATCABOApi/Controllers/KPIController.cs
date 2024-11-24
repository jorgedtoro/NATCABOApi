// Controllers/KPIController.cs
using Microsoft.AspNetCore.Mvc;
using NATCABOSede.Models;
using NATCABOSede.Services;
using System;

namespace NATCABOSede.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KPIController : ControllerBase
    {
        private readonly IKPIService _kpiService;

        public KPIController(IKPIService kpiService)
        {
            _kpiService = kpiService;
        }

        [HttpPost("CalculateAll")]
        public IActionResult CalculateAll([FromBody] KPICalculationRequest request)
        {
            try
            {
                var response = new KPICalculationResponse
                {
                    PPM = _kpiService.CalcularPPM(request.PaquetesTotales, request.MinutosTrabajados, request.NumeroPersonas),
                    PM = _kpiService.CalcularPM(request.PaquetesTotales, request.MinutosTrabajados),
                    Extrapeso = _kpiService.CalcularExtrapeso(request.PesoReal, request.PesoObjetivo),
                    FTT = _kpiService.CalcularFTT((int)request.PaquetesTotales, request.PaquetesRechazados),
                    HoraInicioLote = _kpiService.GetHoraInicioLote(request.HoraInicio),
                    HoraFinAproximada = _kpiService.CalcularHoraFin(request.HoraInicio, request.PaquetesProducidos, request.MediaPaquetesPorMinuto),
                    PorcentajePedido = _kpiService.CalcularPorcentajePedido(request.PaquetesProducidos, request.PaquetesTotalesPedido),
                    CosteMOD = _kpiService.CalcularCosteMOD(request.TiempoTotal, request.CostoHora, request.NumeroPaquetes, request.PesoMinimo)
                };

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                // Para producción, evita exponer detalles de errores
                return StatusCode(500, new { error = "Ocurrió un error al procesar la solicitud." });
            }
        }
    }
}