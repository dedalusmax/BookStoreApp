using BookStoreApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace BookStoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            //var connection = new SqlConnection(connectionString);
            //connection.Open();
            ////TODO...
            //connection.Close();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //using var command = new SqlCommand("INSERT INTO Author (Name, Bio) VALUES ('Pero', '');", connection);
                //command.ExecuteNonQuery();

                //using var command = new SqlCommand("SELECT 1", connection);
                //using var command = new SqlCommand("SELECT [Name] FROM Author;", connection);

                //using var command = new SqlCommand("SELECT * FROM Author WHERE AuthorId = @author_id;", connection);

                //command.Parameters.Clear();
                //command.Parameters.AddWithValue("@author_id", 1);

                //var result = command.ExecuteScalar();

                //using var command = new SqlCommand("SELECT * FROM Author ORDER BY AuthorId DESC;", connection);
                //var result = command.ExecuteScalar();

                using var command = new SqlCommand("SELECT * FROM Author;", connection);

                //var reader = command.ExecuteReader();
                ////TODO...
                //while (reader.Read())
                //{
                //    var id = reader[0];
                //    var authorId = reader["AuthorId"];
                //    var name = reader["name"];
                //    var bio = reader["bio"];
                //}

                //reader.Close();
                //reader.Dispose();

                using var reader = command.ExecuteReader();
                //TODO...
                while (reader.Read())
                {
                    int id2 = reader.GetInt32("AuthorId");
                    var id = reader[0];
                    int authorId = (int)reader["AuthorId"];
                    string name = (string)reader["name"];
                    string? bio = reader.GetString("bio");
                }
            }

            //using var conn2 = new SqlConnection(connectionString);
            //conn2.Open();

            _logger.LogWarning("Index akcija se izvodi i jako je važno!");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
