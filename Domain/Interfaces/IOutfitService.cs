namespace Domain;
public interface IOutfitService
{
     public void AddOutfit(Outfit outfit);
    public void GetOutfits();
    public string? UpdateOutfit(int outfitId,string newName);
    public string? DeleteOutfit(int outfitId);
}