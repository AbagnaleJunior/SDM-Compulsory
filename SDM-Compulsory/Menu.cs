using SDM_Compulsory.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDM_Compulsory
{
    public class Menu
    {
        private IReviewService _reviewService;

        public Menu(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public void Start()
        {
            
            
        }
    }

}