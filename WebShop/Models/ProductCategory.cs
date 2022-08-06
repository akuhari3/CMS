using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        [NotMapped]
        public string ProductTitle { get; set; }
        [NotMapped]
        [DisplayName("Category")]
        public string CategoryTitle { get; set; }
    }
}
