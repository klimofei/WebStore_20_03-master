﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreDB _db;

        public SqlProductData(WebStoreDB db) => _db = db;


        public IEnumerable<Section> GetSections() => _db.Sections.Include(section => section.Products).AsEnumerable();

        public IEnumerable<Brand> GetBrands() => _db.Brands.Include(brand => brand.Products).AsEnumerable();

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products;

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            return query;

        }

    }
}
