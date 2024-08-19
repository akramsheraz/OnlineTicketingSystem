namespace UserService.Domain;

public class User
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserType  { get; set; } // To identify user is admin user or customer          
   
}
