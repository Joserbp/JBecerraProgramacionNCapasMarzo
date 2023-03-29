using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Importar libreria
using ML;
using System.Data;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                //Codigo que puede tener un error.
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
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
                        if (RowAffeted > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al insertar en la tabla alumno";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                    {
                        cmd.CommandText = "SELECT [IdAlumno],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento] FROM [Alumno]";
                        cmd.Connection=context;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            DataTable tablaAlumno = new DataTable();
                            da.Fill(tablaAlumno);
                            if(tablaAlumno.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tablaAlumno.Rows)
                                {
                                    ML.Alumno alumno = new ML.Alumno();
                                    alumno.IdAlumno = int.Parse(row[0].ToString());
                                    alumno.Nombre = row[1].ToString();
                                    
                                    result.Objects.Add(alumno);
                                    //Isac 
                                }
                                result.Correct = true;
                            }

                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontraron registros";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }

        public static ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                //Codigo que puede tener un error.
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                    {
                        cmd.CommandText = "AlumnoAdd";
                        cmd.CommandType = CommandType.StoredProcedure;

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
                        if (RowAffeted > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al insertar en la tabla alumno";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }

        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JBecerraProgramacionNCapasMarzoEntities context = new DL_EF.JBecerraProgramacionNCapasMarzoEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.FechaNacimiento, alumno.UserName, alumno.Semestre.IdSemestre);

                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JBecerraProgramacionNCapasMarzoEntities context = new DL_EF.JBecerraProgramacionNCapasMarzoEntities())
                {
                    var alumnos = context.AlumnoGetAll().ToList();

                    if (alumnos != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var alumnoObj in alumnos)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = alumnoObj.IdAlumno;
                            alumno.Nombre = alumnoObj.Nombre;
                            alumno.ApellidoPaterno = alumnoObj.ApellidoPaterno;
                            alumno.ApellidoMaterno = alumnoObj.ApellidoMaterno;
                            alumno.FechaNacimiento = alumnoObj.FechaNacimiento;
                            alumno.UserName = alumnoObj.UserName;
                            //Instancia de Semestre
                                //ML.Semestre semestre = new ML.Semestre(); NO tiene relación con alumno
                            alumno.Semestre = new ML.Semestre();
                            alumno.Semestre.IdSemestre = alumnoObj.IdSemestre.Value; //Solo cuando estamos seguros que viene un valor
                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.JBecerraProgramacionNCapasMarzoEntities context = new DL_EF.JBecerraProgramacionNCapasMarzoEntities())
                {
                    var alumnoObj = context.AlumnoGetById(IdAlumno).Single();

                    if (alumnoObj != null)
                    {
                        

                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = alumnoObj.IdAlumno;
                            alumno.Nombre = alumnoObj.Nombre;
                            alumno.ApellidoPaterno = alumnoObj.ApellidoPaterno;
                            alumno.ApellidoMaterno = alumnoObj.ApellidoMaterno;
                            alumno.FechaNacimiento = alumnoObj.FechaNacimiento;
                            alumno.UserName = alumnoObj.UserName;
                            //Instancia de Semestre
                            //ML.Semestre semestre = new ML.Semestre(); NO tiene relación con alumno
                            alumno.Semestre = new ML.Semestre();
                            //alumno.Semestre.IdSemestre = alumnoObj.IdSemestre; //Solo cuando estamos seguros que viene un valor

                       
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
    }
}
