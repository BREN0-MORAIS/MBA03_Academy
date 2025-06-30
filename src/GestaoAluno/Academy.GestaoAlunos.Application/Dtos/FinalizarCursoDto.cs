using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoAlunos.Application.Dtos;

public class FinalizarCursoDto
{
    public string UserId { get; set; }
    public Guid MatriculaId { get; set; }
    public string  NomeAluno { get; set; }
 
}
