using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using BadgeContentRepo;

public class ProgramUI
{
    private BadgeContentRepository _badgeDirectory = new BadgeContentRepository();

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

            Console.WriteLine("Welcome to the Badge Selection Interface. Please select an option: \n" +
            "1. Add a badge \n" +
            "2. Edit a badge \n" +
            "3. List all Badges \n" +
            "4. Exit");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                CreateNewBadge();
                break;
                case "2":
                EditExistingBadge();
                break;
                case "3":
                ShowAllBadges();
                break;
                case "4":
                continueRunning = false;
                break;
                default:
                Console.WriteLine("I'm sorry. You seem to have entered an invalid option. Press any key to continue.");
                Console.ReadLine();
                RunMenu();
                break;
            }
        }
    }

    private void CreateNewBadge()
    {
        Console.Clear();
        Badge content = new Badge();
        Console.WriteLine("Enter a new badge ID: ");
        content.BadgeID = int.Parse(Console.ReadLine());

        List<string> _doors = new List<string>();
 
        bool continueAdding = true;
        do
        {
            Console.Clear();   
            Console.WriteLine("Enter a door this badge can access: ");
            
            _doors.Add(Console.ReadLine());
            Console.WriteLine("Would you like to add another door? \n" +
            "1. Yes \n"+
            "2. No");
            string userInput = Console.ReadLine();
            int inputChoice = int.Parse(userInput);
            
            switch (inputChoice)
            {
                case 1:
                break;
                case 2:
                continueAdding = false;
                break;
                default:
                continueAdding = false;
                break;
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            
        }while(continueAdding == true);
        

        content.DoorAccessList = _doors;
        _badgeDirectory.AddContentToDirectory(content);
    }



    private void EditExistingBadge()
    {
        Console.Clear();
        Dictionary<int, List<string>> _showBadges = _badgeDirectory.GetContents();
        Console.WriteLine("Choose a badge number to update: ");
        int badgeNumber = int.Parse(Console.ReadLine());
        
        _badgeDirectory.GetListOfDoorsByID(badgeNumber);

        // List<string> badgeDoors =_badgeDirectory.GetListOfDoorsByID(badgeNumber);
        foreach(KeyValuePair<int, List<string>> kvp in _showBadges)
        {
            if(kvp.Key.Equals(badgeNumber))
            {
                foreach (var listMember in _showBadges[badgeNumber])
                {
                    Console.WriteLine(listMember + " ");
                }

                
                Console.WriteLine("Choose a door to remove: ");
                string doorToRemove = Console.ReadLine();
                kvp.Value.Remove(doorToRemove);
            }
        }
    }

    

    private void ShowAllBadges()
    {
        Console.Clear();
        Dictionary<int, List<string>> _showBadges = _badgeDirectory.GetContents();
        
        foreach(var contents in _showBadges.Keys)
        
        {
            Console.Write("Badge ID: " + contents + " Door Access: ");
            
            foreach(var listMember in _showBadges[contents])
            {
                Console.Write(listMember +" ");
            }
            Console.WriteLine("");
            
        }

        Console.WriteLine("\nPress any key to continue.");
        Console.ReadLine();
    }

    private void DisplayBadges (Badge content)
    {
        Console.WriteLine($"{content.BadgeID} {content.DoorAccessList}");
    }

    private void SeedContentList()
    {

    }
}