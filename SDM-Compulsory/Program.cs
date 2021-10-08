using SDM_Compulsory.Domain.IServices;
using SDM_Compulsory.Application.IRepositories;
using SDM_Compulsory.Infrastructure.SQLLite.Repositories;
using SDM_Compulsory.Application.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using SDM_Compulsory.Infrastructure.SQLLite;
using System.Collections.Generic;

namespace SDM_Compulsory.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<ReviewsDbContext>(options => options.UseSqlite("Data Source=../../../../SDM-Complusory.Infrastructure.SQLLite/Review.db;"));
            serviceCollection.AddScoped<IReviewRepository, ReviewRepository>();
            serviceCollection.AddScoped<IReviewService, ReviewService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var reviewService = serviceProvider.GetRequiredService<IReviewService>();

            Console.WriteLine(reviewService.GetAverageRateFromReviewer(1).ToString());

            PrintList<int>(reviewService.GetTopMoviesByReviewer(148));
            
            Console.ReadLine();
        }

        static void PrintList <T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
