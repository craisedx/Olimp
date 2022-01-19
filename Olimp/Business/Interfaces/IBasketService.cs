using Olimp.Models;
using Olimp.ViewModels.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olimp.Business.Interfaces
{
    public interface IBasketService
    {
        /// <summary>
        /// Get User basket.
        /// </summary>
        /// <param name="id">Basket id.</param>
        /// <returns>All elements user basket.</returns>
        Task<List<BasketStoreWarehouseViewModel>> GetUserBasket(string id);

        /// <summary>
        /// Add product to basket.
        /// </summary>
        /// <param name="basketStoreWarehouseViewModel">View model all products in a basket.</param>
        Task AddProductToBasket(BasketStoreWarehouseViewModel basketStoreWarehouseViewModel);

        /// <summary>
        /// Delete product to basket.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="userId">User id.</param>
        Task DeleteProductInBasket(int id, string userId);

        /// <summary>
        /// Add order.
        /// </summary>
        /// <param name="userId">User id.</param>
        Task AddOrder(string userId);

        /// <summary>
        /// Get orders by user id.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>List of orders.</returns>
        Task<List<Order>> GetOrdersByUserId(string id);

        /// <summary>
        /// Get orders by id.
        /// </summary>
        /// <param name="id">Order id.</param>
        /// <returns>Order.</returns>
        Task<List<OrderStoreWarehouses>> GetOrderById(int id);
    }
}
