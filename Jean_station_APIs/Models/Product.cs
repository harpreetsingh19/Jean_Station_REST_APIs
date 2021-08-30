using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Productid { get; set; }
        public string Productname { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
