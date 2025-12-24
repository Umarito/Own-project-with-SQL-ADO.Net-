using Domain;
using Npgsql;
namespace Infrastructure;

public class CategoryService : ApplicationDB_, ICategoryService
{
    public void AddCategory(Category category)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var insertQuery = $"insert into categories(name,Season) values('{category.Category_name}','{category.Season}')";
        using var cmd = new NpgsqlCommand(insertQuery,conn);
        cmd.ExecuteNonQuery();
    }

    public string? DeleteCategory(int categoryId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var deleteQuery = $"delete from categories where id = {categoryId}";
        using var cmd = new NpgsqlCommand(deleteQuery,conn);
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
            System.Console.WriteLine($"{res["id"]}---{res["name"]}---{res["season"]}");
        }
    }

    public string? UpdateCategory(int categoryId, string categoryName)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var updateQuery = $"update categories set name = '{categoryName}' where id = {categoryId}";
        using var cmd = new NpgsqlCommand(updateQuery,conn);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't update category" : "Category was updated successfully";
    }
}