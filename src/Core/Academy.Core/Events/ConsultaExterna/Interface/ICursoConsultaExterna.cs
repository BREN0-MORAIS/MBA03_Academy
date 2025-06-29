

    public interface ICursoConsultaExterna
    {
        Task<bool> CursoExisteAsync(Guid cursoId);
        Task<CursoRespostaDto?> ObterCursoDetalhadoAsync(Guid cursoId);

    }

