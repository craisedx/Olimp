using Olimp.ViewModels.Brand;
using Olimp.ViewModels.Category;

namespace Olimp.ViewModels.Product
{
    public class ProductViewModel
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets category.
        /// </summary>
        public CategoryViewModel Category { get; set; }

        /// <summary>
        /// Gets or sets category id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets brand.
        /// </summary>
        public BrandViewModel Brand { get; set; }

        /// <summary>
        /// Gets or sets brand id.
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Gets or sets title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; }
    }
}
