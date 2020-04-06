using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
