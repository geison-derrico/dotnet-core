using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Domain.Core.Models
{
    public abstract class ModelBase
    {
        [NotMapped]
        public int Id { get; set; }

        [NotMapped]
        public Guid Guid { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as ModelBase;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Guid.Equals(compareTo.Guid);
        }

        public static bool operator ==(ModelBase a, ModelBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ModelBase a, ModelBase b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Guid.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Guid + "]";
        }
    }
}
