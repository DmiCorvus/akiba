﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Longue_LOC : MonoBehaviour {


    public static void YourLongue()
    {       
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/Home/Longue/longue_0_";
        daycycle_loc.DayCyclePIC();

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Дом / Гостиная";
            MMOstart.lang_locTEXT1 = "В этой комнате можно пообщаться с гостями или просто немного отдохнуть.";
            //действия
            MMOstart.lang_actions[0] = "Выйти на улицу";
            //переходы
            MMOstart.lang_places[0] = "Гостиная";
            MMOstart.lang_places[1] = "Кухня";
            MMOstart.lang_places[2] = "Ванная";
            MMOstart.lang_places[3] = "Ваша комната";
            MMOstart.lang_places[4] = "Комната брата";
            MMOstart.lang_places[5] = "Комната сестры";
        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "House / Living room";
            MMOstart.lang_locTEXT1 = "In this room, you can chat with guests or just relax a bit.";
            //действия
            MMOstart.lang_actions[0] = "Exit to street";
            //переходы
            MMOstart.lang_places[0] = "Living room";
            MMOstart.lang_places[1] = "Kitchen";
            MMOstart.lang_places[2] = "Bathroom";
            MMOstart.lang_places[3] = "Your room";
            MMOstart.lang_places[4] = "Brother room";
            MMOstart.lang_places[5] = "Sister room";
        }

        //текст
        MMOstart.locNameTEXT.GetComponent<Text>().text = MMOstart.lang_locname;
        MMOstart.contentTEXT1.GetComponent<Text>().text = MMOstart.lang_locTEXT1;
        MMOstart.contentTEXT2.GetComponent<Text>().text = "";





        //0 ДЕЙСТВИE
        NUM = 0;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[0];
        MMOstart.actionBTNcommand[NUM].onClick.AddListener(Suburb_place.goToYard);

        //1 ДЕЙСТВИE  
        MMOstart.actionBTS[1].SetActive(true);
        MMOstart.actionBTStxt[1].GetComponent<Text>().text = "Смотреть ТВ";

        //НПС      


        //0 ПЕРЕХОД 
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(Home_place.goToLongue);

        //1 ПЕРЕХОД 
        NUM = 1;
        MMOstart.placesBTS[NUM].SetActive(true);  //активируем       
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM];//называем  
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(Home_place.goToKitchen);

        //2 ПЕРЕХОД
        NUM = 2;
        MMOstart.placesBTS[NUM].SetActive(true);  //активируем      
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(Home_place.goToBathroom);

        //3 ПЕРЕХОД 
        NUM = 3;
        MMOstart.placesBTS[NUM].SetActive(true);    //активируем   
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM];//называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(Home_place.goToYourRoom);

        //4 ПЕРЕХОД
        NUM = 4;
        if (Family.brother == true)
        {
            MMOstart.placesBTS[NUM].SetActive(true);    //активируем        
            MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM];//называем 
            MMOstart.placesBTNcommand[NUM].onClick.AddListener(Home_place.goToBroRoom);
        }

        //5 ПЕРЕХОД
        NUM = 5;
        if (Family.sister == true)
        {
            MMOstart.placesBTS[NUM].SetActive(true);   //активируем          
            MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM];//называем 
            MMOstart.placesBTNcommand[NUM].onClick.AddListener(Home_place.goToSisRoom);
        }

    }

}