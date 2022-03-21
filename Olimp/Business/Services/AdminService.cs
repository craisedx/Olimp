using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Olimp.Business.Interfaces;
using Olimp.Migrations;
using Olimp.Models;
using Olimp.ViewModels.Brand;
using Olimp.ViewModels.Category;
using Olimp.ViewModels.Product;
using Olimp.ViewModels.StoreWarehouse;

namespace Olimp.Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationContext _db;
        private readonly IMapper _mapper;

        public AdminService(IMapper mapper, ApplicationContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<CategoryViewModel> CreateCategory(CategoryViewModel model)
        {
            var category = _mapper.Map<Category>(model);

            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();

            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<BrandViewModel> CreateBrand(BrandViewModel model)
        {
            var brand = _mapper.Map<Brand>(model);

            await _db.Brands.AddAsync(brand);
            await _db.SaveChangesAsync();

            return _mapper.Map<BrandViewModel>(brand);
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel model)
        {
            var product = _mapper.Map<Product>(model);

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<StoreWarehouseViewModel> CreateStoreWarehouse(StoreWarehouseViewModel model)
        {
            var storeWarehouse = _mapper.Map<StoreWarehouse>(model);

            await _db.StoreWarehouses.AddAsync(storeWarehouse);
            await _db.SaveChangesAsync();

            return _mapper.Map<StoreWarehouseViewModel>(storeWarehouse);
        }

        public async Task<CategoryViewModel> EditCategory(CategoryViewModel model)
        {
            var editCategory = await _db.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);

            editCategory.ProductCategory = model.ProductCategory;
            await _db.SaveChangesAsync();

            return _mapper.Map<CategoryViewModel>(editCategory);
        }

        public async Task<BrandViewModel> EditBrand(BrandViewModel model)
        {
            var editBrand = await _db.Brands.FirstOrDefaultAsync(x => x.Id == model.Id);

            editBrand.ProductBrand = model.ProductBrand;
            editBrand.Image = model.Image;
            editBrand.Description = model.Description;
            await _db.SaveChangesAsync();

            return _mapper.Map<BrandViewModel>(editBrand);
        }

        public async Task<ProductViewModel> EditProduct(ProductViewModel model)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == model.Id);

            product.CategoryId = model.CategoryId;
            product.BrandId = model.BrandId;
            product.Title = model.Title;
            product.Image = model.Image;
            product.Description = model.Description;
            await _db.SaveChangesAsync();

            var editProduct = await _db.Products.Include(x => x.Category).Include(x => x.Brand)
                .FirstOrDefaultAsync(x => x.Id == product.Id);

            return _mapper.Map<ProductViewModel>(editProduct);
        }

        public async Task<StoreWarehouseViewModel> EditStoreWarehouse(StoreWarehouseViewModel model)
        {
            var storeWarehouse = await _db.StoreWarehouses.FirstOrDefaultAsync(x => x.Id == model.Id);

            storeWarehouse.ProductId = model.ProductId;
            storeWarehouse.Price = model.Price;
            storeWarehouse.Quantity = model.Quantity;
            storeWarehouse.Discount = model.Discount;

            var editStoreWarehouse = await _db.StoreWarehouses.FirstOrDefaultAsync(x => x.Id == storeWarehouse.Id);

            return _mapper.Map<StoreWarehouseViewModel>(editStoreWarehouse);
        }

        public async Task<List<CategoryViewModel>> GetAllCategory()
        {
            var categories = await _db.Categories.ToListAsync();

            return _mapper.Map<List<CategoryViewModel>>(categories);
        }

        public async Task<List<BrandViewModel>> GetAllBrand()
        {
            var brands = await _db.Brands.ToListAsync();

            return _mapper.Map<List<BrandViewModel>>(brands);
        }

        public async Task<List<ProductViewModel>> GetAllProduct()
        {
            var product = await _db.Products.ToListAsync();

            return _mapper.Map<List<ProductViewModel>>(product);
        }

        public async Task<List<StoreWarehouseViewModel>> GetAllStoreWarehouse()
        {
            var storeWarehouse = await _db.StoreWarehouses.ToListAsync();

            return _mapper.Map<List<StoreWarehouseViewModel>>(storeWarehouse);
        }

        public async Task<CategoryViewModel> DeleteCategory(CategoryViewModel model)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return new CategoryViewModel();
        }

        public async Task<BrandViewModel> DeleteBrand(BrandViewModel model)
        {
            var brand = await _db.Brands.FirstOrDefaultAsync(x => x.Id == model.Id);

            _db.Brands.Remove(brand);
            await _db.SaveChangesAsync();

            return new BrandViewModel();
        }

        public async Task<ProductViewModel> DeleteProduct(ProductViewModel model)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == model.Id);

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return new ProductViewModel();
        }

        public async Task<StoreWarehouseViewModel> DeleteStoreWarehouse(StoreWarehouseViewModel model)
        {
            var storeWarehouse = await _db.StoreWarehouses.FirstOrDefaultAsync(x => x.Id == model.Id);

            _db.StoreWarehouses.Remove(storeWarehouse);
            await _db.SaveChangesAsync();

            return new StoreWarehouseViewModel();
        }
    }
}