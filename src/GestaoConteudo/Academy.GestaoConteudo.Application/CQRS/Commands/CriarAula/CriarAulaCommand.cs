using Academy.Core.DomainObjects.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GestaoConteudo.Application.CQRS.Commands.CriarAula
{
    public class CriarAulaCommand : IRequest<Guid>
    {

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string VideoUrl { get; set; }
        public TimeSpan Duracao { get; set; }
        public int Ordem { get; set; }
        public Guid CursoId { get; set; }

        public CriarAulaCommand(string titulo, string descricao, string videoUrl, TimeSpan duracao, int ordem, Guid cursoId)
        {
            Titulo = titulo;
            Descricao = descricao;
            VideoUrl = videoUrl;
            Duracao = duracao;
            Ordem = ordem;
            CursoId = cursoId;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Titulo, "O campo titulo não pode ser vazio.");
            Validacoes.ValidarSeMenorQue(Titulo.Count(), 5, "O campo titulo não pode ser menor que 5 caracteres.");
            Validacoes.ValidarMinimoMaximo(Titulo.Count(), 5, 50, "O campo titulo tem que ter no minimo 5 caracteres e no maximo 50");

            Validacoes.ValidarSeVazio(Descricao, "O campo titulo não pode ser vazio.");
            Validacoes.ValidarSeMenorQue(Descricao.Count(), 10, "O campo titulo não pode ser menor que 10 caracteres.");
            Validacoes.ValidarMinimoMaximo(Descricao.Count(), 10, 500, "O campo tem que ter no minimo 10 caracteres e no maximo 500");

            Validacoes.ValidarSeVazio(VideoUrl, "O campo VideoUrl não pode ser vazio.");
            Validacoes.ValidarSeMenorQue(VideoUrl.Count(), 10, "O campo VideoUrl não pode ser menor que 10 caracteres.");

            Validacoes.ValidarSeMenorQue(VideoUrl.Count(), 0, "O campo VideoUrl não pode ser menor que 10 caracteres.");
        }
    }
}
