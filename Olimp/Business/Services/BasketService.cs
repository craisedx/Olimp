using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Olimp.Business.Interfaces;
using Olimp.Migrations;
using Olimp.Models;
using Olimp.ViewModels.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olimp.Business.Services
{
    public class BasketService : IBasketService
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext db;
        public BasketService(ApplicationContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get User basket.
        /// </summary>
        /// <param name="id">Basket id.</param>
        /// <returns>All elements user basket.</returns>
        public async Task<List<BasketStoreWarehouseViewModel>> GetUserBasket(string id)
        {
            var basket = await db.Baskets.FirstOrDefaultAsync(u => u.UserId == id);

            var userBasket = await db.BasketStoreWarehouses.Where(x => x.Basket == basket)
                .Include(x => x.StoreWarehouse)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Brand)
                .Include(x => x.StoreWarehouse.Product)
                .ThenInclude(x => x.Category)
                .ToListAsync();

            return mapper.Map<List<BasketStoreWarehouseViewModel>>(userBasket);
        }

        /// <summary>
        /// Add product to basket.
        /// </summary>
        /// <param name="basketStoreWarehouseViewModel">View model all products in a basket.</param>
        public async Task AddProductToBasket(BasketStoreWarehouseViewModel basketStoreWarehouseViewModel)
        {
            var userBasket = await db.Baskets
                .FirstOrDefaultAsync(x => x.User.Id == basketStoreWarehouseViewModel.UserId);

            var storeWarehouse = await db.StoreWarehouses
                .FirstOrDefaultAsync(x => x.Id == basketStoreWarehouseViewModel.StoreWarehouseId);

            db.BasketStoreWarehouses.Add(new BasketStoreWarehouse
            {
                Basket = userBasket,
                StoreWarehouse = storeWarehouse,
                Quantity = basketStoreWarehouseViewModel.Quantity
            });

            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Delete product to basket.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <param name="userId">User id.</param>
        public async Task DeleteProductInBasket(int id, string userId)
        {
            var basket = await db.Baskets.FirstOrDefaultAsync(x => x.User.Id == userId);
            var product = await db.BasketStoreWarehouses
                .FirstOrDefaultAsync(x => x.StoreWarehouse.Id == id && x.Basket.User.Id == userId);

            if (product != null) db.BasketStoreWarehouses.Remove(product);

            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Add order.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="address"></param>
        public async Task AddOrder(string userId, string address)
        {
            var basket = await db.BasketStoreWarehouses
                .Include(x => x.StoreWarehouse)
                .Where(x => x.Basket.User.Id == userId).ToListAsync();

            var orderId = await GetOrderId(userId, address);
            
            foreach(var item in basket)
            {
                await db.OrderStoreWarehouses.AddAsync(new OrderStoreWarehouses
                {
                    StoreWarehouseId = item.StoreWarehouse.Id,
                    OrderId = orderId,
                    Quantity = item.Quantity
                });

                item.StoreWarehouse.Quantity -= item.Quantity;
            }

            db.RemoveRange(basket);

            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Get orders by user id.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>List of orders.</returns>
        public async Task<List<Order>> GetOrdersByUserId(string userId)
        {
            var orders = await db.Orders.Include(x => x.Status).Where(x => x.User.Id == userId).ToListAsync();

            return orders;
        }

        /// <summary>
        /// Get orders by id.
        /// </summary>
        /// <param name="id">Order id.</param>
        /// <returns>Order.</returns>
        public async Task<List<OrderStoreWarehouses>> GetOrderById(int id)
        {
            var order = await db.OrderStoreWarehouses
                .Include(x => x.StoreWarehouse)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Brand)
                .Include(x => x.StoreWarehouse.Product)
                .ThenInclude(x => x.Category)
                .Where(x => x.Order.Id == id).ToListAsync();

            return order;
        }

        private async Task<int> GetOrderId(string userId, string address)
        {
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                StatusId = 1,
                FinalPrice = await GetOrderFullPriceByUserId(userId),
                StoreAddress = address
            };

            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();

            return order.Id;
        }

        private async Task<double> GetOrderFullPriceByUserId(string userId)
        {
            var fullPrice = await db.BasketStoreWarehouses
                .Where(x => x.Basket.User.Id == userId)
                .SumAsync(x => x.Quantity * (x.StoreWarehouse.Price - (x.StoreWarehouse.Price * (x.StoreWarehouse.Discount/100.00))));

            return fullPrice;
        }
    }
}
