using System.Collections.Generic;
using System.Threading.Tasks;
using Olimp.ViewModels.Brand;
using Olimp.ViewModels.Category;
using Olimp.ViewModels.Order;
using Olimp.ViewModels.Product;
using Olimp.ViewModels.StoreWarehouse;

namespace Olimp.Business.Interfaces
{
    public interface IAdminService
    {
        public Task<CategoryViewModel> CreateCategory(CategoryViewModel model);
        public Task<BrandViewModel> CreateBrand(BrandViewModel model);
        public Task<ProductViewModel> CreateProduct(ProductViewModel model);
        public Task<StoreWarehouseViewModel> CreateStoreWarehouse(StoreWarehouseViewModel model);
        public Task<CategoryViewModel> EditCategory(CategoryViewModel model);
        public Task<BrandViewModel> EditBrand(BrandViewModel model);
        public Task<ProductViewModel> EditProduct(ProductViewModel model);
        public Task<StoreWarehouseViewModel> EditStoreWarehouse(StoreWarehouseViewModel model);
        public Task<OrderViewModel> EditOrder(OrderViewModel model);
        public Task<List<CategoryViewModel>> GetAllCategory();
        public Task<List<BrandViewModel>> GetAllBrand();
        public Task<List<ProductViewModel>> GetAllProduct();
        public Task<List<StoreWarehouseViewModel>> GetAllStoreWarehouse();
        public Task<List<StatusViewModel>> GetAllStatus();
        public Task<List<OrderViewModel>> GetAllOrder();
        public Task<CategoryViewModel> DeleteCategory(CategoryViewModel model);
        public Task<BrandViewModel> DeleteBrand(BrandViewModel model);
        public Task<ProductViewModel> DeleteProduct(ProductViewModel model);
        public Task<StoreWarehouseViewModel> DeleteStoreWarehouse(StoreWarehouseViewModel model);
    }
}