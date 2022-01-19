using Olimp.ViewModels.Product;

namespace Olimp.ViewModels.StoreWarehouse
{
    public class StoreWarehouseViewModel
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets product.
        /// </summary>
        public ProductViewModel Product { get; set; }

        /// <summary>
        /// Gets or sets product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets price
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets discount.
        /// </summary>
        public int Discount { get;set; }
    }
}
