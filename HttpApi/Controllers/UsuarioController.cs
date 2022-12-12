using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HttpApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private static List<Usuario> usuarios = new List<Usuario>{
                new Usuario {Nombre= "David Aguinsaca",Cedula= "1234567890"},
                new Usuario {Nombre="Jefferson Pérez", Cedula= "1234537890"},
                new Usuario {Nombre="Jason Negrete", Cedula= "1234537890"},
                new Usuario {Nombre="Daniel Buitrón", Cedula= "1721129060"},
            };

    [HttpGet(Name = "{Cedula}")]



    public Usuario GetUsuarios([FromHeader] string buscar)

    {

        var user = usuarios.Where(x => x.Cedula == buscar).SingleOrDefault();



        if (user != null)

        {

            var plainTextBytes = Encoding.UTF8.GetBytes(user.Cedula);

            var cedulaBase64 = System.Convert.ToBase64String(plainTextBytes);



            return new Usuario
            {

                Nombre = user.Nombre,

                Cedula = cedulaBase64

            };

        }
        throw new Exception("Error");
    }
}

