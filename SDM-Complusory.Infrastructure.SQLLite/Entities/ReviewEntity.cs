using System;

namespace SDM_Compulsory.Infrastructure.SQLLite.Entities
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
