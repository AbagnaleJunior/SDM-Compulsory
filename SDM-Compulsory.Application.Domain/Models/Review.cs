using System;

namespace SDM_Compulsory.Domain.Models
{
    public class Review
    {
        int Reviewer { get; set; }
        int Movie { get; set; }
        int Grade { get; set; }
        DateTime ReviewDate { get; set; }
    }
}
