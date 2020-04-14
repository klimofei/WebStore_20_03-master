using WebStore.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Domain.Entities.Base
{
    /// <summary>Именованная сущность</summary>
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        /// <summary>Имя</summary>
        //[Required, StringLength(250)]
        [Required]
        public string Name { get; set; } 
    }
}
