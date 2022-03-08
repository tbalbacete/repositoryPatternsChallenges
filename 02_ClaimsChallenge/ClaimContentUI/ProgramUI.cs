using System;
using System.Collections;
using ClaimContentRepo;


public class ProgramUI
{

    private readonly ClaimContentRepository _contentDirectory = new ClaimContentRepository();
    private ClaimContentRepository _claimQueue = new ClaimContentRepository();

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

            Console.WriteLine("Welcome to the Claims Processing Database. Please select an option: \n" +
            "1. See all claims \n" +
            "2. Take care of next claim \n" +
            "3. Enter a new claim \n" +
            "4. Exit");

            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                ShowAllClaims();
                break;
                case "2":
                ShowNextClaim();
                break;
                case "3":
                CreateNewClaim();
                break;
                case "4":
                continueRunning = false;
                break;
            }
        }
    }

    private void ShowAllClaims()
    {
    Console.Clear();

    List<Claim> listOfClaims = _contentDirectory.GetContents();

    Console.WriteLine(
    "Claim ID       Type        Description             Amount      DateOfAccident      DateOfClaim     isValid ");
    foreach(Claim content in listOfClaims)
    {
        DisplayContent(content);
    }
    Console.WriteLine("Press any key to continue.");
    Console.ReadLine();
    }

    private void DisplayContent(Claim content)
    {
        Console.WriteLine(
        $"{content.ClaimID}     {content.TypeOfClaim}       {content.Description}               ${content.ClaimAmount}       {content.DateOfIncident}        {content.DateOfClaim}       {content.isValid}");
        
    }

    private void ShowNextClaim()
    {
        Console.Clear();

        Queue<Claim> queueofClaims = _claimQueue.GetQueueContents();

        do
        {
            Console.Clear();
            Claim firstItem = queueofClaims.Peek();
            Console.WriteLine($"Claim ID: {firstItem.ClaimID} \n" +
            $"Type of Claim: {firstItem.TypeOfClaim} \n" +
            $"Claim Description: {firstItem.Description} \n" +
            $"Claim Amount: {firstItem.ClaimAmount} \n" +
            $"Date of Incident: {firstItem.DateOfIncident} \n" +
            $"Date of Claim: {firstItem.DateOfClaim} \n" +
            $"Is Valid: {firstItem.isValid}");
            Console.WriteLine("Would you like to deal with this claim now? y/n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "y":
                queueofClaims.Dequeue();
                Console.WriteLine("Total remaining Claims: {0}", queueofClaims.Count);
                Console.WriteLine("Press enter to move on to the next queue item.");
                Console.ReadLine();
                break;

                case "n":
                RunMenu();
                break;
            }
        } while (queueofClaims.Count > 0);
        Console.WriteLine("You have no remaining claims. Press any key to return to the menu.");
        Console.ReadLine();

    }

    private void CreateNewClaim()
    {
        Console.Clear();
        Claim content = new Claim();
        Console.WriteLine("Enter the claim id: ");
        content.ClaimID = int.Parse(Console.ReadLine());

        Console.WriteLine("Select a claim type: \n" +
        "1. Car \n" +
        "2. Home \n" +
        "3. Theft \n" );
        string typeResponse = Console.ReadLine();
        switch(typeResponse)
        {
            case "1":
            content.TypeOfClaim = ClaimType.Car;
            break;
            case "2":
            content.TypeOfClaim = ClaimType.Home;
            break;
            case "3":
            content.TypeOfClaim = ClaimType.Theft;
            break;
            default:
            Console.WriteLine("I'm sorry. you entered an invalid option. Press enter to enter your claim again.");
            Console.ReadLine();
            CreateNewClaim();
            break;
        }

        Console.Clear();
        Console.WriteLine("Please enter a claim description: ");
        content.Description = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Enter the cost of damages: ");
        content.ClaimAmount = double.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Enter the year the accident happened: ");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Month the accident happened numerically (1-12): ");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the numerical day of the month the incident happened: ");
        int day = int.Parse(Console.ReadLine());

        DateTime incidentDate = new DateTime(year, month, day);
        content.DateOfIncident = incidentDate;

        content.DateOfClaim = DateTime.Now;

        _claimQueue.CheckIsValid(content);

        _contentDirectory.AddContentToDirectory(content);
        _claimQueue.AddContentToQueue(content);

        Console.WriteLine("Your claim has been added. Press any key to continue.");
        Console.ReadLine();
    }

    private void SeedContentList()
    {
        Claim claim1 = new Claim(1, ClaimType.Car, "bumper", 1000, new DateTime(2022, 02, 05), new DateTime(2022, 03, 03));
        Claim claim2 = new Claim(2, ClaimType.Home, "fire", 1000, new DateTime(2021, 12, 25), new DateTime(2022, 03, 03));

        _claimQueue.CheckIsValid(claim1);
        _claimQueue.CheckIsValid(claim2);

        _contentDirectory.AddContentToDirectory(claim1);
        _contentDirectory.AddContentToDirectory(claim2);
        _claimQueue.AddContentToQueue(claim1);
        _claimQueue.AddContentToQueue(claim2);
    }
}