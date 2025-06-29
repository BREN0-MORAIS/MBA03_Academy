using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.PagamentoFaturamento.Application.Dtos;

public class CursoRespostaDto
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Status { get; set; }
    public decimal Valor { get; set; }
    public string Objetivo { get; set; }
    public string PreRequisitos { get; set; }
}
