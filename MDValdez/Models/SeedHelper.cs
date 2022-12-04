using System.Xml.Linq;

namespace MDValdez.Models
{
    public class SeedHelper
    {
        public static IEnumerable<Product> GetProductsSeeds() 
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    Name = "Mooie schoenen",
                    Description = "De beste schoenen ooit",
                    OrderCode = "beste154"
                },

                 new Product()
                {
                    ProductId = 2,
                    Name = "T-Shirt",
                    Description = "Een leuke zomerse T-Shirt",
                    OrderCode = "beste11"
                },

                new Product()
                {
                    ProductId = 3,
                    Name = "Broek",
                    Description = "Geweldige broek",
                    OrderCode = "beste1122"
                }
            };
            return products;
        }

        internal static IEnumerable<Customer> GetAccoutsSeeds()
        {
            var customers = new List<Customer>()
            {
                new Customer () 
                {
                    AccountId = 1,
                    adress = "Landlaan 1",
                    CustomerName = "Jan",
                    Email = "jantest@hotmail.com",
                    
                },

               new Customer ()
                {
                    AccountId = 2,
                    adress = "Kade 3",
                    CustomerName = "Peter",
                    Email = "petertest@hotmail.com",
                },

               new Customer ()
                {
                    AccountId = 3,
                    adress = "Sonseweg 15",
                    CustomerName = "Jost",
                    Email = "josttest@hotmail.com",
                },
            };

            return customers;
        }

        internal static IEnumerable<ShoppingCart> GetShoppingCartsSeeds()
        {
            var shoppinCarts = new List<ShoppingCart>()
            {
                new ShoppingCart()
                {
                    ShoppingCartId = 1,
                    Date = DateTime.Now,
                    TotalPrice = 100,
                    CustomerId = 2,


                },



               new ShoppingCart()
                {
                    ShoppingCartId = 2,
                    Date = DateTime.Now,
                    TotalPrice = 200,
                    CustomerId = 1,

                },

                new ShoppingCart()
                {
                    ShoppingCartId = 3,
                    Date = DateTime.Now,
                    TotalPrice = 300,
                    CustomerId = 1,

                },
            };

            return shoppinCarts;
        }

        internal static IEnumerable<Order> GetOrdersSeeds()
        {
            var orders = new List<Order>()
            {
                new Order()
                {
                    OrderId = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.Now,
                    OrderAmount = 250.50,

                },

                new Order()
                {
                    OrderId = 2,
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                    OrderAmount = 100,

                },

                 new Order()
                {
                    OrderId = 3,
                    CustomerId = 3,
                    OrderDate = DateTime.Now,
                    OrderAmount = 300,

                },
            };

            return orders;
        }
    }
    
}
