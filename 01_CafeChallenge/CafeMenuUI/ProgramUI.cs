using CafeContentRepo;

public class ProgramUI
{
    
    private readonly MenuRepository _menuRepo = new MenuRepository();

    public void Run()
    {
        SeedContentList();
        RunMenu();
    }

    public void RunMenu()
    {
        bool continueRunning = true;
        while(continueRunning)
        {
            Console.Clear();

            Console.WriteLine("Welcome to the Komodo Cafe Menu Interface. Please select an option: \n" +
            "1. Show All Menu Items \n" +
            "2. Create New Menu Items \n" +
            "3. Delete Menu Items \n" +
            "4. Exit");

            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                ShowAllItems();
                break;
                case "2":
                AddMenuItems();
                break;
                case "3":
                DeleteMenuItems();
                break;
                case "4":
                continueRunning = false;
                break;
                default:
                Console.WriteLine("I'm sorry. Please choose a valid numerical option. Press any key to continue.");
                Console.ReadLine();
                break;
            }
        }
    }

    private void ShowAllItems()
    {
            Console.Clear();

            List<Menu> listofItems = _menuRepo.GetMenu();

            foreach(Menu menuItem in listofItems)
            {
                DisplayContent(menuItem);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
    }
    
    private void DisplayContent(Menu menuItem)
    {
        Console.WriteLine($"Name: {menuItem.Name} \n" +
        $"Description: {menuItem.Description} \n" +
        $"Ingredients: {menuItem.Ingredients} \n" +
        $"Price: {menuItem.Price} \n" +
        $"Meal Number: {menuItem.MealNumber}");
    }

    private void AddMenuItems()
    {
        Console.Clear();

        Menu menuItem = new Menu();

        Console.WriteLine("Please enter a name for the dish: ");
        menuItem.Name = Console.ReadLine();

        Console.WriteLine("Please enter a description of the dish: ");
        menuItem.Description = Console.ReadLine();

        Console.WriteLine("Please enter the ingredients needed for the dish: ");
        menuItem.Ingredients = Console.ReadLine();

        Console.WriteLine("Please enter the price the dish will cost: ");
        menuItem.Price = double.Parse(Console.ReadLine());

        Console.WriteLine("Please enter the dish Meal Number");
        menuItem.MealNumber = int.Parse(Console.ReadLine());

        _menuRepo.AddItemsToMenu(menuItem);

    }

    private void DeleteMenuItems()
    {
        Console.Clear();
        Console.WriteLine("Which dish would you like to remove?");

        List<Menu> listOfItems = _menuRepo.GetMenu();

        int count = 0;

        foreach(Menu menuItem in listOfItems)
        {
            count ++;
            Console.WriteLine($"{count}. {menuItem.Name}");
        }

        int targetItemID = int.Parse(Console.ReadLine());
        int targetIndex = targetItemID;

        if(targetIndex >= 0 && targetIndex < listOfItems.Count)
        {
            Menu desiredItem = listOfItems[targetIndex];

            if(_menuRepo.DeleteExistingContent(desiredItem))
            {
                Console.WriteLine($"{desiredItem.Name} was successfully removed.");
            }
            else
            {
                Console.WriteLine("I'm sorry. I cannot do that.");
            }
        }
        else
        {
            Console.WriteLine("There are no menu items with that ID.");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }

    private void SeedContentList()
    {
        Menu latte = new Menu("Latte","Milky Espresso Drink","1 shot espresso, 3 ounces steamed milk", 4.99, 1);
        Menu vanillaFrap = new Menu("Vanilla Frappuccino", "Cold Blended Vanilla Coffee Drink","milk, ice, sugar, vanilla ice cream, whipped cream", 5.99, 2);
        Menu eggCheeseBagel = new Menu("Egg and Cheese Bagel", "Toasted Bagel with scrambled eggs and cheddar cheese", "toasted everything bagel, scrambled egg, cheddar cheese, salt and pepper",7.99, 3);
        Menu cheesecakePop = new Menu("Cheesecake Cake Pop","A sweet cheesecake made into a cakepop on a stick", "cheesecake base(flour, sugar, salt rolled into dough), crust crumbles, stick", 1.99, 4);

        _menuRepo.AddItemsToMenu(latte);
        _menuRepo.AddItemsToMenu(vanillaFrap);
        _menuRepo.AddItemsToMenu(eggCheeseBagel);
        _menuRepo.AddItemsToMenu(cheesecakePop);
    }

}
