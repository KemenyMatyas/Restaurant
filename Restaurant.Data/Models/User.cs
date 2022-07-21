namespace Restaurant.Data.Models;

using Base;
using Enums;

public class User : EntityBase
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Role UserRole { get; set; }
}