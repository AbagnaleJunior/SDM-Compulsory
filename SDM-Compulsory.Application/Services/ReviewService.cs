using SDM_Compulsory.Domain.IServices;
using System.Collections.Generic;

namespace SDM_Compulsory.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositories.IReviewRepository _repo;
       

        public ReviewService(IRepositories.IReviewRepository repo)
        {
            _repo = repo;
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _repo.GetNumberOfReviewsFromReviewer(reviewer);
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            return _repo.GetAverageRateFromReviewer(reviewer);
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _repo.GetNumberOfRatesByReviewer(reviewer, rate);
        }

        public int GetNumberOfReviews(int movie)
        {
            return _repo.GetNumberOfReviews(movie);
        }
        
        public double GetAverageRateOfMovie(int movie)
        {
            return _repo.GetAverageRateOfMovie(movie);
        }
        
        public int GetNumberOfRates(int movie, int rate)
        {
            return _repo.GetNumberOfRates(movie, rate);
        }
        
        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return _repo.GetMoviesWithHighestNumberOfTopRates();
        }
        
        public List<int> GetMostProductiveReviewer()
        {
            return _repo.GetMostProductiveReviewer();
        }
        
        public List<int> GetTopRatedMovies(int amount)
        {
            return _repo.GetTopRatedMovies(amount);
        }
        
        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _repo.GetTopMoviesByReviewer(reviewer);
        }
        
        public List<int> GetReviewersByMovie(int movie)
        {
            return _repo.GetReviewersByMovie(movie);
        }
    }
}
