using System.Runtime.InteropServices;
using Domain;
using Npgsql;
namespace Infrastructure;

public class OutfitDetailsService : ApplicationDB_, IOutfitDetailsService
{
    public void AddDetail(OutfitDetails outfitDetails)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var insertQuery = $"insert into outfit_details(outfit_id,item_id) values({outfitDetails.Outfit_id},{outfitDetails.Item_id})";
        using var cmd = new NpgsqlCommand(insertQuery,conn);
        cmd.ExecuteNonQuery();
    }

    public string? DeleteDetail(int detailId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var deleteQuery = $"delete from outfit_details where id = {detailId}";
        using var cmd = new NpgsqlCommand(deleteQuery,conn);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't delete outfit detail" : "Outfit's details were deleted successfully";
    }

    public void GetOutfitDetails()
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var selectQuery = "select * from outfit_details";
        using var cmd = new NpgsqlCommand(selectQuery,conn);
        var res = cmd.ExecuteReader();
        while (res.Read())
        {
            System.Console.WriteLine($"{res["outfit_id"]}---{res["item_id"]}");
        }
    }
    public List<OutfitDetailsDto> GetOutfitDetailsWithJoin()
    {
        var result = new List<OutfitDetailsDto>();
        string sql = "SELECT  od.id, o.name, i.name FROM outfit_details od JOIN outfits o ON od.outfit_id = o.id JOIN items i ON od.item_id = i.id;";
        using var conn = new NpgsqlConnection(connString);
        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            conn.Open();

            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new OutfitDetailsDto
                    {
                        OutfitDetailsId = reader.GetInt32(0),
                        OutfitName = reader.GetString(1),
                        ItemName = reader.GetString(2)
                    });
                }
            }
        return result;
        }


    public string? UpdateOutfitDetail(int detailId, int newItemId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var updateQuery = $"update items set item_id = {newItemId} where id = {detailId}";
        using var cmd = new NpgsqlCommand(updateQuery,conn);
        var res = cmd.ExecuteNonQuery();
        return res == 0 ? "Can't update detail" : "Outfit's detail was updated successfully";
    }

}