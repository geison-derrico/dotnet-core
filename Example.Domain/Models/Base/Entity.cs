using Example.Domain.Models.Interfaces;
using System;

namespace Example.Domain.Models.Base
{
    public class Entity : IEntity
    {
        public virtual DateTime DataHoraInclusao { get; set; }
        public virtual DateTime DataHoraAlteracao { get; set; }
        public virtual DateTime? DataHoraExclusao { get; set; }
        public virtual string IdOperador { get; set; } = string.Empty;
    }
}
