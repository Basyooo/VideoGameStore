using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace VideoGameStore.Pages
{
    public class cartModel : PageModel
    {
        public IActionResult OnPost()
        {
            string gameName = "All";
            string email = Request.Form["email"];
            string user = Request.Form["user"];

            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database=VideoGame; Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use parameterized query for security
                    string query = "UPDATE Users SET games_bought = @gameName WHERE Email = @Email OR User_name = @UserName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@gameName", gameName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@UserName", user);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error: {ex.Message}");
                return RedirectToPage("/error");
            }

            return RedirectToPage("/successful");
        }
    }
}
