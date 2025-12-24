using System.Runtime.InteropServices;
using Domain;
using Infrastructure;
namespace lesson3;
class Program
{
    static void Main(string[] args)
    {
    CategoryService categoryService = new CategoryService();
    ItemService itemService = new ItemService();
    OutfitService outfitService = new OutfitService();
    OutfitDetailsService detailsService = new OutfitDetailsService();

        while (true)
        {
            System.Console.WriteLine("Enter an operation: ");
            System.Console.WriteLine("1 - Add a category\n2 - Get all categories\n3 - Update category\n4 - Delete a category\n5 - Add an item\n6 - Get all items\n7 - Update item\n8 - Delete an item\n9 - Add an outfit\n10 - Get all outfits\n11 - Update outfit\n12 - Delete an outfit\n13 - Add an outfit detail\n14 - Get all outfit's details\n15 - Update outfit's detail\n16 - Delete a detail of an outfit\n17 - Get all outfit's details with join\n18 - Get all item and categories with join");
            var a = Console.ReadLine();
            switch (a)
            {

                case "1":
                System.Console.WriteLine("Enter category's name: ");
                string? name = Console.ReadLine();
                System.Console.WriteLine("Enter category's season: ");
                string? season = Console.ReadLine();
                var category = new Category(){Category_name = name,Season = season};
                categoryService.AddCategory(category);
                break;

                case "2":
                System.Console.WriteLine("All categories: ");
                categoryService.GetCategories();
                break;

                case "3":
                System.Console.WriteLine("Enter id of category that you want to change: ");
                int id = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter new name of the category: ");
                string? name2 = Console.ReadLine();
                categoryService.UpdateCategory(id,name2);
                break;

                case "4":
                System.Console.WriteLine("Enter id of category that you want to delete: ");
                int id2 = Convert.ToInt32(Console.ReadLine());
                categoryService.DeleteCategory(id2);
                break;

                case "5":
                System.Console.WriteLine("Enter item's name: ");
                string? name3 = Console.ReadLine();
                System.Console.WriteLine("Enter item's category id: ");
                int category_id = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter item's price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());
                System.Console.WriteLine("Enter item's status: ");
                string? status = Console.ReadLine();
                var item = new Item(){Item_name = name3,Category_id = category_id,Price = price,Status=status};
                itemService.AddItem(item);
                break;

                case "6":
                System.Console.WriteLine("All items: ");
                itemService.GetItems();
                break;

                case "7":
                System.Console.WriteLine("Enter id of item that you want to change: ");
                int id3 = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter new price of the item: ");
                decimal price2 = Convert.ToDecimal(Console.ReadLine());
                itemService.UpdateItem(id3,price2);
                break;

                case "8":
                System.Console.WriteLine("Enter id of item that you want to delete: ");
                int id4 = Convert.ToInt32(Console.ReadLine());
                itemService.DeleteItem(id4);
                break;

                case "9":
                System.Console.WriteLine("Enter outfit's name: ");
                string? name4 = Console.ReadLine();
                System.Console.WriteLine("Enter outfit's rating: ");
                int rating = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter outfit's total price: ");
                decimal total_price = Convert.ToDecimal(Console.ReadLine());
                var outfit = new Outfit(){Outfit_name = name4,Rating = rating,TotalPrice = total_price};
                outfitService.AddOutfit(outfit);
                break;

                case "10":
                System.Console.WriteLine("All outfits: ");
                outfitService.GetOutfits();
                break;

                case "11":
                System.Console.WriteLine("Enter id of outfit that you want to change: ");
                int id5 = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter new name of the outfit: ");
                string? name5 = Console.ReadLine();
                outfitService.UpdateOutfit(id5,name5);
                break;

                case "12":
                System.Console.WriteLine("Enter id of outfit that you want to delete: ");
                int id6 = Convert.ToInt32(Console.ReadLine());
                outfitService.DeleteOutfit(id6);
                break;

                case "13":
                System.Console.WriteLine("Enter outfit's id: ");
                int id7 = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter item's id: ");
                int id8 = Convert.ToInt32(Console.ReadLine());
                var outfitDetails = new OutfitDetails(){Outfit_id = id7,Item_id = id8};
                detailsService.AddDetail(outfitDetails);
                break;

                case "14":
                System.Console.WriteLine("All outfits details: ");
                detailsService.GetOutfitDetails();
                break;

                case "15":
                System.Console.WriteLine("Enter outfit's detail id that you want to change: ");
                int id9 = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter new item's id: ");
                int id10 = Convert.ToInt32(Console.ReadLine());
                detailsService.UpdateOutfitDetail(id9,id10);
                break;

                case "16":
                System.Console.WriteLine("Enter id of outfit's detail that you want to delete: ");
                int id11 = Convert.ToInt32(Console.ReadLine());
                detailsService.DeleteDetail(id11);
                break;

                case "17":
                System.Console.WriteLine("All outfit details with join: ");
                var data = detailsService.GetOutfitDetailsWithJoin();
                foreach (var i in data)
                {
                    Console.WriteLine(
                    $"OutfitDetailsId: {i.OutfitDetailsId}---" +
                    $"Outfit: {i.OutfitName}---" +
                    $"Item: {i.ItemName}"
                    );
                }
                break;

                
                case "18":
                System.Console.WriteLine("All outfit details with join: ");
                var data2 = itemService.GetAllItemsWithJoin();
                foreach (var i in data2)
                {
                    Console.WriteLine(
                    @$"Items Id: {i.ItemId}---" +
                    @$"Items Name: {i.ItemName}---" +
                    @$"Category's Name: {i.CategoryName}"
                    );
                }
                break;

            }
        }
        
    }
}