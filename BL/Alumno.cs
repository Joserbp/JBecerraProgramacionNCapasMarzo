using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Importar libreria

namespace BL
{
    public class Alumno
    {
        public static void Add(ML.Alumno alumno)
        {
            using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
            {
                using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                {
                    cmd.CommandText = "INSERT INTO [Alumno]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento]) VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento)";

                    SqlParameter[] collection = new SqlParameter[4]; //Cantidad sin contemplar 0
                    collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                    collection[0].Value = alumno.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                    collection[1].Value = alumno.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoMaterno;
                    collection[3] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
                    collection[3].Value = alumno.FechaNacimiento;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection = context;

                    cmd.Connection.Open();
                    int RowAffeted = cmd.ExecuteNonQuery();
                    if(RowAffeted > 0)
                    {
                        Console.WriteLine("Registro exitoso"); //PL
                    }
                    else
                    {
                        Console.WriteLine("Ocurrio un error");
                    }
                }
            }
        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
        public void GetAll()
        {

        }
        public void GetById()
        {

        }
    }
}
