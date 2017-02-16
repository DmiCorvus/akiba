using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_place : MonoBehaviour {

    //Метро
    public static void goToCenterMetro()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "city/metro_loc";
        MMOplayerlist.clearYou = true;

        ct_metro_LOC.ctMetro();
    }

    //Центр города
    public static void goToCenterCity()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "city/center_loc";
        MMOplayerlist.clearYou = true;

        ct_city_LOC.ctCity();
    }

    //Городской парк
    public static void goToCityPark()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "city/park_loc";
        MMOplayerlist.clearYou = true;

        ct_park_LOC.ctPark();
    }
    //Кафе
    public static void goToCafe()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "city/cafe_loc";
        MMOplayerlist.clearYou = true;

        ct_cafe_LOC.ctCafe();
    }

    //Развлекательный комплекс
    public static void goToETCenter()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "city/etcenter_loc";
        MMOplayerlist.clearYou = true;

        ct_etcenter_LOC.ctETCenter();
    }

    //торговый центр
    public static void goToSHCenter()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "city/shcenter_loc";
        MMOplayerlist.clearYou = true;

        ct_shcenter_LOC.ctSHCenter();
    }

    //ЛАВ ОТЕЛЬ
    public static void goToLoveHotel()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "city/lovehotel_loc";
        MMOplayerlist.clearYou = true;

        ct_lovehotel_LOC.ctLoveHotel();
    }



    //Поездка на окраину
    public static void goToSuburbTrain()
    {
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOshowplayers.yourLoc = "suburb/train_loc";
        MMOplayerlist.clearYou = true;
        su_trainwait_QS.destinationTrain = "metro:suburb_station";

        su_train_LOC.Train();
    }

}
