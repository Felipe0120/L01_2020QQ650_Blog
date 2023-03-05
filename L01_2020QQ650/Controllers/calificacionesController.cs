using L01_2020QQ650.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L01_2020QQ650.Controllers
{
    [Route("calificaciones")]
    [ApiController]
    public class calificacionesController : ControllerBase
    {

        private readonly blogC _blogCali;

        public calificacionesController(blogC blogCali)

        {
            _blogCali = _blogCali;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<calificaciones> listcalifi = (from e in _blogCali.calificaciones
                                             select e).ToList();
            if (listcalifi.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listcalifi);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Guardarcalificaciones([FromBody] calificaciones calificaciones)
        {

            try
            {
                _blogCali.calificaciones.Add(calificaciones);
                _blogCali.SaveChanges();
                return Ok(calificaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult actualizarcalifi(int id, [FromBody] calificaciones updateDevice)
        {
            try
            {
                calificaciones? updatecalifi = (from e in _blogCali.calificaciones
                                             where e.calificacionId == id
                                             select e).FirstOrDefault();
                if (updatecalifi == null)

                    return NotFound();
                updatecalifi.calificacionId = updateDevice.calificacionId;
                updatecalifi.publicacionId = updateDevice.publicacionId;
                updatecalifi.calificacion = updateDevice.calificacion;
                updatecalifi.usuarioId = updateDevice.usuarioId;


                _blogCali.Entry(updatecalifi).State = EntityState.Modified;
                _blogCali.SaveChanges();
                return Ok(updateDevice);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        //metodos de eliminar ID
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Deletecalifi(int id)

        {
            try
            {
                calificaciones? deletcalifi = (from e in _blogCali.calificaciones
                                            where e.calificacionId == id
                                            select e).FirstOrDefault();
                if (deletcalifi == null)

                    return NotFound();

                _blogCali.SaveChanges();
                return Ok(deletcalifi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet]
        [Route("Find/{publicacion}")]
        public IActionResult FindBypublicacion(int filtro)
        {
           calificaciones ? califi = (from e in _blogCali.calificaciones
                                 where e.publicacionId == (filtro)
                                 select e).FirstOrDefault();

            if (califi == null)
            {
                return NotFound();
            }
            return Ok(califi);
        }
    }
}
