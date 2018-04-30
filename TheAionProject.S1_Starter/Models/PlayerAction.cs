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

        Act,
        Options,

        LookAround,
        LookAt,

        TalkTo,
        Trade,
        Heal,

        PickUpItem,
        Scavenge,
        PutDownItem,
        Travel,
        PlayerInfo,


        EditPlayer,
        EditName,
        EditAge,
        EditHomeTown,

        DisplayPlayerInventory,

        AdminMenu,
        DisplayAllObjects,
        DisplayAllLocations,
        DisplayAllNPC,
        DisplayLocationsVisited,

        PlayerInventory,
        PlayerWallet,

        Return,
        Exit
    }
}
