using Microsoft.AspNetCore.Mvc;

namespace EspacioKanban;

[ApiController]
[Route("Api/[controller]")]
public class TareaController : ControllerBase
{
    private ITareaRepository tareaRepository;
    private readonly ILogger<TareaController> _logger;
    
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    [HttpPost]
    public ActionResult AddTarea(Tarea tarea, int idTablero){
        tareaRepository.AddTarea(tarea, idTablero);
        return Ok();
    }

    [HttpPut ("{id}/Nombre/{Nombre}")]
    public ActionResult UpdateTarea(int id, string Nombre){
        var tarea = tareaRepository.GetAllTareas().FirstOrDefault(t => t.Id == id);
        if(tarea != null){
            tarea.Nombre = Nombre;
            tareaRepository.UpdateTarea(id,tarea);
        }
        return Ok();
    }

    [HttpPut ("{id}/Estado/{estado}")]
    public ActionResult UpdateEstadoTarea(int id, EstadoTarea estado){
        tareaRepository.UpdateEstadoTarea(id, estado);
        return Ok();
    }

    [HttpDelete ("{id}")]
    public ActionResult DeleteTarea(int id){
        tareaRepository.DeleteTarea(id);
        return Ok();
    }

    [HttpGet("{estado}")]
    public ActionResult<int> GetAllTareasByEstado(EstadoTarea estado){
        var tareas = tareaRepository.GetAllTareas();
        int cantidad = tareas.Count(t => t.Estado == estado);
        return Ok(cantidad);
    }

    [HttpGet("Usuario/{id}")]
    public ActionResult<List<Usuario>> GetAllTareasByUsuario(int id){
        var tareas = tareaRepository.GetAllTareas().Where(t => t.IdUsuarioAsignado == id);
        return Ok(tareas);
    }
    
    [HttpGet("Tablero/{id}")]
    public ActionResult<List<Usuario>> GetAllTareasByTablero(int id){
        var tareas = tareaRepository.GetAllTareas().Where(t => t.IdTablero == id);
        return Ok(tareas);
    }

}