using System;
using System.ComponentModel.DataAnnotations;

namespace DentistSite.Domain.Entities.Base
{
    [Serializable]
    public abstract class EntityBase : IHaveIdentity<int>
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
