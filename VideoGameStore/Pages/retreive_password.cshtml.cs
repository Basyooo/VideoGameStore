using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Numerics;

namespace VideoGameStore.Pages
{
    public class retreive_passwordModel : PageModel
    {
        public IActionResult OnPost()
        {
            string EmailORUser = Request.Form["EmailORUser"]; 
           string NewPassword = Request.Form["newPassword"];
           string ConfirmPassword = Request.Form["confirmPassword"];
            bool PasswordMismatch= false;
            if (NewPassword != ConfirmPassword)
            {
                PasswordMismatch = true;
                return Page();
            }

            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database = VideoGame ; Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query = "UPDATE Users SET Password =" + "'" + NewPassword +"'" +"WHERE Email =" + "'" + EmailORUser + "'" +" OR User_name =" + "'" + EmailORUser + "'";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

           return RedirectToPage("/Index");

            

        }
}
}
