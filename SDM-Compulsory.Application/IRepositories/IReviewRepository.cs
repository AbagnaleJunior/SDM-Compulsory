﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM_Compulsory.Application.IRepositories
{
    public interface IReviewRepository
    {

        int GetNumberOfReviewsFromReviewer(int reviewer);
        double GetAverageRateFromReviewer(int reviewer);
        int GetNumberOfRatesByReviewer(int reviewer, int rate);
        int GetNumberOfReviews(int movie);
        double GetAverageRateOfMovie(int movie);
        int GetNumberOfRates(int movie, int rate);
        List<int> GetMoviesWithHighestNumberOfTopRates();
        List<int> GetMostProductiveReviewers();
        List<int> GetTopRatedMovies(int amount);
        List<int> GetTopMoviesByReviewer(int reviewer);

    }
}