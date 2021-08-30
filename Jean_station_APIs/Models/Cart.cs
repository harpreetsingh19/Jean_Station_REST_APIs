using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cartid { get; set; }
        public string Userid { get; set; }
        public int Productid { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
    }
}
