using System.ComponentModel.DataAnnotations.Schema;

namespace DemoGenericRepositoryPattern.Models
{
    [Table("Category")]
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
