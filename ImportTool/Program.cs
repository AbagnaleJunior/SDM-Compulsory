using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;


namespace ImportTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read from JSON");

            List<Model> rows = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model>>(
                System.IO.File.ReadAllText("D:\\School\\ratings.json")
            );

            Console.WriteLine("Import to database");
            SqliteConnection sqliteConnection = new SqliteConnection("Data Source=D:\\School\\Review.db;");
            sqliteConnection.Open();
            SqliteCommand sqliteCommand = new SqliteCommand("INSERT INTO Ratings (Reviewer, Movie, Grade, Date) VALUES (@Reviewer, @Movie, @Grade, @Date)", sqliteConnection);

            for (int i = 0; i < rows.Count; i++)
            {
                sqliteCommand.Parameters.Clear();
                sqliteCommand.Parameters.AddWithValue("Reviewer", rows[i].Reviewer);
                sqliteCommand.Parameters.AddWithValue("Movie", rows[i].Movie);
                sqliteCommand.Parameters.AddWithValue("Grade", rows[i].Grade);
                sqliteCommand.Parameters.AddWithValue("Date", rows[i].Date);
                sqliteCommand.ExecuteNonQuery();
                
               if(i% 10000 == 0)
                {
                    Console.Write("Rows : ");
                    Console.WriteLine(i);
                }
            }

            if (sqliteConnection.State != ConnectionState.Closed)
            {
                sqliteConnection.Close();
            }

            Console.WriteLine("Finished!");
            Console.Read();
        }
    }
}
