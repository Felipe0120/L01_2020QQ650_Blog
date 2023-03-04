using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2020QQ650.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2020QQ650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly blogContex _usuariocontexto;

        public usuariosController(blogContex usuariocontexto)

        {
            _usuariocontexto = usuariocontexto;
        }

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<usuarios> listadousuario = (from e in _usuariocontexto.usuarios
                                           select e).ToList();
            if (listadousuario.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadousuario);
        }

        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindBynombre(string filtro)
        {
            usuarios? usuario = (from e in _usuariocontexto.usuarios
                               where e.nombre.Contains(filtro)
                               select e).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByapellido(string filtro)
        {
            usuarios? usuario = (from e in _usuariocontexto.usuarios
                                 where e.apellido.Contains(filtro)
                                 select e).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByrolld(int filtro)
        {
            usuarios? usuario = (from e in _usuariocontexto.usuarios
                                 where e.rolld==(filtro)
                                 select e).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

    }

}
