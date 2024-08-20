using System.ComponentModel.DataAnnotations;

namespace API_FIlmes_Entity.Models;

public class Filme
{

    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public String Titulo { get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    public String Genero {  get; set; }
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    public int Duracao { get; set; }
}
