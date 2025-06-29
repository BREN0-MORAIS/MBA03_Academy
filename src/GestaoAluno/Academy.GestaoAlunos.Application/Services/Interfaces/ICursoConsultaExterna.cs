using Academy.GestaoAlunos.Application.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoAlunos.Application.Services.Interfaces;

    public interface ICursoConsultaExterna
    {
        Task<bool> CursoExisteAsync(Guid cursoId);
        Task<CursoRespostaDto?> ObterCursoDetalhadoAsync(Guid cursoId);


    }

