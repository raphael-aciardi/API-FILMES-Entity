using API_FIlmes_Entity.Data;
using API_FIlmes_Entity.Data.Dtos;
using API_FIlmes_Entity.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_FIlmes_Entity.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmesPorId),
            new { id = filme.Id },
            filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmesPorId(int id)
    {
        var filme = _context.Filmes
            .FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        return Ok(filme);
    }

    [HttpPut("{id}")]
    public IActionResult AtualiaFilme(int id, [FromBody]  UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id); if (filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

}
