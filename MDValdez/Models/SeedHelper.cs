using System.Collections;
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
                    Name = "Mooie Jas",
                    Category = "coat",
                    Description = "De beste jas ooit",
                    OrderCode = "beste154"
                },

                 new Product()
                {
                    ProductId = 2,
                    Name = "Mooie sieraden",
                    Category= "jewelry",
                    Description = "Gouden sieraden",
                    OrderCode = "beste11"
                },

                new Product()
                {
                    ProductId = 3,
                    Name = "Beste schoenen ooit",
                    Category = "shoes",
                    Description = "De beste schoenen ooit gemaakt",
                    OrderCode = "beste1122"
                }
            };
            return products;
        }

        public static IEnumerable<Customer> GetAccoutsSeeds()
        {
            var customers = new List<Customer>()
            {
                new Customer () 
                {
                    AccountId = 1,
                    adress = "Landlaan 1",
                    CustomerName = "jan",
                    Email = "jantest@hotmail.com",
                    Password = "admin123"
                    
                },

               new Customer ()
                {
                    AccountId = 2,
                    adress = "Kade 3",
                    CustomerName = "peter",
                    Email = "petertest@hotmail.com",
                    Password = "welcome"
                },

               new Customer ()
                {
                    AccountId = 3,
                    adress = "Sonseweg 15",
                    CustomerName = "jost",
                    Email = "josttest@hotmail.com",
                    Password = "welcome2"
                },
            };

            return customers;
        }

        public static IEnumerable<ShoppingCart> GetShoppingCartsSeeds()
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

        public static IEnumerable<ShoppingCartProduct> GetShoppingCartProductsSeeds()
        {
            var shoppingProducts = new List<ShoppingCartProduct>()
            {
                new ShoppingCartProduct()
                {
                    ProductId = 1,
                    ShoppingCartId = 2
                },
                new ShoppingCartProduct()
                {
                    ProductId = 2,
                    ShoppingCartId = 2
                },

                new ShoppingCartProduct()
                {
                    ProductId = 1,
                    ShoppingCartId = 3
                }
            };

            return shoppingProducts;
        }
        public static IEnumerable<Order> GetOrdersSeeds()
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
