using System;
using System.Collections;
using System.Collections.Generic;

namespace BadgeContentRepo;

public class Badge
{
    public int BadgeID {get; set;}

    public List<string> DoorAccessList {get; set;}

    public Badge(){}

    public Badge (int badgeID, List<string> doorAccessList)
    {
        BadgeID = badgeID;
        DoorAccessList = doorAccessList;
    }

}