using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2020QQ650.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2020QQ650.Controllers
{
    [Route("usuarios")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly blogC _blogUsu;

        public usuariosController(blogC blogUsu)

        {
            _blogUsu = blogUsu;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            try
            {
                List<usuarios> listausuario = (from e in _blogUsu.usuarios
                                               select e).ToList();
                if (listausuario.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(listausuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("Find/{nombre}/{apellido}")]
        public IActionResult FindBynombre(string nombre, string apellido)
        {
            try 
            {
                List<usuarios>listnombreapellidos= (from e in _blogUsu.usuarios where e.nombres.Contains(nombre) && e.apellido.Contains(apellido) select e).ToList();
                

                if (listnombreapellidos == null)
     
                    return NotFound();
                _blogUsu.SaveChanges();
                
                return Ok(listnombreapellidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("Find/{rol}")]
        public IActionResult FindByrolld(int filtro)
        {
            try
            {
                usuarios? usuario = (from e in _blogUsu.usuarios
                                     where e.rolId == (filtro)
                                     select e).FirstOrDefault();

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost]
        [Route("add")]
        public IActionResult Guardarusuario([FromBody] usuarios usuario)
        {

            try
            {
                _blogUsu.usuarios.Add(usuario);
                _blogUsu.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult actualizarusuario(int id, [FromBody] usuarios updateDevice)
        {
            try
            {
                usuarios? updateusuario = (from e in _blogUsu.usuarios
                                           where e.usuarioId == id
                                           select e).FirstOrDefault();
                if (updateusuario == null)
                {
                    return NotFound();
                }
                updateusuario.usuarioId = updateDevice.usuarioId;
                updateusuario.rolId = updateDevice.rolId;
                updateusuario.nombreUsuario = updateDevice.nombreUsuario;
                updateusuario.clave = updateDevice.clave;


                _blogUsu.Entry(updateusuario).State = EntityState.Modified;
                _blogUsu.SaveChanges();
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
        public IActionResult Deleteusuario(int id)

        {
            try
            {
                usuarios? deleteusu = (from e in _blogUsu.usuarios
                                            where e.usuarioId == id
                                            select e).FirstOrDefault();
                if (deleteusu == null)

                    return NotFound();

                _blogUsu.SaveChanges();
                return Ok(deleteusu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

    }

}
