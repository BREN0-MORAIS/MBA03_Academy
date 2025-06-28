using Academy.GestaoConteudo.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoConteudo.Application.CQRS.Commands.AtualizarAula;

public class AtualizarAulaCommand : IRequest<Guid>
{
   
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string VideoUrl { get; set; }
    public TimeSpan Duracao { get; set; }
    public int Ordem { get; set; }
    public Guid CursoId { get; set; }
    public AtualizarAulaCommand(Guid id, string titulo, string descricao, string videoUrl, TimeSpan duracao, int ordem, Guid cursoId)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        VideoUrl = videoUrl;
        Duracao = duracao;
        Ordem = ordem;
        CursoId = cursoId;
    }

}
