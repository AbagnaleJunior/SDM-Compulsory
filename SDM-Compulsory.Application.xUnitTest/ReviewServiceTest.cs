using SDM_Compulsory.Application.IRepositories;
using Xunit;
using Microsoft.EntityFrameworkCore;
using SDM_Compulsory.Infrastructure.SQLLite.Repositories;
using SDM_Compulsory.Infrastructure.SQLLite;
using SDM_Compulsory.Domain.IServices;
using SDM_Compulsory.Application.Services;
using System.Collections.Generic;

namespace SDM_Compulsory.Application.xUnitTest
{
    public class ReviewServiceTest
    {
        private readonly IReviewService _service;
        public ReviewServiceTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReviewsDbContext>();
            optionsBuilder.UseSqlite("Data Source=../../../ReviewTest.db;");

            ReviewsDbContext dbContext = new ReviewsDbContext(optionsBuilder.Options);
            IReviewRepository repo = new ReviewRepository(dbContext);
            _service = new ReviewService(repo);
        }

        //ID - REVIEWER - MOVIE - GRADE - DATE

        //9807	    1	1488844	    3	2005-09-06 00:00:00
        //9808	    1	822109	    5	2005-05-13 00:00:00
        //9809	    1	885013	    4	2005-10-19 00:00:00
        //10249	    1	387418	    1	2004-02-08 00:00:00
        //10323	    1	515436	    1	2005-02-13 00:00:00
        //10354	    2	2059652	    4	2005-09-05 00:00:00
        //10355	    2	1666394	    3	2005-04-19 00:00:00
        //10356	    2	1759415	    4	2005-04-22 00:00:00
        //10479	    2	387418	    1	2004-11-19 00:00:00
        //10495	    2	515436	    1	2005-02-13 00:00:00
        //525938	148	387418	    3	2005-12-11 00:00:00
        //528600	148	218497	    4	2004-12-20 00:00:00
        //528601	148	1114519	    3	2004-12-28 00:00:00
        //528602	148	267841	    3	2005-01-02 00:00:00
        //528603	148	964306	    2	2005-01-04 00:00:00
        //1001735	1	822109	    4	2005-05-13 00:00:00


        [Theory]
        [InlineData(1,6)]
        public void GetNumberOfReviewsFromReviewer(int reviewer, int expectedResult)
        {
            Assert.Equal(expectedResult, _service.GetNumberOfReviewsFromReviewer(reviewer));
        }

        [Theory]
        [InlineData(1, 3)]
        public void GetAverageRateFromReviewer(int reviewer, double expectedResult)
        {
            Assert.Equal(expectedResult, _service.GetAverageRateFromReviewer(reviewer));
        }

        [Theory]
        [InlineData(1, 1, 2)]
        public void GetNumberOfRatesByReviewer(int reviewer, int rate, int expectedResult)
        {
            Assert.Equal(expectedResult, _service.GetNumberOfRatesByReviewer(reviewer, rate));
        }

        [Theory]
        [InlineData(387418, 3)]
        public void GetNumberOfReviews(int movie, int expectedResult)
        {
            Assert.Equal(expectedResult, _service.GetNumberOfReviews(movie));
        }

        [Theory]
        [InlineData(387418, 1.6666666666666667)]
        [InlineData(515436, 1)]
        public void GetAverageRateOfMovie(int movie, double expectedResult)
        {
            Assert.Equal(expectedResult, _service.GetAverageRateOfMovie(movie));
        }

        [Theory]
        [InlineData(387418, 1, 2)]
        public void GetNumberOfRates(int movie, int rate, int expectedResult)
        {
            Assert.Equal(expectedResult, _service.GetNumberOfRates(movie, rate));
        }

        [Theory]
        [InlineData(1)]
        public void GetMoviesWithHighestNumberOfTopRates(int expectedResult)
        {
            Assert.Equal(expectedResult, _service.GetMoviesWithHighestNumberOfTopRates().Count);
        }

        [Theory]
        [InlineData(1)]
        public void GetMostProductiveReviewers(int expectedResult)
        {
            Assert.Equal(expectedResult, _service.GetMostProductiveReviewers().Count);
        }

        [Fact]
        public void GetTopRatedMovies()
        {
            List<int> result = new List<int>();
            result.Add(822109);
            result.Add(2059652);
            result.Add(1759415);
            result.Add(885013);
            result.Add(218497);
            result.Add(1666394);

            Assert.Equal(result, _service.GetTopRatedMovies(6));
        }

        [Fact]
        public void GetTopMoviesByReviewer()
        {

            List<int> result = new List<int>();
            result.Add(218497);
            result.Add(1114519);
            result.Add(267841);
            result.Add(387418);
            result.Add(964306);

            Assert.Equal(result, _service.GetTopMoviesByReviewer(148));
        }
    }
}
