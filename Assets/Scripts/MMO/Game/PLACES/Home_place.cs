using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_place : MonoBehaviour {

    //вход в дом
    public static void goToHouse()
    {
        MMOplayerlist.uniqueLOC = 1;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "house_loc";
        MMOplayerlist.clearYou = true;

        Longue_LOC.YourLongue();
    }


    //переход в ванную
    public static void goToBathroom()
    { Bathroom_LOC.Bathroom(); }

    //переход к вам в комнату
    public static void goToYourRoom()
    { Room_LOC.YourRoom();  }

    //переход  в гостиную
    public static void goToLongue()
    { Longue_LOC.YourLongue(); }

    //переход  на кухню
    public static void goToKitchen()
    { Kitchen_LOC.YourKithcen(); }

    //переход  к брату
    public static void goToBroRoom()
    { BrotherRoom_LOC.BroRoom(); }

    //переход  к сестре
    public static void goToSisRoom()
    { SisterRoom_LOC.SisRoom(); }

}
