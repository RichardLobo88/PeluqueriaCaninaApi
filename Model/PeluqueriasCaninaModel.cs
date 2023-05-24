using Microsoft.EntityFrameworkCore;
using PeluqueriaCaninaApi.Model;


namespace PeluqueriaCaninaApi.Model
{
    /* public class PeluqueriasCaninaModel
     {
         public int ID { get; set; }
         public string Nombre { get; set; }
         public DateTime Horario { get; set; }


     }
    */

    public class Peluquero
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }

    public class Turno
    {
        public int ID { get; set; }
        public int PeluqueroID { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
    }

    public class PeluqueriaAPI
    {
        private List<Peluquero> peluqueros;
        private List<Turno> turnos;

        public PeluqueriaAPI()
        {
            peluqueros = new List<Peluquero>();
            turnos = new List<Turno>();
        }

        //obtener lista de peluqueros 
        public List<Peluquero> GetAllPeluqueros()
        {
            return peluqueros;
        }





        public List<DateTime> ObtTurnosDisp(int peluqueroID, DateTime Fecha) {


            List<DateTime> turnosDisponibles = new List<DateTime>();


            foreach (var peluquero in peluqueros) {
                if (peluquero.ID == peluqueroID) {

                    DateTime horaInicio = new DateTime(Fecha.Year, Fecha.Month, Fecha.Day, peluquero.HoraFin.Hour, peluquero.HoraFin.Minute, 0);
                    DateTime horaFin = new DateTime(Fecha.Year, Fecha.Month, Fecha.Day, peluquero.HoraFin.Hour, peluquero.HoraFin.Minute, 0);


                    foreach (var turno in turnos)
                    {

                        if (turno.PeluqueroID.Equals(peluqueroID) && turno.Fecha.Date.Equals(Fecha.Date)){

                            horaInicio = horaInicio.AddMinutes(30);

                        }

                        while (horaInicio <= horaFin) {


                            turnosDisponibles.Add(horaInicio);
                            horaInicio = horaInicio.AddMinutes(30);

                        }
                        break;

                    }
                }


            }

            return turnosDisponibles;


        }

        public void AddTurno(int peluquerioID, DateTime fecha, int usuarioId)
        {

            Turno nuevoTurno = new Turno
            {
                PeluqueroID = peluquerioID,
                Fecha = fecha,
                UsuarioId = usuarioId
            };

            turnos.Add(nuevoTurno);




        }

        public List<Turno>GetTurnosPorUsuario(int usuarioId)
        {
            List<Turno> turnosUsuario = new List<Turno>();

            foreach (Turno turno in turnos)
            {
                if (turno.UsuarioId == usuarioId)
                {
                    turnosUsuario.Add(turno);
                }
            }

            return turnosUsuario;
        }


       









    }
}





