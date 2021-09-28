using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
