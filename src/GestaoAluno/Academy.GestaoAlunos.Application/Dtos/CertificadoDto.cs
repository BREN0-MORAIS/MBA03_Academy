namespace Academy.GestaoAlunos.Application.Dtos;

public class CertificadoDto
{
    public Guid UserId { get;  set; }
    public Guid CursoId { get;  set; }
    public Guid MatriculaId { get;  set; }
    public string NomeDoAluno { get;  set; }
    public DateTime DataEmissao { get;  set; }
    public string CodigoVerificacao { get;  set; }
}
