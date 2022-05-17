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
using Olimp.ViewModels.FeedBack;

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
        /// Get products by filters ids.
        /// </summary>
        /// <param name="categoryId">Category id in warehouse.</param>
        /// <param name="brandId">Brand id in warehouse.</param>
        /// <param name="priceStart">Price start.</param>
        /// <param name="priceEnd">Price end.</param>
        /// <param name="sortType">Type sort.</param>
        /// <returns>Products by filters ids.</returns>
        public async Task<List<StoreWarehouseViewModel>> GetProductsByFilters(int categoryId, int brandId, int? priceStart, int? priceEnd, int sortType)
        {
            var products = await db.StoreWarehouses
                .Include(x => x.Product).ThenInclude(x => x.Brand)
                .Include(x => x.Product).ThenInclude(x => x.Category).ToListAsync();

            if (products == null) return null;
            
            if (categoryId != 0)
            {
                products = products.Where(x => x.Product.CategoryId == categoryId).ToList();
            }

            if (brandId != 0)
            {
                products = products.Where(x => x.Product.BrandId == brandId).ToList();
            }

            if (priceStart.HasValue)
            {
                products = products.Where(x => x.Price >= priceStart.Value).ToList();
            }

            if (priceEnd.HasValue)
            {
                products = products.Where(x => x.Price <= priceEnd).ToList();
            }

            switch (sortType)
            {
                case 0:
                {
                    break;
                }
                case 1:
                {
                    products = products.OrderBy(x => x.Price).ToList();
                    break;
                }
                case 2:
                {
                    products = products.OrderByDescending(x => x.Price).ToList();
                    break;
                }
            }
            
            return mapper.Map<List<StoreWarehouseViewModel>>(products);
        }
        
        /// <summary>
        /// Get products by name.
        /// </summary>
        /// <param name="productName">Product name.</param>
        /// <returns>All products like name.</returns>
        public async Task<List<StoreWarehouseViewModel>> GetProductsByName(string productName)
        {
            var events = await db.StoreWarehouses
                .Include(x => x.Product)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Product)
                .ThenInclude(x => x.Category)
                .Where(x => x.Product.Title.Contains(productName))
                .ToListAsync();

            return mapper.Map<List<StoreWarehouseViewModel>>(events);
        }

        /// <summary>
        /// Get brand by id.
        /// </summary>
        /// <param name="id">Brand id.</param>
        /// <returns>Brand by id.</returns>
        public async Task<BrandViewModel> GetBrandById(int id)
        {
            var brand = await db.Brands.FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<BrandViewModel>(brand);
        }
        
        /// <summary>
        /// Get comments by store warehouse id.
        /// </summary>
        /// <param name="id">StoreWarehouse id.</param>
        /// <returns>Comments by store warehouse id.</returns>
        public async Task<List<FeedBackViewModel>> GetCommentsByStoreWarehouseId(int id)
        {
            var comments = await db.FeedBacks
                .Include(x => x.User)
                .Include(x => x.StoreWarehouse)
                .Where(x => x.StoreWarehouseId == id)
                .ToListAsync();

            return mapper.Map<List<FeedBackViewModel>>(comments);
        }
        
        /// <summary>
        /// Add feedback.
        /// </summary>
        /// <param name="model">Feedback model.</param>
        /// <returns>Message about adding a feedback.</returns>
        public async Task<string> AddFeedBack(FeedBackViewModel model)
        {
            var feedback = mapper.Map<FeedBack>(model);
            
            await db.FeedBacks.AddAsync(feedback);
            
            await db.SaveChangesAsync();
            
            return "FeedBack has been added";
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
        /// Get last products by count.
        /// </summary>
        /// <param name="count">Count products.</param>
        /// <returns>Last products in warehouse.</returns>
        public async Task<List<StoreWarehouseViewModel>> GetLastProductsByCount(int count)
        {
            var products = await db.StoreWarehouses
                .Include(x => x.Product).ThenInclude(x => x.Brand)
                .Include(x => x.Product).ThenInclude(x => x.Category)
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();

            return mapper.Map<List<StoreWarehouseViewModel>>(products);
        }
        
        /// <summary>
        /// Get brands by count.
        /// </summary>
        /// <param name="count">Count brands.</param>
        /// <returns>Brands.</returns>
        public async Task<List<BrandViewModel>> GetBrandsByCount(int count)
        {
            var products = await db.Brands
                .Take(count)
                .ToListAsync();

            return mapper.Map<List<BrandViewModel>>(products);
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
