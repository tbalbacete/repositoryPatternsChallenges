using System;
using System.Collections;
namespace ClaimContentRepo;

public class ClaimContentRepository
{
    protected readonly List<Claim> _contentDirectory = new List<Claim>();
    protected readonly Queue<Claim> _claimQueue = new Queue<Claim>();

    public bool AddContentToDirectory(Claim content)
    {
        int startingCount = _contentDirectory.Count;
        
        _contentDirectory.Add(content);

        bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
        return wasAdded;
    }

    public List<Claim> GetContents()
    {
        return _contentDirectory;
    }

    public bool AddContentToQueue (Claim content)
    {
        int startingCount = _claimQueue.Count;

        _claimQueue.Enqueue(content);
        
        bool wasAdded = (_claimQueue.Count > startingCount) ? true : false;
        return wasAdded;
    }
    
    public void CheckIsValid(Claim content)
    {
        if((content.DateOfClaim - content.DateOfIncident).TotalDays < 30)
        {
            content.isValid = true;
        }
        else
        {
            content.isValid = false;
        }
    }
    public Queue<Claim> GetQueueContents()
    {
        return _claimQueue;
    }

}
