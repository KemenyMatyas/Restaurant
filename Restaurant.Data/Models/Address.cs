namespace Restaurant.Data.Models;

using Base;

public class Address : EntityBase
{
    public string City { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
}