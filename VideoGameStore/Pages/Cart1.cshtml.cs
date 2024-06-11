using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace VideoGameStore.Pages
{
    public class Cart1Model : PageModel
    {
        public IActionResult OnPost()
        {
            string gameName = "Rainbow Six Siege"; 

            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database = VideoGame ; Integrated Security=True";
            string sql = "INSERT INTO Users (games_bought) VALUES(" + "'" + gameName + "')";

            SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            

            return RedirectToPage("/main");
        }
    }
}

