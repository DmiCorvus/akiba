using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class su_station_LOC : MonoBehaviour {


    ///ЛОКАЦИЯ 
    public static void suStation()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка

        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/Suburb/station_0_";
        daycycle_loc.DayCyclePIC();
        UIactive.mainPanel.GetComponent<Image>().color = new Color32(188, 188, 188, 255);


        ///
        ///LANG
        ///

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Окраина / Станция";
            MMOstart.lang_locTEXT1 = "Ж/Д станция - здесь можно купить билет на поезд. Также рядом расположен круглосуточный продуктовый магазин.";
            //действия
            MMOstart.lang_actions[0] = "Зайти в магазин";
            MMOstart.lang_actions[1] = "Билет до  <b>Центра</b> <color=#D8D83CFF>-10</color>";
            //переходы
            MMOstart.lang_places[0] = "Дорога домой";

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Suburb / Station";
            MMOstart.lang_locTEXT1 = "Train station - you can buy a train ticket. Also nearby is a convenience food shop.";
            //действия
            MMOstart.lang_actions[0] = "Enter to the shop";
            MMOstart.lang_actions[1] = "Ticket to the <b>Center</b> <color=#D8D83CFF>-10</color>";
            //переходы
            MMOstart.lang_places[0] = "Road to your house";
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
        MMOstart.actionBTNcommand[NUM].onClick.AddListener(Suburb_place.goToShop);

        //1 ДЕЙСТВИE -  до центра
        NUM = 1;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[NUM];
        MMOstart.actionBTNcommand[NUM].onClick.AddListener(Suburb_place.goToCenterTrain);


        //0 ПЕРЕХОД 
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(Suburb_place.goToRoad);







    }


}
