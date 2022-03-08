namespace CafeContentRepo;
public class MenuRepository
{
    protected readonly List<Menu> _menuDirectory = new List<Menu>();

    public bool AddItemsToMenu(Menu menuitem)
    {
        int startingCount = _menuDirectory.Count;

        _menuDirectory.Add(menuitem);

        bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;
        return wasAdded;
    }

    public List<Menu> GetMenu()
    {
        return _menuDirectory;
    }

    public bool DeleteExistingContent(Menu existingContent)
    {
        bool deleteResult = _menuDirectory.Remove(existingContent);
        return deleteResult;
    }
}
