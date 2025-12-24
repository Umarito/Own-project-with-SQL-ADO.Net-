namespace Domain;
public interface IOutfitDetailsService
{
     public void AddDetail(OutfitDetails outfitDetails);
    public void GetOutfitDetails();
    public string? UpdateOutfitDetail(int detailId,int newItemId);
    public string? DeleteDetail(int detailId);
}