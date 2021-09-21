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
            string promotionId = "Promotion1";
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
            try
            {
                Cart cart = engineService.CheckOut(promotionId, cartService.GetCart());
                Console.WriteLine($"Total Amount for Scenario A after promotion: {promotionId} is applied is: {cart.TotalAmount}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Scenario B
            cartService = provider.GetService<ICartService>();
            cartService.AddToCart('A', 5);
            cartService.AddToCart('B', 5);
            cartService.AddToCart('C', 1);
            try
            {
                Cart cart = engineService.CheckOut(promotionId, cartService.GetCart());
                Console.WriteLine($"Total Amount for Scenario B after promotion: {promotionId} is applied is: {cart.TotalAmount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Scenario B
            cartService = provider.GetService<ICartService>();
            cartService.AddToCart('A', 3);
            cartService.AddToCart('B', 5);
            cartService.AddToCart('C', 1);
            cartService.AddToCart('D', 1);
            try
            {
                Cart cart = engineService.CheckOut(promotionId, cartService.GetCart());
                Console.WriteLine($"Total Amount for Scenario C after promotion: {promotionId} is applied is: {cart.TotalAmount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

    }
}
