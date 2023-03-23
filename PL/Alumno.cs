﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void GetAll()
        {
            BL.Alumno.GetAll();
        }
        public static void Add()
        {
            Console.WriteLine("Ingrese la informacion del alumno");

            ML.Alumno alumno = new ML.Alumno();  //Instancia Alumno 

            Console.WriteLine("Ingrese el nombre del alumno");
            alumno.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido Paterno del alumno");
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido Materno del alumno");
            alumno.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de nacimiento del alumno");
            alumno.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            ML.Result result = BL.Alumno.Add(alumno);

            if (result.Correct)
            {
                Console.WriteLine("El registro fue exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }
    }
}
