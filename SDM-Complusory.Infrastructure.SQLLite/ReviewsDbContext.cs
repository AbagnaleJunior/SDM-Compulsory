using Microsoft.EntityFrameworkCore;
using SDM_Compulsory.Infrastructure.SQLLite.Entities;

namespace SDM_Compulsory.Infrastructure.SQLLite
{
    public class ReviewsDbContext : DbContext
    {
        public ReviewsDbContext(DbContextOptions<ReviewsDbContext> opt) : base(opt)
        {
        }
        
        public DbSet<ReviewEntity> Ratings { get; set; }
    }
}

