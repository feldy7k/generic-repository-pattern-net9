using System.ComponentModel.DataAnnotations.Schema;

namespace DemoGenericRepositoryPattern.Models
{
    [Table("Brand")]
    public class Brand
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
