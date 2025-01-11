using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VideoGameStore.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal TotalPrice { get; set; }

        public void OnGet()
        {
            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database=VideoGame; Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Name, Price, ImageUrl FROM Cart";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CartItems.Add(new CartItem
                    {
                        Name = reader.GetString(0),
                        Price = reader.GetDecimal(1),
                        ImageUrl = reader.GetString(2)
                    });
                    TotalPrice += reader.GetDecimal(1);
                }
            }
        }

        public IActionResult OnPostCheckout(string email, string user)
        {
            string connectionString = "Data Source=DESKTOP-0MC143Q\\BASYO; database=VideoGame; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Users SET games_bought = 'All' WHERE Email = @Email OR User_name = @User";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@User", user);
                command.ExecuteNonQuery();
            }

            return RedirectToPage("/successful");
        }
    }

    public class CartItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
