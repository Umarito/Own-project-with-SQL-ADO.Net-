using Domain;
using Npgsql;
namespace Infrastructure;

public class CategoryService : ApplicationDB_, ICategoryService
{
    public void AddCategory(Category category)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var insertQuery = $"insert into categories(name,Season) values(@name,@Season)";
        using var cmd = new NpgsqlCommand(insertQuery,conn);
        cmd.Parameters.AddWithValue("@name",category.Category_name);
        cmd.Parameters.AddWithValue("@Season",category.Season);
        cmd.ExecuteNonQuery();
    }

    public string? DeleteCategory(int categoryId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var deleteQuery = $"delete from categories where id = @categoryId";
        using var cmd = new NpgsqlCommand(deleteQuery,conn);
        cmd.Parameters.AddWithValue("@categoryId",categoryId);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't delete category" : "Category was deleted successfully";
    }

    public void GetCategories()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var selectQuery = "select * from categories";
        using var cmd = new NpgsqlCommand(selectQuery,conn);
        var res = cmd.ExecuteReader();
        while (res.Read())
        {
            System.Console.WriteLine($"{res["id"]}---{res["name"]}---{res["Season"]}");
        }
    }

    public void GetCategoryById()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        System.Console.WriteLine("Type id of category that you are searching: ");
        int a = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Category that you were searching for: ");
        var selectQuery = $"select * from categories where id = @a";
        using var cmd = new NpgsqlCommand(selectQuery,conn);
        cmd.Parameters.AddWithValue("@a",a);
        var res = cmd.ExecuteReader();
        while (res.Read())
        {
            System.Console.WriteLine($"{res["id"]}---{res["name"]}---{res["Season"]}");
        }
    }

    public string? UpdateCategory(int categoryId, string categoryName)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var updateQuery = $"update categories set name = @name where id = @categoryId";
        using var cmd = new NpgsqlCommand(updateQuery,conn);
        cmd.Parameters.AddWithValue("@name",categoryName);
        cmd.Parameters.AddWithValue("@categoryId",categoryId);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't update category" : "Category was updated successfully";
    }
}