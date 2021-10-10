using Microsoft.EntityFrameworkCore;
using SDM_Compulsory.Infrastructure.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM_Compulsory.Infrastructure.MSSQL
{
    public class ReviewsDbSQLContext : DbContext
    {
        public ReviewsDbSQLContext(DbContextOptions<ReviewsDbSQLContext> opt) : base(opt)
        {
        }

        public DbSet<ReviewEntity> Ratings { get; set; }
    }
}
