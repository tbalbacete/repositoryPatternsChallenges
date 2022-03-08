using System;
using System.Collections;
using System.Collections.Generic;

namespace BadgeContentRepo;
public class BadgeContentRepository
{

    protected Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

    public bool AddContentToDirectory(Badge content)
    {
        int startingCount = _badgeDictionary.Count;

        _badgeDictionary.Add(content.BadgeID, content.DoorAccessList);

        bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
        return wasAdded;
    }

    public Dictionary<int, List<string>> GetContents()
    {
        return _badgeDictionary;
    }

    public List<string> GetListOfDoorsByID(int id)
    {
        List<string> doors;
        bool isIDPresent = _badgeDictionary.TryGetValue(id, out doors);

        if(isIDPresent)
        {
            return doors;
        }
        else
        {
            return null;
        }
    }

}
