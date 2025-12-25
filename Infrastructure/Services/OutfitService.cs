using Domain;
using Npgsql;
namespace Infrastructure;

public class OutfitService : ApplicationDB_, IOutfitService
{
    public void AddOutfit(Outfit outfit)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var insertQuery = $"insert into outfits(name,rating,total_cost) values(@name,@rating,@cost)";
        using var cmd = new NpgsqlCommand(insertQuery,conn);
        cmd.Parameters.AddWithValue("@name",outfit.Outfit_name);
        cmd.Parameters.AddWithValue("@rating",outfit.Rating);
        cmd.Parameters.AddWithValue("@cost",outfit.TotalPrice);
        cmd.ExecuteNonQuery();
    }

    public string? DeleteOutfit(int outfitId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var deleteQuery = $"delete from outfits where id = @outfitId";
        using var cmd = new NpgsqlCommand(deleteQuery,conn);
        cmd.Parameters.AddWithValue("@outfitId",outfitId);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't delete outfit" : "Outfit was deleted successfully";
    }

    public void GetOutfits()
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var selectQuery = "select * from outfits";
        using var cmd = new NpgsqlCommand(selectQuery,conn);
        var res = cmd.ExecuteReader();
        while (res.Read())
        {
            System.Console.WriteLine($"{res["id"]}---{res["name"]}---{res["rating"]}---{res["total_cost"]}");
        }
    }

    public void GetOutfitById()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        System.Console.WriteLine("Type id of outfit that you are searching: ");
        int a = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("Outfit that you were searching for: ");
        var selectQuery = $"select * from outfits where id = @A";
        using var cmd = new NpgsqlCommand(selectQuery,conn);
        cmd.Parameters.AddWithValue("@A",a);
        var res = cmd.ExecuteReader();
        while (res.Read())
        {
            System.Console.WriteLine($"{res["id"]}---{res["name"]}---{res["rating"]}---{res["total_cost"]}");
        }
    }
    
    public void GetMaxPriceOfOutfit()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var maxQuery = $"select max(total_cost) from outfits";
        using var cmd = new NpgsqlCommand(maxQuery,conn);
        var res = cmd.ExecuteScalar();
        System.Console.WriteLine(res);
    }
    public void GetMinPriceOfOutfit()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var minQuery = $"select min(total_cost) from outfits";
        using var cmd = new NpgsqlCommand(minQuery,conn);
        var res = cmd.ExecuteScalar();
        System.Console.WriteLine(res);
    }

    public void GetNumberOfOutfits()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var countQuery = $"select count(*) from outfits";
        using var cmd = new NpgsqlCommand(countQuery,conn);
        int res = Convert.ToInt32(cmd.ExecuteScalar());
        System.Console.WriteLine(res);
    }
    public void GetAvgPriceOfOutfits()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var countQuery = $"select round(avg(total_cost),2) from outfits";
        using var cmd = new NpgsqlCommand(countQuery,conn);
        decimal res = Convert.ToDecimal(cmd.ExecuteScalar());
        System.Console.WriteLine(res);
    }

    public string? UpdateOutfit(int outfitId, string? newName)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var updateQuery = $"update outfits set name = @newName where id = @outfitId";
        using var cmd = new NpgsqlCommand(updateQuery,conn);
        cmd.Parameters.AddWithValue("@newName",newName);
        cmd.Parameters.AddWithValue("@outfitId",outfitId);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't update outfit" : "Outfit was updated successfully";
    }

}