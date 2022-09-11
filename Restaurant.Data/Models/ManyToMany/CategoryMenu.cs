namespace Restaurant.Data.Models.ManyToMany;

using Base;

public class CategoryMenu : EntityBase
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}