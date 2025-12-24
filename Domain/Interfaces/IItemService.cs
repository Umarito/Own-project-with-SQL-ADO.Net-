namespace Domain;
public interface IItemService
{
     public void AddItem(Item item);
    public void GetItems();
    public string? UpdateItem(int itemId,decimal newPrice);
    public string? DeleteItem(int itemId);
}