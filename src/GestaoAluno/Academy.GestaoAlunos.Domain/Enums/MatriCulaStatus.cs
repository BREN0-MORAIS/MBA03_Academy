using System.ComponentModel.DataAnnotations;

namespace Academy.GestaoAlunos.Domain.Enums;

public enum MatriculaStatus
{
    [Display(Name = "Inativo")]
    Inativo = 0,
    [Display(Name = "Ativo")]
    Ativo = 1,
    [Display(Name = "Pendente de Pagamento")]
    PendentePagamento = 3,
    [Display(Name = "Concluído")]
    Concluido = 4,
}
