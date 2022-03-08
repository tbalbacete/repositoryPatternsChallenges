namespace CafeContentRepo;

public class Menu
{
    public string Name {get; set;}
    public string Description {get; set;}
    public string Ingredients {get; set;}
    public double Price {get; set;}
    public int MealNumber {get; set;}

    public Menu(){}

    public Menu(string name, string description, string ingredients, double price, int mealNumber)
    {
        Name = name;
        Description = description;
        Ingredients = ingredients;
        Price = price;
        MealNumber = mealNumber;
    }


}

