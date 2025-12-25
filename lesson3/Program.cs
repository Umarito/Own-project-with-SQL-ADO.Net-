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
            System.Console.WriteLine("1 - Add a category\n2 - Get all categories\n3 - Update category\n4 - Delete a category\n5 - Add an item\n6 - Get all items\n7 - Update item\n8 - Delete an item\n9 - Add an outfit\n10 - Get all outfits\n11 - Update outfit\n12 - Delete an outfit\n13 - Add an outfit detail\n14 - Get all outfit's details\n15 - Update outfit's detail\n16 - Delete a detail of an outfit\n17 - Get all outfit's details with join\n18 - Get all item and categories with join\n19 - Get all item and seasons with join\n20 - Get items by category\n21 - Get category by id\n22 - Get item by id\n23 - Get outfit detail by id\n24 - Get outfit by id\n25 - Get maximum price of items\n26 - Get minimum price of items\n27 - Get number of items in shop\n28 - Get average price of items\n29 - Get maximum price of outfit\n30 - Get minimum price of outfit\n31 - Get number of outfits in shop\n32 - Get average price of outfit in shop\n33 - \n34 - \n35 - Exit from a program");
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
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                        System.Console.WriteLine("Invalid id");
                        break;
                }
                System.Console.WriteLine("Enter new name of the category: ");
                string? name2 = Console.ReadLine();
                categoryService.UpdateCategory(id,name2);
                break;

                case "4":
                System.Console.WriteLine("Enter id of category that you want to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id2))
                {
                        System.Console.WriteLine("Invalid id");
                        break;
                }
                categoryService.DeleteCategory(id2);
                break;

                case "5":
                System.Console.WriteLine("Enter item's name: ");
                string? name3 = Console.ReadLine();
                System.Console.WriteLine("Enter item's category id: ");
                if (!int.TryParse(Console.ReadLine(), out int category_id))
                {
                        System.Console.WriteLine("Invalid id");
                        break;
                }
                System.Console.WriteLine("Enter item's price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        System.Console.WriteLine("You entered wrong thing. You need to type in decimal");
                    }System.Console.WriteLine("Enter item's status: ");
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
                if (!int.TryParse(Console.ReadLine(), out int id3))
                {
                        System.Console.WriteLine("Invalid id");
                        break;
                }
                System.Console.WriteLine("Enter new price of the item: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price2))
                    {
                        System.Console.WriteLine("You entered wrong thing. You need to type in decimal");
                    }
                itemService.UpdateItem(id3,price2);
                break;

                case "8":
                System.Console.WriteLine("Enter id of item that you want to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id4))
                {
                        System.Console.WriteLine("Invalid id");
                        break;
                }
                itemService.DeleteItem(id4);
                break;

                case "9":
                System.Console.WriteLine("Enter outfit's name: ");
                string? name4 = Console.ReadLine();
                System.Console.WriteLine("Enter outfit's rating: ");
                if (!int.TryParse(Console.ReadLine(), out int rating))
                    {
                        System.Console.WriteLine("You entered wrong thing. You need to type in integer");
                    }
                System.Console.WriteLine("Enter outfit's total price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal total_price))
                    {
                        System.Console.WriteLine("You entered wrong thing. You need to type in decimal");
                    }
                var outfit = new Outfit(){Outfit_name = name4,Rating = rating,TotalPrice = total_price};
                outfitService.AddOutfit(outfit);
                break;

                case "10":
                System.Console.WriteLine("All outfits: ");
                outfitService.GetOutfits();
                break;

                case "11":
                System.Console.WriteLine("Enter id of outfit that you want to change: ");
                if (!int.TryParse(Console.ReadLine(), out int id5))
                {
                        System.Console.WriteLine("Invalid id");
                        break;
                }
                System.Console.WriteLine("Enter new name of the outfit: ");
                string? name5 = Console.ReadLine();
                outfitService.UpdateOutfit(id5,name5);
                break;

                case "12":
                    try
                    {
                        
                System.Console.WriteLine("Enter id of outfit that you want to delete: ");
                int id6 = Convert.ToInt32(Console.ReadLine());
                outfitService.DeleteOutfit(id6);
                    }
                     catch(FormatException)
                    {
                        Console.WriteLine("You must enter a number.");
                    }
                     catch (Exception)
                    {
                        Console.WriteLine($"Unexpected error.");
                    } 
                break;

                case "13":
                try{
                System.Console.WriteLine("Enter outfit's id: ");
                int id7 = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter item's id: ");
                int id8 = Convert.ToInt32(Console.ReadLine());
                var outfitDetails = new OutfitDetails(){Outfit_id = id7,Item_id = id8};
                detailsService.AddDetail(outfitDetails);
                }
                    catch(FormatException)
                    {
                        Console.WriteLine("You must enter a number.");
                    }
                        catch (Exception)
                    {
                        Console.WriteLine($"Unexpected error.");
                    } 
                    
                break;

                case "14":
                System.Console.WriteLine("All outfits details: ");
                detailsService.GetOutfitDetails();
                break;

                case "15":
                System.Console.WriteLine("Enter outfit's detail id that you want to change: ");
                try{
                int id9 = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine("Enter new item's id: ");
                int id10 = Convert.ToInt32(Console.ReadLine());
                detailsService.UpdateOutfitDetail(id9,id10);
                }
                       catch (FormatException)
                    {
                        Console.WriteLine("You must enter a number.");
                    }
                        catch (Exception)
                    {
                        Console.WriteLine($"Unexpected error.");
                    }
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
                System.Console.WriteLine("All Item and their categories with join: ");
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

                
                case "19":
                var data3 = itemService.GetAllItemsBySeason();
                foreach (var i in data3)
                {
                    Console.WriteLine(
                    @$"Items Id: {i.ItemId}---" +
                    @$"Items Name: {i.ItemName}---" +
                    @$"Season's Name: {i.SeasonName}"
                    );
                }
                break;

                case "20":
                var data4 = itemService.GetAllItemsByCategory();
                foreach (var i in data4)
                {
                    Console.WriteLine(
                    @$"Items Id: {i.ItemId}---" +
                    @$"Items Name: {i.ItemName}---" +
                    @$"Category's Name: {i.CategoryName}"
                    );
                }
                break;

                case "21":
                categoryService.GetCategoryById();
                break;

                case "22":
                itemService.GetItemById();
                break;

                case "23":
                detailsService.GetOutfitDetailById();
                break;

                case "24":
                outfitService.GetOutfitById();
                break;

                case "25":
                System.Console.WriteLine("Item with maximum price in our shop: ");
                itemService.GetMaxPriceOfItem();
                break;

                case "26":
                System.Console.WriteLine("Item with minimum price in our shop: ");
                itemService.GetMinPriceOfItem();
                break;

                case "27":
                System.Console.WriteLine("Number of all items in our shop: ");
                itemService.GetNumberOfItems();
                break;

                case "28":
                System.Console.WriteLine("Average price of item in our shop: ");
                itemService.GetAvgPriceOfItems();
                break;
                
                case "29":
                System.Console.WriteLine("Outfit with maximum price in our shop: ");
                outfitService.GetMaxPriceOfOutfit();
                break;
                
                case "30":
                System.Console.WriteLine("Outfit with minimum price in our shop: ");
                outfitService.GetMinPriceOfOutfit();
                break;
                
                case "31":
                System.Console.WriteLine("Number of all outfits in our shop: ");
                outfitService.GetNumberOfOutfits();
                break;
                
                case "32":
                System.Console.WriteLine("Average price of outfit in our shop: ");
                outfitService.GetAvgPriceOfOutfits();
                break;
                
                case "33":
                break;

                case "34":
                break;
                
                case "35":
                System.Console.WriteLine("You exited from a program");
                return;

            }
        }
        
    }
}