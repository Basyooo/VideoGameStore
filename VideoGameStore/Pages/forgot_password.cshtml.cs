using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace VideoGameStore.Pages
{
    public class forgot_passwordModel : PageModel
    {
        public IActionResult OnPost()
        {
            string UserOREmail = Request.Form["username"];
            string Phone = Request.Form["phone"];

            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database = VideoGame ; Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "SELECT COUNT(1) FROM Users WHERE (User_name =" + "'" + UserOREmail + "'" + " OR Email ="+ "'" +UserOREmail + "')" + " AND phone =" + "'" + Phone + "'";
            SqlCommand command = new SqlCommand(query, connection);


            int count = (int)command.ExecuteScalar();
            if (count == 1)
            {

                return RedirectToPage("/retreive_password");
            }
            else
            {
                return Page();
            }

        }
    }
}

