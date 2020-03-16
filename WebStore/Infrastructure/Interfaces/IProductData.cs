using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IProductData
    {
        /// <summary>
        /// Получить все секции
        /// </summary>
        /// <returns>Перечисление секций</returns>
        IEnumerable<Section> GetSections();

        /// <summary>
        /// Получить все бренды
        /// </summary>
        /// <returns>Перечисление брендов каталога</returns>
        IEnumerable<Brand> GetBrands();
    }
}
