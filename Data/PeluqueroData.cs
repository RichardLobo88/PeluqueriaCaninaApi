using Dapper;
using Microsoft.AspNetCore;
using System.Data.SqlClient;
using PeluqueriaCaninaApi.Model;
using System.Linq;




namespace PeluqueriaCaninaApi.Data
    
{
    public class PeluqueroData
    {
        private readonly string conection_string = "Server=DESKTOP-DKKNBKN;Database=PeluqueriaCanina; Integrated Security = true; Trusted_Connection=Yes;";
        public List<Peluquero> GetAllPeluqueros()
        {
            List<Peluquero> list = new List<Peluquero>();
            try
            {



                using (SqlConnection cnn = new SqlConnection(conection_string))
                {

                    string query = "SELECT ID, Nombre FROM Peluqueros";
                    list = cnn.Query<Peluquero>(query).ToList();
                }
            }
            catch (Exception X) { }

            return list;

        }
              

        public List<Turno> GetTurnosPorUsuario()
        {
            List<Turno> list = new List<Turno>();
            try
            {



                using (SqlConnection cnn = new SqlConnection(conection_string))
                {

                    string query = "SELECT ID, Horario FROM Peluqueros";
                    list = cnn.Query<Turno>(query).ToList();
                }
            }
            catch (Exception X) { }

            return list;




        }


    }

    /*
    public List<DateTime> GetAllHoursPeluqueros(int Peluquero, DateTime Fecha)
    {


        List<DateTime> turnosDisponibles = new List<DateTime>();

        
        try
        {

            using (SqlConnection cnn = new SqlConnection(conection_string))
            {

                string query = "SELECT Horario FROM Peluqueros";
               turnosDisponibles = cnn.Query<PeluqueriasCaninaModel>(query).ToList();
            }

        }
        catch (Exception X) { }

        return turnosDisponibles;
    }
    */
}
