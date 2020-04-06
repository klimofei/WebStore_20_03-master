﻿using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Секция товаров
    /// </summary>
    /// 
    //[Table("Sections")]
   public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

       /// <summary>
       /// Идентификатор родительской секции
       /// </summary>
        public int? ParentId { get; set; }
        
        [ForeignKey(nameof(ParentId))]
        public virtual Section ParentSection { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
