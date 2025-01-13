using System.ComponentModel.DataAnnotations.Schema;

namespace DemoGenericRepositoryPattern.Models
{
    [Table("Product")]
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
