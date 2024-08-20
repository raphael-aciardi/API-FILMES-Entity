using API_FIlmes_Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_FIlmes_Entity.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController
{
    private static List<Filme> filmes = new List<Filme>();
    [HttpPost]
    public void AdicionarFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }

}
