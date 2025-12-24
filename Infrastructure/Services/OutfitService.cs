using Domain;
using Npgsql;
namespace Infrastructure;

public class OutfitService : ApplicationDB_, IOutfitService
{
    public void AddOutfit(Outfit outfit)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var insertQuery = $"insert into outfits(name,rating,total_cost) values('{outfit.Outfit_name}',{outfit.Rating},{outfit.TotalPrice})";
        using var cmd = new NpgsqlCommand(insertQuery,conn);
        cmd.ExecuteNonQuery();
    }

    public string? DeleteOutfit(int outfitId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var deleteQuery = $"delete from outfits where id = {outfitId}";
        using var cmd = new NpgsqlCommand(deleteQuery,conn);
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

    public string? UpdateOutfit(int outfitId, string? newName)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var updateQuery = $"update outfits set name = '{newName}' where id = {outfitId}";
        using var cmd = new NpgsqlCommand(updateQuery,conn);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't update outfit" : "Outfit was updated successfully";
    }

}