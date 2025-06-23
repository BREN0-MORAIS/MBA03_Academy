using Academy.Core.Entities;
using Academy.Core.Interfaces;
using Academy.GestaoConteudo.Domain.Enums;
using Academy.GestaoConteudo.Domain.ObjectValue;

namespace Academy.GestaoConteudo.Domain.Entities
{
    public class Curso : EntidadeBase, IAggregateRoot
    {
        public string  Titulo { get; private set; }
        public string  Descriao { get; private set; }
        public CursoStatus Status { get; private set; }
        public Decimal Valor { get; private set; }
        public ConteudoProgramatico ConteudoProgramatico { get; private set; }
        private readonly List<Aula> _aulas = [];
        public IReadOnlyCollection<Aula> Aulas => _aulas.AsReadOnly();

        public Curso()
        {
                
        }

        public Curso(string titulo, string descriao, CursoStatus status, decimal valor, ConteudoProgramatico conteudoProgramatico)
        {
            Titulo = titulo;
            Descriao = descriao;
            Status = status;
            Valor = valor;
            ConteudoProgramatico = conteudoProgramatico;
            Validar();
        }


        public void Validar()
        {

        }

        public void AdicionarAula(Aula aula)
        {
           _aulas.Add(aula);
        }
    }
}
