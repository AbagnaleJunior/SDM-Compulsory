using SDM_Compulsory.Domain.IServices;


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