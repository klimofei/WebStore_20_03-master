using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Mapping;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Shop(int? _SectionId, int? _BrandId)
        {
            var filter = new ProductFilter
            {
                SectionId = _SectionId,
                BrandId = _BrandId
            };

            var products = _ProductData.GetProducts(filter);
             
            return View(new CatalogViewModel
            {
                SectionId = _SectionId,
                BrandId = _BrandId,
                Products = products.Select(ProductMapping.ToView).OrderBy(p => p.Order)
            });
        }

        public IActionResult Details()
        {
            return View(); 

        }
    }
}