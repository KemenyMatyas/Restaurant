namespace Restaurant.Data.Models;

using Base;
using ManyToMany;

public class Order : EntityBase
{
    public DateTime OrderTime { get; set; }
    
    public string Comment { get; set; }
    public User Costumer { get; set; }
    public Address DeliveryAddress { get; set; }
    public int DeliveryTime { get; set; }
    public int FinalPrice { get; set; }
    
    public IList<OrderMenuItem> OrderMenuItems { get; set; }
    
}