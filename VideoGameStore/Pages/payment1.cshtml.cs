using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace VideoGameStore.Pages
{
    public class payment1Model : PageModel
    {
        public IActionResult OnPost()
        {
            string email = Request.Form["email"];
            string user = Request.Form["user"];

            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database = VideoGame ; Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "UPDATE Users SET bought_rainbow =" + "'Yes'" + "WHERE Email =" + "'" + email + "'" + " OR User_name =" + "'" + user + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            return RedirectToPage("/succesful");
        }
    }
}
