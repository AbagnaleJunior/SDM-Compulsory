using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDM_Complusory.Infrastructure.SQLLite.Entities;

namespace SDM_Complusory.Infrastructure.SQLLite
{
    public class ReviewsDbContext : DbContext
    {

        public ReviewsDbContext(DbContextOptions<ReviewsDbContext> opt) : base(opt)
        {

        }
        
        public DbSet<RatingEntity> Ratings { get; set; }
        
    }
}

