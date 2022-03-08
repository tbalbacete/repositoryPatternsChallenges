using System;
using System.Collections;
namespace ClaimContentRepo;

public class Claim
{
    public int ClaimID {get; set;}
    public ClaimType TypeOfClaim {get; set;}
    public string Description {get; set;}
    public double ClaimAmount {get; set;}
    public DateTime DateOfIncident {get; set;}
    public DateTime DateOfClaim {get; set;}
    public bool isValid {get; set;}
    
    public Claim(){}
    public Claim(int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
    {
        ClaimID = claimID;
        TypeOfClaim = claimType;
        Description = description;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
    }

}

public enum ClaimType
{
    Car, Home, Theft
}

