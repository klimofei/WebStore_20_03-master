using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Domain.Entities.Base
{
    /// <summary>
    /// Абстарктный класс именованной сущности
    /// </summary>
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        //[Required, StringLength(250)]
        [Required]
        public string Name { get; set; } 
    }
}
