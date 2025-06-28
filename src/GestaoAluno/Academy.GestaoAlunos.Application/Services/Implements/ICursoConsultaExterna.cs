using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoAlunos.Application.Services.Implements;

    public interface ICursoConsultaExterna
    {
        Task<bool> CursoExisteAsync(Guid cursoId);
    
    }

