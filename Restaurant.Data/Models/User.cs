namespace Restaurant.Data.Models;

using Base;
using Enums;

public class User : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Role UserRole { get; set; }
    public string PhoneNumber { get; set; }
    public Address Address { get; set; }
}