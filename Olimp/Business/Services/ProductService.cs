using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Olimp.Business.Interfaces;
using Olimp.Migrations;
using Olimp.Models;
using Olimp.ViewModels.Brand;
using Olimp.ViewModels.Product;
using Olimp.ViewModels.StoreWarehouse;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olimp.ViewModels.Category;

namespace Olimp.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext db;
        public ProductService(ApplicationContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get product in warehouse by id.
        /// </summary>
        /// <param name="id">Product id in warehouse.</param>
        /// <returns>Product in warehouse.</returns>
        public async Task<StoreWarehouseViewModel> GetProduct(int id)
        {
            var product = await db.StoreWarehouses
                .Include(x => x.Product).ThenInclude(x => x.Brand)
                .Include(x => x.Product).ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(sw => sw.Id == id);

            return mapper.Map<StoreWarehouseViewModel>(product);
        }
        
        /// <summary>
        /// Get all products by category id.
        /// </summary>
        /// <param name="categoryId">Product id in warehouse.</param>
        /// <returns>Products by category id.</returns>
        public async Task<List<StoreWarehouseViewModel>> GetProductsByCategoryId(int categoryId)
        {
            var product = await db.StoreWarehouses.Where(x => x.Product.CategoryId == categoryId)
                .Include(x => x.Product).ThenInclude(x => x.Brand)
                .Include(x => x.Product).ThenInclude(x => x.Category)
                .ToListAsync();

            return mapper.Map<List<StoreWarehouseViewModel>>(product);
        }

        /// <summary>
        /// Get all products in warehouse.
        /// </summary>
        /// <returns>All products in warehouse.</returns>
        public async Task<List<StoreWarehouseViewModel>> GetAllProducts()
        {
            var products = await db.StoreWarehouses
                .Include(x => x.Product).ThenInclude(x => x.Brand)
                .Include(x => x.Product).ThenInclude(x => x.Category).ToListAsync();

            return mapper.Map<List<StoreWarehouseViewModel>>(products);
        }
        
        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>All categories.</returns>
        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var products = await db.Categories.ToListAsync();

            return mapper.Map<List<CategoryViewModel>>(products);
        }
    }
}
