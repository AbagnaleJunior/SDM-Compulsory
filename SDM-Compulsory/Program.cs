using SDM_Compulsory.Domain.IServices;
using SDM_Compulsory.Application.IRepositories;
using SDM_Compulsory.Infrastructure.SQLLite.Repositories;
using SDM_Compulsory.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SDM_Compulsory.Infrastructure.SQLLite;

namespace SDM_Compulsory.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DEPENDENCY INJECTION "MAGIC CODE"
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<ReviewsDbContext>(options => options.UseSqlite("Data Source=../../../../SDM-Complusory.Infrastructure.SQLLite/Review.db;"));

            serviceCollection.AddScoped<IReviewRepository, ReviewRepository>();
            serviceCollection.AddScoped<IReviewService, ReviewService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var reviewService = serviceProvider.GetRequiredService<IReviewService>();

            var menu = new Menu(reviewService);
            menu.Start();
        }
    }
    
}

