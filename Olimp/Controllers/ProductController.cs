using Microsoft.AspNetCore.Mvc;
using Olimp.Business.Interfaces;
using Olimp.ViewModels.Basket;
using System.Threading.Tasks;

namespace Olimp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IBasketService basketService;

        public ProductController(
            IProductService productService,
            IBasketService basketService)
        {
            this.basketService = basketService;
            this.productService = productService;
        }
        
        public async Task<IActionResult> Product(int id)
        {
            var product = await productService.GetProduct(id);

            return product != null ? View(product) : RedirectToAction("MainPage");
        }

        public async Task<IActionResult> MainPage()
        {
            var products = await productService.GetAllProducts();

            return View(products);
        }

        public async Task<IActionResult> UserBasket(string id)
        {
            var userBasket = await basketService.GetUserBasket(id);

            return View(userBasket);
        }

        public async Task<IActionResult> AddProductToBasket(
            BasketStoreWarehouseViewModel basketStoreWarehouseViewModel)
        {
            await basketService.AddProductToBasket(basketStoreWarehouseViewModel);

            return RedirectToAction("Product", new {id =basketStoreWarehouseViewModel.StoreWarehouseId });
        }

        public async Task<IActionResult> DeleteProductInBasket(int id, string userId)
        {
            await basketService.DeleteProductInBasket(id, userId);

            return RedirectToAction("UserBasket", new { id = userId });
        }

        public async Task<IActionResult> AddOrder(string userId)
        {
            await basketService.AddOrder(userId);

            return RedirectToAction("UserBasket", new { id = userId });
        }

        public async Task<IActionResult> ShowOrders(string id)
        {
            var orders = await basketService.GetOrdersByUserId(id);

            return View(orders);
        }

        public async Task<IActionResult> Order(int id)
        {
            var order = await basketService.GetOrderById(id);

            return View(order);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
