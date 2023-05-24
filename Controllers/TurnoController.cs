using Microsoft.AspNetCore.Mvc;
using PeluqueriaCaninaApi.Model;

namespace PeluqueriaCaninaApi.Controllers
{
    public class TurnoController : ControllerBase
    {

        private readonly PeluqueriaAPI peluqueriaAPI;

        public TurnoController()
        {
            peluqueriaAPI = new PeluqueriaAPI();
        }

        [HttpGet("{peluqueroId}/{fecha}")]
        public ActionResult<IEnumerable<DateTime>> ObtTurnosDisp(int peluqueroId, DateTime fecha)
        {
            List<DateTime> turnosDisponibles = peluqueriaAPI.ObtTurnosDisp(peluqueroId, fecha);
            return Ok(turnosDisponibles);
        }

        [HttpPost]
        public IActionResult AddTurno(Turno turno)
        {
            peluqueriaAPI.AddTurno(turno.PeluqueroID, turno.Fecha, turno.UsuarioId);
            return Ok();
        }

        [HttpGet("usuario/{usuarioId}")]
        public ActionResult<IEnumerable<Turno>> GetTurnosPorUsuario(int usuarioId)
        {
            List<Turno> turnosUsuario = peluqueriaAPI.GetTurnosPorUsuario(usuarioId);
            return Ok(turnosUsuario);
        }
    }



}

