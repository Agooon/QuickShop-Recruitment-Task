using System.ComponentModel;

namespace QuickShop.CoreBusiness.Models
{
    /* Example of an item:
     "SKU":"SEN-b0dbc",
       "name":"Kask ochronny SEN-b0dbc",
       "description":"Kask ochronny Duis quis ex vestibulum, ullamcorper tortor vitae, sollicitudin arcu. SEN-b0dbc",
       "price":4.62,
       "currency":"PLN",
       "discount":14
     */
    public class Product
    {
        public string SKU { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DisplayName("Waluta")]
        public string Currency { get; set; }
        [DisplayName("Zniżka")]
        public float Discount { get; set; }
    }
}
