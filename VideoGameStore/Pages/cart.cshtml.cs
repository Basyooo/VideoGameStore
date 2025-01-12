using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace VideoGameStore.Pages
{
    /**
     * Represents the backend logic for the Shopping Cart page in the VideoGameStore application.
     * Handles operations such as updating the database with the user's purchased games.
     * 
     * This class interacts with the database to record the games purchased by a user
     * based on their email or username, and redirects the user to a success page upon completion.
     */
    public class cartModel : PageModel
    {
        /**
         * Handles POST requests for the Shopping Cart page.
         * 
         * This method retrieves user input from the form (email and username), establishes a connection
         * to the SQL Server database, and updates the "Users" table to record the games purchased.
         * Upon successful execution, the user is redirected to the "successful" page.
         * 
         * @return IActionResult A redirection to the "successful" page upon successful completion of the operation.
         */
        public IActionResult OnPost()
        {
            // Retrieve form data
            string gameName = "All"; // Placeholder for games purchased
            string email = Request.Form["email"];
            string user = Request.Form["user"];

            // Database connection string
            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database=VideoGame; Integrated Security=True";

            try
            {
                // Establish a connection to the SQL Server database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Construct and execute the SQL query to update the user's purchased games
                    string query = "UPDATE Users SET games_bought = @GameName WHERE Email = @Email OR User_name = @UserName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use parameterized queries to prevent SQL injection
                        command.Parameters.AddWithValue("@GameName", gameName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@UserName", user);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }

                // Redirect to the "successful" page upon successful database update
                return RedirectToPage("/successful");
            }
            catch (SqlException ex)
            {
                // Log the exception (logging implementation can be added here)
                Console.WriteLine($"Database error: {ex.Message}");
                // Return an error page or handle the error appropriately
                return RedirectToPage("/error");
            }
        }
    }
}
