using System;

namespace Example.Domain.Models.Interfaces
{
    public interface IEntidadeAuditavel
    {
        DateTime DataHoraInclusao { get; set; }
        DateTime DataHoraAlteracao { get; set; }
    }
}