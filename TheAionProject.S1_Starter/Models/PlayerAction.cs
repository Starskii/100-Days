using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum PlayerAction
    {
        None,
        CharacterSetup,
        LookAround,
        LookAt,
        PickUpItem,
        Scavenge,
        PutDownItem,
        Travel,
        PlayerInfo,


        EditPlayer,
        EditName,
        EditAge,
        EditHomeTown,

        DisplayAllObjects,
        DisplayAllLocations,

        PlayerInventory,
        PlayerWallet,
        ListSpaceTimeLocations,
        ListItems,
        ListScavenge,

        Return,
        Exit
    }
}
