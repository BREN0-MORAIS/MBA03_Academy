public interface IAulaConsultaExterna
{
    Task<bool> AulaExisteAsync(Guid aulaId);
}
