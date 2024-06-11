using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace VideoGameStore.Pages
{
    public class Del_AccModel : PageModel
    {
        public IActionResult OnPost()
        {
            String Password = Request.Form["password"];
            String User = Request.Form["username"];
            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database = VideoGame ; Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "DELETE FROM Users WHERE User_name = " + "'" + User + "'" + " AND password = " + "'" + Password + "'" ;
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            return RedirectToPage("/Index");
        }
    }
}
