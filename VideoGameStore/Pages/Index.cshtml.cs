using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;

    public IndexModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }



    public IActionResult OnPost()
    {
        string Username = Request.Form["username"];
        string Password = Request.Form["password"];
        string ErrorMessage;
        bool ShowLoginError;

       string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database = VideoGame ; Integrated Security=True";

        SqlConnection connection = new SqlConnection(connectionString);
        
            connection.Open();
            string query = "SELECT COUNT(1) FROM Users WHERE User_name =" + "'" +Username + "'" +  "AND password =" + "'" + Password + "'";
            SqlCommand command = new SqlCommand(query, connection);


            int count = (int)command.ExecuteScalar();
            if (count == 1)
            {
               
                return RedirectToPage("/main");
            }
            else
            {
                ErrorMessage = "Invalid username or password";
                ShowLoginError = true; // Set flag to true to show error message
                return Page();
            }
     
    }
}
