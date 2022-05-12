using Olimp.ViewModels.Brand;
using Olimp.ViewModels.Product;
using Olimp.ViewModels.StoreWarehouse;
using System.Collections.Generic;
using System.Threading.Tasks;
using Olimp.ViewModels.Category;

namespace Olimp.Business.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Get product in warehouse by id.
        /// </summary>
        /// <param name="id">Product id in warehouse.</param>
        /// <returns>Product in warehouse.</returns>
        Task<StoreWarehouseViewModel> GetProduct(int id);

        /// <summary>
        /// Get all products by category id.
        /// </summary>
        /// <param name="categoryId">Product id in warehouse.</param>
        /// <returns>Products by category id.</returns>
        Task<List<StoreWarehouseViewModel>> GetProductsByCategoryId(int categoryId);

        /// <summary>
        /// Get all products in warehouse.
        /// </summary>
        /// <returns>All products in warehouse.</returns>
        Task<List<StoreWarehouseViewModel>> GetAllProducts();

        /// <summary>
        /// Get products by filters ids.
        /// </summary>
        /// <param name="categoryId">Category id in warehouse.</param>
        /// <param name="brandId">Brand id in warehouse.</param>
        /// <param name="priceStart">Price start.</param>
        /// <param name="priceEnd">Price end.</param>
        /// <param name="sortType">Type sort.</param>
        /// <returns>Products by filters ids.</returns>
        Task<List<StoreWarehouseViewModel>> GetProductsByFilters(int categoryId, int brandId,
            int? priceStart, int? priceEnd, int sortType);

        /// <summary>
        /// Get products by name.
        /// </summary>
        /// <param name="productName">Product name.</param>
        /// <returns>All products like name.</returns>
        Task<List<StoreWarehouseViewModel>> GetProductsByName(string productName);

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>All categories.</returns>
        Task<List<CategoryViewModel>> GetAllCategories();
    }
}
