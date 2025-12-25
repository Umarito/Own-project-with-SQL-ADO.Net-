using Domain;
using Npgsql;
namespace Infrastructure;

public class ItemService : ApplicationDB_, IItemService
{
    public void AddItem(Item item)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var insertQuery = $"insert into items(name,category_id,price,Status) values(@name,@categoryId,@price,@status)";
        using var cmd = new NpgsqlCommand(insertQuery,conn);
        cmd.Parameters.AddWithValue("@name",item.Item_name);
        cmd.Parameters.AddWithValue("@categoryId",item.Category_id);
        cmd.Parameters.AddWithValue("@price",item.Price);
        cmd.Parameters.AddWithValue("@status",item.Status);
        cmd.ExecuteNonQuery();
    }

    public string? DeleteItem(int ItemId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var deleteQuery = $"delete from items where id = @itemId";
        using var cmd = new NpgsqlCommand(deleteQuery,conn);
        cmd.Parameters.AddWithValue("itemId",ItemId);
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

    public List<ItemDto> GetAllItemsBySeason()
    {
        var result = new List<ItemDto>();
        System.Console.WriteLine("Enter which season's items you want to get: ");
        string? a = Console.ReadLine();
        string sql = $"Select i.id,i.name,c.Season from items i join categories c on i.category_id = c.id where c.Season = '{a}'";
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
                    SeasonName = reader.GetString(2)
                });
            }
        }    
        return result;
    }
    
    public List<ItemDto> GetAllItemsByCategory()
    {
        var result = new List<ItemDto>();
        System.Console.WriteLine("Enter which category's items you want to get: ");
        string? a = Console.ReadLine();
        string sql = $"Select i.id,i.name,c.name from items i join categories c on i.category_id = c.id where c.name = '{a}'";
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
    public void GetMaxPriceOfItem()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var maxQuery = $"select max(price) from items";
        using var cmd = new NpgsqlCommand(maxQuery,conn);
        var res = cmd.ExecuteScalar();
        System.Console.WriteLine(res);
    }
    public void GetMinPriceOfItem()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var minQuery = $"select min(price) from items";
        using var cmd = new NpgsqlCommand(minQuery,conn);
        var res = cmd.ExecuteScalar();
        System.Console.WriteLine(res);
    }

    public void GetNumberOfItems()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var countQuery = $"select count(*) from items";
        using var cmd = new NpgsqlCommand(countQuery,conn);
        int res = Convert.ToInt32(cmd.ExecuteScalar());
        System.Console.WriteLine(res);
    }
    public void GetAvgPriceOfItems()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var countQuery = $"select round(avg(price),2) from items";
        using var cmd = new NpgsqlCommand(countQuery,conn);
        decimal res = Convert.ToDecimal(cmd.ExecuteScalar());
        System.Console.WriteLine(res);
    }
    
    public void GetItemById()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        System.Console.WriteLine("Type id of item that you are searching: ");
        int a = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Item that you were searching for: ");
        var selectQuery = $"select * from items where id = @a";
        using var cmd = new NpgsqlCommand(selectQuery,conn);
        cmd.Parameters.AddWithValue("@a",a);
        var res = cmd.ExecuteReader();
        while (res.Read())
        {
            System.Console.WriteLine($"{res["id"]}---{res["name"]}---{res["category_id"]}---{res["price"]}---{res["status"]}");
        }
    }

    public string? UpdateItem(int itemId, decimal newPrice)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var updateQuery = $"update items set price = @newPrice where id = @itemId";
        using var cmd = new NpgsqlCommand(updateQuery,conn);
        cmd.Parameters.AddWithValue("newPrice",newPrice);
        cmd.Parameters.AddWithValue("@itemId",itemId);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't update item" : "Item was updated successfully";
    }

}