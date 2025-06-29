using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoAlunos.Application.Services.Interfaces
{
    public interface IAulaConsultaExterna
    {
        Task<bool> AulaExisteAsync(Guid aulaId);
    }
}
