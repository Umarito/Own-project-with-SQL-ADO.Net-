using Domain;
using Npgsql;
namespace Infrastructure;

public class ItemService : ApplicationDB_, IItemService
{
    public void AddItem(Item item)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var insertQuery = $"insert into items(name,category_id,price,Status) values('{item.Item_name}',{item.Category_id},{item.Price},'{item.Status}')";
        using var cmd = new NpgsqlCommand(insertQuery,conn);
        cmd.ExecuteNonQuery();
    }

    public string? DeleteItem(int ItemId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var deleteQuery = $"delete from items where id = {ItemId}";
        using var cmd = new NpgsqlCommand(deleteQuery,conn);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't delete item" : "Item was deleted successfully";
    }

    public void GetItems()
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var selectQuery = "select * from items";
        using var cmd = new NpgsqlCommand(selectQuery,conn);
        var res = cmd.ExecuteReader();
        while (res.Read())
        {
            System.Console.WriteLine($"{res["id"]}---{res["name"]}---{res["category_id"]}---{res["price"]}---{res["status"]}");
        }
    }

    public List<ItemDto> GetAllItemsWithJoin()
    {
        var result = new List<ItemDto>();
        string sql = "Select i.id,i.name,c.name from items i join categories c on i.category_id = c.id";
        using var conn = new NpgsqlConnection(connString);
        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
        conn.Open();

        using (NpgsqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                result.Add(new ItemDto
                {
                    ItemId = reader.GetInt32(0),
                    ItemName = reader.GetString(1),
                    CategoryName = reader.GetString(2)
                });
            }
        }    
        return result;
    }

    public string? UpdateItem(int itemId, decimal newPrice)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var updateQuery = $"update items set price = {newPrice} where id = {itemId}";
        using var cmd = new NpgsqlCommand(updateQuery,conn);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't update item" : "Item was updated successfully";
    }

}