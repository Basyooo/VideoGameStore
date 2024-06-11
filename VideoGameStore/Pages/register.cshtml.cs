using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace VideoGameStore.Pages
{
    public class registerModel : PageModel
    {
        public IActionResult OnPost()
        {
            String fname = Request.Form["fname"];
            String lname = Request.Form["lname"];
            String Email = Request.Form["email"];
            String Phone = Request.Form["phone"];
            String password = Request.Form["password"];
            String ConfirmPassword = Request.Form["confirm_password"];
            bool PasswordMismatch = false;


            if (password != ConfirmPassword)
            {
                PasswordMismatch = true;
                return Page();
            }
            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database = VideoGame ; Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            string query =  "INSERT INTO Users (User_ID ,User_name, Fname, Lname, Email, password, phone) VALUES (" + "NEXT VALUE FOR UserIDSequence" + " , " + "'" + null + "'" + " , " + "'" + fname +"'" + " , " + "'" + lname +"'" + " , " + "'" + Email +"'" + " , " + "'" + password +"'" + " , " + "'" + Phone +"'" + ")";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

         

                return RedirectToPage("/User");



        }
    }
}
