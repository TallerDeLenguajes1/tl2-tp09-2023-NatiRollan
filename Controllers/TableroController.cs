using Microsoft.AspNetCore.Mvc;

namespace EspacioKanban;

[ApiController]
[Route("Api/[controller]")]
public class TableroController : ControllerBase
{
    private ITableroRepository tableroRepository;
    private readonly ILogger<TableroController> _logger;
    
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }
    
    [HttpPost]
    public ActionResult AddTablero(Tablero tablero){
        tableroRepository.AddTablero(tablero);
        return Ok("Tablero creado");
    }

    [HttpGet]
    public ActionResult<List<Tablero>> GetAllTableros(){
        List<Tablero> tableros = tableroRepository.GetAllTableros();
        return Ok(tableros);
    }
}