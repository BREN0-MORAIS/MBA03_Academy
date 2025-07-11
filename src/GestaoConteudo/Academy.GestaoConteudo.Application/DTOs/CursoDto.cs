﻿using Academy.GestaoConteudo.Domain.Enums;

namespace Academy.GestaoConteudo.Application.Dtos;

public class CursoDto
{
    public Guid Id { get; set; }
    public string Titulo { get;  set; }
    public string Descricao { get;  set; }
    public CursoStatus Status { get;  set; }
    public decimal Valor { get;  set; }
    public string Objetivo { get;  set; }
    public string PreRequisitos { get;  set; }
    public IEnumerable<AulaDto> Aulas { get; set; }
}

