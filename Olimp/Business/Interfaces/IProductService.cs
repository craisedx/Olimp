using Olimp.ViewModels.Brand;
using Olimp.ViewModels.Product;
using Olimp.ViewModels.StoreWarehouse;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// Get all products in warehouse.
        /// </summary>
        /// <returns>All products in warehouse.</returns>
        Task<List<StoreWarehouseViewModel>> GetAllProducts();
    }
}
