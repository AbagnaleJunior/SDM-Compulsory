using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM_Compulsory.Infrastructure.MSSQL.Entities
{
    public class ReviewEntity
    {
        public int Id { get; set; }
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
    }
}
