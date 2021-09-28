using SDM_Compulsory.Domain.IServices;
using SDM_Compulsory.Application.IRepositories;
using SDM_Complusory.Infrastructure.SQLLite.Repositories;
using SDM_Compulsory.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using SDM_Complusory.Infrastructure.SQLLite;

namespace SDM_Compulsory.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var serviceCollection = new ServiceCollection();


            //serviceCollection.AddScoped<IReviewRepository, RatingRepository>();

            //serviceCollection.AddScoped<IReviewService, ReviewService>();

            //var serviceProvider = serviceCollection.BuildServiceProvider();

            //var reviewService = serviceProvider.GetRequiredService<IReviewService>();


            //var startUp = new Menu(reviewService);
            //startUp.Start();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ReviewsDbContext>(options => options.UseSqlite("Data Source=D:\\School\\Review.db;"));
            serviceCollection.AddScoped<IReviewRepository, RatingRepository>();
            serviceCollection.AddScoped<IReviewService, ReviewService>();



            var serviceProvider = serviceCollection.BuildServiceProvider();
            var reviewService = serviceProvider.GetRequiredService<IReviewService>();

            Console.WriteLine(reviewService.GetAverageRateFromReviewer(1).ToString());
            //var methods = typeof(ReviewService)
            //    .GetMethods(BindingFlags.Public | BindingFlags.Instance);

            //foreach(var method in methods)
            //{
            //    method.Invoke(reviewService, new object[0]);
            //}

            Console.ReadLine();
        }

    }
}
