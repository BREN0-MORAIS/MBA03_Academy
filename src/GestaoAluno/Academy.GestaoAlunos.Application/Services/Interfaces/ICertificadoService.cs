using Academy.GestaoAlunos.Application.Dtos;
using Academy.GestaoAlunos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoAlunos.Application.Services.Interfaces;

public interface ICertificadoService
{
    Task<string> GerarCertificado(Matricula matricula, string NomeAluno);

}
