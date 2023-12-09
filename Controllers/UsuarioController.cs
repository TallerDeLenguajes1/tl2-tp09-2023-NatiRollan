using Microsoft.AspNetCore.Mvc;

namespace EspacioKanban;

[ApiController]
[Route("Api/[controller]")]
public class UsuarioController : ControllerBase
{
    private IUsuarioRepository usuarioRepository;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost]
    public ActionResult AddUsuario(Usuario usuario){
        usuarioRepository.AddUsuario(usuario);
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<Usuario>> GetAllUsuarios(){
        var usuarios = usuarioRepository.GetAllUsuarios();
        return Ok(usuarios);
    }

    [HttpGet ("{id}")]
    public ActionResult<Usuario> GetUsuario(int id){
        var usuario = usuarioRepository.GetUsuario(id);
        return Ok(usuario);
    }
    
    [HttpPut ("{id}/Nombre")]
    public ActionResult UpdateUSuario(int id, Usuario usuario){
        usuarioRepository.UpdateUsuario(id,usuario);
        return Ok("usuario modificado");
    }

}