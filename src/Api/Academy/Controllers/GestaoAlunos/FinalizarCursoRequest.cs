using Microsoft.AspNetCore.Mvc;

namespace Academy.Api.Controllers.GestaoAlunos
{
    public class FinalizarCursoRequest
    {
        public Guid MatriculaId { get; set; }
    }
}
