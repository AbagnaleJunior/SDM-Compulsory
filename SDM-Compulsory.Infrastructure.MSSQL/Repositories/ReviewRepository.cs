using SDM_Compulsory.Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM_Compulsory.Infrastructure.MSSQL.Repositories
{
    class ReviewRepository : IReviewRepository
    {
        private readonly ReviewsDbSQLContext _ctx;

        public ReviewRepository(ReviewsDbSQLContext ctx)
        {
            _ctx = ctx;
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _ctx.Ratings.Count(x => x.Reviewer == reviewer);
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            return _ctx.Ratings.Where(r => r.Reviewer == reviewer).Average(r => r.Grade);
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _ctx.Ratings.Count(r => r.Reviewer == reviewer && r.Grade == rate);
        }

        public int GetNumberOfReviews(int movie)
        {
            return _ctx.Ratings.Count(r => r.Movie == movie);
        }

        public double GetAverageRateOfMovie(int movie)
        {
            return _ctx.Ratings.Where(r => r.Movie == movie).Average(r => r.Grade);
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return _ctx.Ratings.Count(r => r.Movie == movie && r.Grade == rate);
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return _ctx.Ratings.Where(r => r.Grade == 5).Select(r => r.Movie).ToList();
        }

        public List<int> GetMostProductiveReviewer()
        {
            var groupedRatings =
                _ctx.Ratings
                .OrderByDescending(x => x.Reviewer)
                .GroupBy(x => x.Reviewer)
                .Select(x => new { Id = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            var maxCount = groupedRatings.First().Count;

            return groupedRatings.Where(x => x.Count == maxCount).Select(r => r.Id).ToList();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            var groupedRatings = _ctx.Ratings
                .GroupBy(r => r.Movie)
                .Select(r => new
                {
                    Movie = r.Key,
                    AvgGrade = r.Average(g => g.Grade)
                })
                .OrderByDescending(r => r.AvgGrade)
                .Take(amount)
                .ToList();

            return groupedRatings.Select(r => r.Movie).ToList();


            //var groupedRatings =
            //    _ctx.Ratings
            //    .OrderByDescending(r => r.Movie)
            //    .GroupBy(r => r.Grade)
            //    .Select(r => new
            //    {
            //        Id = r.Key,
            //        Avg = r.Average(r => r.Grade),
            //        MovieId = r.Max(x => x.Movie)
            //    }).OrderByDescending(r => r.Avg).Take(amount).ToList();

            //List<int> movies = new List<int>();
            //foreach(var rating in groupedRatings)
            //{
            //    //movies.Add(_ctx.Ratings.Find(rating.Id).Movie);
            //    movies.Add(rating.MovieId);
            //}
            //return movies;
            ////return groupedRatings.Select(r => r.Id).Take(amount).ToList();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _ctx.Ratings
                .Where(r => r.Reviewer == reviewer)
                .OrderByDescending(r => r.Grade)
                .ThenBy(r => r.Date)
                .Select(r => r.Movie)
                .ToList();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return _ctx.Ratings
                .Where(r => r.Movie == movie)
                .OrderByDescending(r => r.Grade)
                .ThenBy(r => r.Date)
                .Select(r => r.Reviewer)
                .ToList();
        }
    }
}

