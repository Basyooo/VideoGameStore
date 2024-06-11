using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace VideoGameStore.Pages
{
    public class UserModel : PageModel
    {
        public IActionResult OnPost()
        {
            String Email = Request.Form["email"];
            String User = Request.Form["username"];
            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database = VideoGame ; Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "UPDATE Users SET User_name =" + "'" + User + "'" + "WHERE Email =" + "'" + Email + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            return RedirectToPage("/Index");
        }
    }
}
