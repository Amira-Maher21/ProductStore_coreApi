using System.ComponentModel.DataAnnotations.Schema;

namespace ProductStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int CatogoryId { get; set; }

        [ForeignKey("CatogoryId")]
        public Catagory? Catagory { get; set; }


    }
}
