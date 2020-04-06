using System.Collections.Generic;
using WebStore.Domain.Entities;

namespace WebStore.Interfaces.Services
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
        
        /// <summary>
        /// Товары из каталога
        /// </summary>
        /// <param name="Filter">Критерии поиска/фильтрации</param>
        /// <returns>Искомые товары из каталога товаров</returns>
        IEnumerable<Product> GetProducts(ProductFilter Filter = null);


        /// <summary>Получить товар по идентификатору</summary>
        /// <param name="id">Идентификатор требуемого товара</param>
        /// <returns>Товар</returns>
        Product GetProductById(int id);
    }
}
