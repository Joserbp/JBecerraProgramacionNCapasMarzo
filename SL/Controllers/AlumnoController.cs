using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace SL.Controllers
{
    public class AlumnoController : ApiController
    {
        [HttpGet]
        [Route("api/alumno/")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAllEF();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpPost]
        [Route("api/alumno/")]
        public IHttpActionResult Add ([FromBody] ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.AddEF(alumno);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpPut]
        [Route("api/alumno/")]
        public IHttpActionResult Update([FromBody] ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.UpdateEF(alumno);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpDelete]
        [Route("api/alumno/{IdAlumno}")]
        public IHttpActionResult Delete(int IdAlumno)
        {
            ML.Result result = BL.Alumno.DeleteEF(IdAlumno);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [HttpGet]
        [Route("api/alumno/{IdAlumno}")]
        public IHttpActionResult GetById(int IdAlumno)
        {
            ML.Result result = BL.Alumno.GetByIdEF(IdAlumno);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
