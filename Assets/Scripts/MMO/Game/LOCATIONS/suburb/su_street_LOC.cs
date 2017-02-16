using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class su_street_LOC : MonoBehaviour {


    ///ЛОКАЦИЯ 
    public static void suStreet()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/Suburb/street_0_";
        daycycle_loc.DayCyclePIC();

        ///
        ///LANG
        ///

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Окраина / Улица";
            MMOstart.lang_locTEXT1 = "Вы стоите во дворе вашего дома, доставшегося вам от родителей, погибших в авиакатастрофе.";
            //действия
            MMOstart.lang_actions[0] = "Зайти в дом";
            //переходы
            MMOstart.lang_places[0] = "Ж/Д станция";

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Suburb / Street";
            MMOstart.lang_locTEXT1 = "You are standing in the yard of your home, you inherited from your parents, who died in a plane crash.";
            //действия
            MMOstart.lang_actions[0] = "Enter your house";
            //переходы
            MMOstart.lang_places[0] = "Train station";
        }


        ///
        ///LOCATION
        ///
        MMOstart.locNameTEXT.GetComponent<Text>().text = MMOstart.lang_locname;
        MMOstart.contentTEXT1.GetComponent<Text>().text = MMOstart.lang_locTEXT1;
        MMOstart.contentTEXT2.GetComponent<Text>().text = "";



        //0 ДЕЙСТВИE 
        NUM = 0;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[NUM];
        MMOstart.actionBTNcommand[NUM].onClick.AddListener(Home_place.goToHouse);


        //0 ПЕРЕХОД 
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(Suburb_place.goToRoad);







    }




}
