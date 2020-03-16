using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities.Base
{
    /// <summary>
    /// Абстарктный класс именованной сущности
    /// </summary>
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }
}
