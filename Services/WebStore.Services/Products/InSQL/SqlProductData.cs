﻿using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.DTO.Products;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;

namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreDB _db;

        public SqlProductData(WebStoreDB db) => _db = db;


        public IEnumerable<Section> GetSections() => _db.Sections
                                                    //.Include(section => section.Products)
                                                    .AsEnumerable();

        public IEnumerable<Brand> GetBrands() => _db.Brands
                                                    //.Include(brand => brand.Products)
                                                    .AsEnumerable();

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products
                                        .Include(p=>p.Section)
                                        .Include(p => p.Brand);

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            if(Filter?.Ids?.Count > 0)
                query = query.Where(product => Filter.Ids.Contains(product.Id));

            return query.AsEnumerable().Select(p => p.ToDTO());

        }

        public ProductDTO GetProductById(int id) => _db.Products
                                                    .Include(p => p.Brand)
                                                    .Include(p => p.Section)
                                                    .FirstOrDefault(p => p.Id == id)
                                                    .ToDTO();
    }
}
