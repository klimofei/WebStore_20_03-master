using System.Collections.Generic;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Бренд
    /// </summary>
   
    //[Table("Brand")] //- ручное указание названия таблицы в БД
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        // навигационное свойство "один ко многим"
        public virtual ICollection<Product> Products { get; set; } 
    }
}
