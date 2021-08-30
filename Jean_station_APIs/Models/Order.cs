using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Orderid { get; set; }
        public string Status { get; set; }
        public int Productid { get; set; }
        public string Userid { get; set; }
        public string Buyername { get; set; }
        public string Phonenumber { get; set; }
        public string Mop { get; set; }
        public string Image { get; set; }
        public string Productname { get; set; }
        public int Price { get; set; }
    }
}
