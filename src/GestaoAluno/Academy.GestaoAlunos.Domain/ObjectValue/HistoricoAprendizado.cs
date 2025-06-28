namespace Academy.GestaoAlunos.Domain.ObjectValue
{
    public class HistoricoAprendizado
    {
        public int TotalCursosConcluidos { get; private set; }
        public int TotalHoras { get; private set; }

        public HistoricoAprendizado(int totalCursosConcluidos, int totalHoras)
        {
            TotalCursosConcluidos = totalCursosConcluidos;
            TotalHoras = totalHoras;
        }
    }
}
