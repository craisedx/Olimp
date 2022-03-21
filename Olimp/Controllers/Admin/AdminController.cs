using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Olimp.Business.Interfaces;
using Olimp.ViewModels.Brand;
using Olimp.ViewModels.Category;
using Olimp.ViewModels.Product;
using Olimp.ViewModels.StoreWarehouse;

namespace Olimp.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<JsonResult> CreateCategory(CategoryViewModel model)
        {
            var category = await _adminService.CreateCategory(model);

            return Json(category);
        }

        [HttpPost]
        public async Task<JsonResult> CreateBrand(BrandViewModel model)
        {
            var brand = await _adminService.CreateBrand(model);

            return Json(brand);
        }

        [HttpPost]
        public async Task<JsonResult> CreateProduct(ProductViewModel model)
        {
            var product = await _adminService.CreateProduct(model);

            return Json(product);
        }

        [HttpPost]
        public async Task<JsonResult> CreateStoreWarehouse(StoreWarehouseViewModel model)
        {
            var storeWarehouse = await _adminService.CreateStoreWarehouse(model);

            return Json(storeWarehouse);
        }

        [HttpPost]
        public async Task<JsonResult> EditCategory(CategoryViewModel model)
        {
            var category = await _adminService.EditCategory(model);

            return Json(category);
        }

        [HttpPost]
        public async Task<JsonResult> EditBrand(BrandViewModel model)
        {
            var brand = await _adminService.EditBrand(model);

            return Json(brand);
        }

        [HttpPost]
        public async Task<JsonResult> EditProduct(ProductViewModel model)
        {
            var product = await _adminService.EditProduct(model);

            return Json(product);
        }
        
        [HttpPost]
        public async Task<JsonResult> EditStoreWarehouse(StoreWarehouseViewModel model)
        {
            var storeWarehouse = await _adminService.EditStoreWarehouse(model);

            return Json(storeWarehouse);
        }

        [HttpGet]
        public async Task<JsonResult> GetAllCategory()
        {
            var category = await _adminService.GetAllCategory();

            return Json(category);
        }

        [HttpGet]
        public async Task<JsonResult> GetAllBrand()
        {
            var brand = await _adminService.GetAllBrand();

            return Json(brand);
        }

        [HttpGet]
        public async Task<JsonResult> GetAllProduct()
        {
            var product = await _adminService.GetAllProduct();

            return Json(product);
        }

        [HttpGet]
        public async Task<JsonResult> GetAllStoreWarehouse()
        {
            var storeWarehouse = await _adminService.GetAllStoreWarehouse();

            return Json(storeWarehouse);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteCategory(CategoryViewModel model)
        {
            var category = await _adminService.DeleteCategory(model);

            return Json(category);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteBrand(BrandViewModel model)
        {
            var brand = await _adminService.DeleteBrand(model);

            return Json(brand);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteProduct(ProductViewModel model)
        {
            var product = await _adminService.DeleteProduct(model);

            return Json(product);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteStoreWarehouse(StoreWarehouseViewModel model)
        {
            var storeWarehouse = await _adminService.DeleteStoreWarehouse(model);

            return Json(storeWarehouse);
        }
    }
}