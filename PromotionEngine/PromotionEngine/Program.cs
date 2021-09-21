using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Models;
using PromotionEngine.Services;
using System;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceCollection services = new ServiceCollection();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IPromotionEngineService, PromotionEngineService>();
            services.AddTransient<ICartService, CartService>();
            ServiceProvider provider = services.BuildServiceProvider();

            var engineService = provider.GetService<IPromotionEngineService>();
            //Scenario A
            var cartService = provider.GetService<ICartService>();
            cartService.AddToCart('A', 1);
            cartService.AddToCart('B', 1);
            cartService.AddToCart('C', 1);
            Cart cart = engineService.CheckOut("Promotion1", cartService.GetCart());
            Console.WriteLine($"Total Amount for Scenario A after promotion is : {cart.TotalAmount}");

            //Scenario B
            cartService = provider.GetService<ICartService>();
            cartService.AddToCart('A', 5);
            cartService.AddToCart('B', 5);
            cartService.AddToCart('C', 1);
            cart = engineService.CheckOut("Promotion1", cartService.GetCart());
            Console.WriteLine($"Total Amount for Scenario B after promotion is : {cart.TotalAmount}");

            //Scenario B
            cartService = provider.GetService<ICartService>();
            cartService.AddToCart('A', 3);
            cartService.AddToCart('B', 5);
            cartService.AddToCart('C', 1);
            cartService.AddToCart('D', 1);
            cart = engineService.CheckOut("Promotion1", cartService.GetCart());
            Console.WriteLine($"Total Amount for Scenario C after promotion is : {cart.TotalAmount}");

            Console.ReadLine();
        }

    }
}
