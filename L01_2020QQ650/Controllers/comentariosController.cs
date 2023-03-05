using L01_2020QQ650.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020QQ650.Controllers
{
    [Route("comentarios")]
    [ApiController]
    public class comentariosController : ControllerBase
    {
        private readonly blogC _blogComent;

        public comentariosController(blogC blogComent)

        {
            _blogComent = blogComent;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<comentarios> listcoment = (from e in _blogComent.comentarios
                                            select e).ToList();
            if (listcoment.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listcoment);
        }

        [HttpPost]
        [Route("agregar")]
        public IActionResult Guardarcomentarios([FromBody] comentarios comentarios)
        {

            try
            {
                _blogComent.comentarios.Add(comentarios);
                _blogComent.SaveChanges();
                return Ok(comentarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult actualizarcoment(int id, [FromBody] comentarios updateDevice)
        {

            try
            {
                comentarios? updatecoment = (from e in _blogComent.comentarios
                                       where e.cometarioId == id
                                       select e).FirstOrDefault();
                if (updatecoment == null)

                    return NotFound();
                updatecoment.cometarioId = updateDevice.cometarioId;
                updatecoment.publicacionId = updateDevice.publicacionId;
                updatecoment.comentario = updateDevice.comentario;
                updatecoment.usuarioId = updateDevice.usuarioId;


                _blogComent.Entry(updatecoment).State = EntityState.Modified;
                _blogComent.SaveChanges();
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
        public IActionResult Deletecoment(int id)

        {
            try
            {
                comentarios? deletcoment = (from e in _blogComent.comentarios
                                            where e.usuarioId == id
                                            select e).FirstOrDefault();
                if (deletcoment == null)

                    return NotFound();

                _blogComent.SaveChanges();
                return Ok(deletcoment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet]
        [Route("Find/{usuariol}")]
        public IActionResult FindByrolld(int filtro)
        {
            try
            {
                comentarios? comentfind = (from e in _blogComent.comentarios
                                     where e.usuarioId == (filtro)
                                     select e).FirstOrDefault();

                if (comentfind == null)
                {
                    return NotFound();
                }
                return Ok(comentfind);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
