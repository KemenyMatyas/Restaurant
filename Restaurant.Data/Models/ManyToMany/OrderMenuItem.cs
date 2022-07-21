namespace Restaurant.Data.Models.ManyToMany;

using Base;

public class OrderMenuItem : EntityBase
{
    public Guid OderId { get; set; }
    public Order Oder { get; set; }
    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}