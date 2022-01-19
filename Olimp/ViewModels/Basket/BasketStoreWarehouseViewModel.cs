using Olimp.ViewModels.StoreWarehouse;

namespace Olimp.ViewModels.Basket
{
    public class BasketStoreWarehouseViewModel
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets store warehouse.
        /// </summary>
        public StoreWarehouseViewModel StoreWarehouse { get; set; }

        /// <summary>
        /// Gets or sets store warehouse id.
        /// </summary>
        public int StoreWarehouseId { get; set; }

        /// <summary>
        /// Gets or sets basket.
        /// </summary>
        public BasketViewModel Basket { get; set; }

        /// <summary>
        /// Gets or sets basket id.
        /// </summary>
        public int BasketId { get; set; }

        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        public string UserId { get; set; }
    }
}
