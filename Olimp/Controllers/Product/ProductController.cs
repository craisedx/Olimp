using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Olimp.Business.Interfaces;
using Olimp.Models;
using Olimp.ViewModels.Basket;
using Olimp.ViewModels.FeedBack;

namespace Olimp.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IBasketService basketService;
        private readonly IAdminService adminService;

        public ProductController(
            IProductService productService,
            IAdminService adminService,
            IBasketService basketService)
        {
            this.basketService = basketService;
            this.adminService = adminService;
            this.productService = productService;
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> Brand(int id)
        {
            var brand = await productService.GetBrandById(id);

            return View(brand);
        }
        
        public async Task<IActionResult> Product(int id)
        {
            var product = await productService.GetProduct(id);
            var productComments = await productService.GetCommentsByStoreWarehouseId(id);

            ViewBag.AllComments = productComments;
            
            return product != null ? View(product) : RedirectToAction("MainPage");
        }

        public async Task<IActionResult> AddFeedBack(int rating, int product, string message)
        {
            var userId = User.Claims.ElementAt(0).Value;

            var model = new FeedBackViewModel()
            {
                UserId = userId,
                Star = rating,
                Text = message,
                StoreWarehouseId = product
            };

            var messageToUser = await productService.AddFeedBack(model);
            
            return Json(messageToUser);
        }

        public async Task<IActionResult> MainPage()
        {
            var products = await productService.GetLastProductsByCount(6);

            ViewBag.Brands = await productService.GetBrandsByCount(4);
            return View(products);
        }

        public async Task<IActionResult> AllProducts(int categoriesId, int brandId, double? priceStart, double? priceEnd, int sortType)
        {
            var categories = await productService.GetAllCategories();
            var brands = await adminService.GetAllBrand();
            
            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            ViewBag.SelectedSort = sortType;
            ViewBag.PriceStart = priceStart;
            ViewBag.PriseEnd = priceEnd;
            

            if (categoriesId != 0)
            {
                ViewBag.SelectCategoriesId = categoriesId;
            }
            
            if (brandId != 0)
            {
                ViewBag.SelectBrandsId = brandId;
            }

            var products =
                await productService.GetProductsByFilters(categoriesId, brandId, priceStart, priceEnd, sortType);

            if (products != null) return View(products);
            
            var productsWithOutFilters = await productService.GetAllProducts();

            return View(productsWithOutFilters);
        }

        public async Task<IActionResult> AllBrands()
        {
            var brands = await adminService.GetAllBrand();

            return View(brands);
        }

        public async Task<IActionResult> Search(string productName)
        {
            var products = await productService.GetProductsByName(productName);

            return View(products);
        }

        public async Task<IActionResult> UserBasket(string id)
        {
            var userBasket = await basketService.GetUserBasket(id);
            List<string> address = new List<string>();
            address.Add("ул. Козлова, 35");
            address.Add("ул. Сергея Есенина, 6");
            address.Add("Проспект Независимости, 58");
            ViewBag.Address = address;

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

        public async Task<IActionResult> AddOrder(string userId, string address)
        {
            await basketService.AddOrder(userId,address);

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
