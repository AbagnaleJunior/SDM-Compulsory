using SDM_Compulsory.Domain.IServices;
using System;
using System.Collections.Generic;

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
            ShowIntroMessage();
            StartLoopMenu();
        }
        private void ShowIntroMessage()
        {
            Console.WriteLine(StringConstants.IntroMessageText);
        }
        
        private void StartLoopMenu()
        {
            Print(StringConstants.MenuMainMenuText);
            ShowMainMenu();
            int choice;
            while ((choice = GetSelection()) != 0)
            {
                if (choice == 1)
                {
                    MoviesMenu();
                }

                if (choice == 2)
                {
                    ReviewersMenu();
                }

                if (choice == 0)
                {
                    ExitProgram();
                }
            }

        }

        private int GetSelection()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        private void MoviesMenu()
        {
            Clear();
            MoviesMenuText();

            int choice;
            while ((choice = GetSelection()) != 0)
            {

                if (choice == 1)
                {
                    Print("");
                    Print("Type movieID:");
                    var movieId = int.Parse(Console.ReadLine()!);
                    Clear();
                    Console.WriteLine($"Movie got reviewed \n= " + _reviewService.GetNumberOfReviews(movieId) + " time(s)");
                    PrintNewLine();
                    MoviesMenuText();
                }

                if (choice == 2)
                {
                    Print("Type movieID:");
                    var movieId = int.Parse(Console.ReadLine()!);
                    Print("Type rate");
                    var movieRate = int.Parse(Console.ReadLine()!);
                    Clear();
                    Console.WriteLine($"Movie got rated with {movieRate} \n= " + _reviewService.GetNumberOfRates(movieId, movieRate) + " time(s)");
                    PrintNewLine();
                    MoviesMenuText();
                }

                if (choice == 3)
                {
                    Print("Type movieID:");
                    var movieId = int.Parse(Console.ReadLine()!);
                    Clear();
                    Console.WriteLine($"Movie: {movieId}\n" + "Average = "+ _reviewService.GetAverageRateOfMovie(movieId));
                    PrintNewLine();
                    MoviesMenuText();
                }

                if (choice == 4)
                {
                    Print("Type amount (TOP X)");
                    var amount = int.Parse(Console.ReadLine()!);
                    Clear();
                    Print("Loading...");
                    PrintList(_reviewService.GetTopRatedMovies(amount));
                    PrintNewLine();
                    MoviesMenuText();
                }

                if (choice == 5)
                {
                    Print("Type movidID to see who made a review on this movie");
                    var movie = int.Parse(Console.ReadLine()!);
                    Clear();
                    Print($"Reviewers who made a review on movie: {movie}");
                    PrintList(_reviewService.GetReviewersByMovie(movie));
                    PrintNewLine();
                    MoviesMenuText();
                }

                if (choice == 6)
                {
                    Clear();
                    PrintList(_reviewService.GetMoviesWithHighestNumberOfTopRates());
                    PrintNewLine();
                    MoviesMenuText();
                }

                if (choice == 9)
                {
                    Clear();
                    StartLoopMenu();
                }
            }
        }

        private void MoviesMenuText()
        {
            
            Print("MOVIES");
            PrintNewLine();
            Print(StringConstants.PrintNumberOfReviewsText);
            Print(StringConstants.PrintNumberOfRatesText);
            Print(StringConstants.PrintGetAverageRateOfMovieText);
            Print(StringConstants.PrintTopRatedMoviesText);
            Print(StringConstants.PrintReviewersByMovieText);
            Print(StringConstants.PrintMoviesWithHighestNumberOfTopRatesText);
            PrintNewLine();
            Print(StringConstants.MainMenu);
        }

        private void ReviewersMenu()
        {
            Clear();
            ReviewersMenuText();

            int choice;
            while ((choice = GetSelection()) != 0)
            {

                if (choice == 1)
                {
                    Print("");
                    Print("Type reviewerID:");
                    var reviewerId = int.Parse(Console.ReadLine()!);
                    Clear();
                    Console.WriteLine($"Reviewer made a review \n= " + _reviewService.GetNumberOfReviewsFromReviewer(reviewerId) + " time(s)");
                    PrintNewLine();
                    ReviewersMenuText();
                }

                if (choice == 2)
                {
                    Print("Type reviewerID:");
                    var reviewerId = int.Parse(Console.ReadLine()!);

                    Clear();
                    Console.WriteLine($"Reviewer: {reviewerId} \nRated " + _reviewService.GetAverageRateFromReviewer(reviewerId) + " in average");
                    PrintNewLine();
                    ReviewersMenuText();
                }

                if (choice == 3)
                {
                    Print("Type reviewerID:");
                    var reviewerId = int.Parse(Console.ReadLine()!);
                    Print("Type rate");
                    var movieRate = int.Parse(Console.ReadLine()!);
                    Clear();

                    Console.WriteLine($"Reviewer: {reviewerId}\nRated {movieRate} = " + _reviewService.GetNumberOfRatesByReviewer(reviewerId, movieRate) + " times");
                    PrintNewLine();
                    ReviewersMenuText();
                }

                if (choice == 4)
                {
                    Print("Loading...");
                    PrintList(_reviewService.GetMostProductiveReviewer());
                    PrintNewLine();
                    ReviewersMenuText();
                }

                if (choice == 5)
                {
                    Print("Type reviewerID to see the top movies for this reviewer");
                    var reviewerId = int.Parse(Console.ReadLine()!);

                    PrintList(_reviewService.GetTopMoviesByReviewer(reviewerId));
                    PrintNewLine();
                    ReviewersMenuText();
                }

                if (choice == 6)
                {
                    Clear();
                    PrintList(_reviewService.GetMoviesWithHighestNumberOfTopRates());
                    PrintNewLine();
                    ReviewersMenuText();
                }

                if (choice == 9)
                {
                    Clear();
                    StartLoopMenu();
                }
            }
        }

        private void ReviewersMenuText()
        {

            Print("Reviewers");
            PrintNewLine();
            Print(StringConstants.PrintNumberOfReviewsFromReviewerText);
            Print(StringConstants.PrintAverageRateFromReviewerText);
            Print(StringConstants.PrintNumberOfRatesByReviewerText);
            Print(StringConstants.PrintMostProductiveReviewerText);
            Print(StringConstants.PrintTopMoviesByReviewerText);
            Print(StringConstants.PrintMoviesWithHighestNumberOfTopRatesText);
            PrintNewLine();
            Print(StringConstants.MainMenu);
        }

        static void PrintList<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void PrintNewLine()
        {
            Console.WriteLine("");
        }
        private void Clear()
        {
            Console.Clear();
        }
        private void ExitProgram()
        {
            Environment.Exit(0);
        }
        private void ShowMainMenu()
        {
            PrintNewLine();
            Print(StringConstants.MenuGuideText);
            PrintNewLine();
            Print(StringConstants.MenuMovies);
            Print(StringConstants.MenuReviewers);
            PrintNewLine();
            Print(StringConstants.ExitProgramText);
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }

    }
}
   