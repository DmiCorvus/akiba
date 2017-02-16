using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suburb_place : MonoBehaviour {


    //ВАШ ДВОР
    public static void goToYard()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;       
        MMOshowplayers.yourLoc = "suburb/street_loc";
        MMOplayerlist.clearYou = true;

        su_street_LOC.suStreet();
    }

    //ДОРОГА
    public static void goToRoad()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "suburb/road_loc";
        MMOplayerlist.clearYou = true;

        su_road_LOC.suRoad();
    }

    //Станция
    public static void goToStation()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "suburb/station_loc";
        MMOplayerlist.clearYou = true;

        su_station_LOC.suStation();
    }

    //МАГАЗИН
    public static void goToShop()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "suburb/foodshop_loc";
        MMOplayerlist.clearYou = true;

        su_shop_LOC.suShop();
    }

    //Поездка в центр
    public static void goToCenterTrain()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "suburb/train_loc";
        MMOplayerlist.clearYou = true;
        su_trainwait_QS.destinationTrain = "metro:city_station";

        su_train_LOC.Train();
    }


}
