using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoAlunos.Application.Dtos;

public class CertificadoDto
{
    public Guid UserId { get;  set; }
    public Guid CursoId { get;  set; }
    public string NomeDoAluno { get;  set; }
    public string TituloDoCurso { get;  set; }
    public DateTime DataEmissao { get;  set; }
    public string CodigoVerificacao { get;  set; }

}
