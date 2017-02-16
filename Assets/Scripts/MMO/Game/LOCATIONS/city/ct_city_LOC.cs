using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ct_city_LOC : MonoBehaviour {

    public static void ctCity()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/City/city_0_";
        daycycle_loc.DayCyclePIC();

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Центр города";
            MMOstart.lang_locTEXT1 = "Добро пожаловать в центр! Здесь находятся основные культурные, торговые и развлекательные заведения города.";
            //действия
            MMOstart.lang_actions[0] = "Спуститься в метро";
            //переходы
            MMOstart.lang_places[0] = "Торговый центр"; 
            MMOstart.lang_places[1] = "Развлекательный комплекс";
            MMOstart.lang_places[2] = "Кафе";
            MMOstart.lang_places[3] = "Парк";
            MMOstart.lang_places[4] = "Лав отель";

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "City center";
            MMOstart.lang_locTEXT1 = "Welcome to the center! There are major cultural, shopping and entertainment venues of the city.";
            //действия
            MMOstart.lang_actions[0] = "Down in the subway";
            //переходы
            MMOstart.lang_places[0] = "Shopping center";
            MMOstart.lang_places[1] = "Entertainment center";
            MMOstart.lang_places[2] = "Cafe";
            MMOstart.lang_places[3] = "Park";
            MMOstart.lang_places[4] = "Love hotel";

        }

        //текст
        MMOstart.locNameTEXT.GetComponent<Text>().text = MMOstart.lang_locname;
        MMOstart.contentTEXT1.GetComponent<Text>().text = MMOstart.lang_locTEXT1;
        MMOstart.contentTEXT2.GetComponent<Text>().text = "";





        //0 ДЕЙСТВИE 
        NUM = 0;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[NUM];
        MMOstart.actionBTNcommand[NUM].onClick.AddListener(City_place.goToCenterMetro);       

        //НПС      





        //0 ПЕРЕХОД ТЦ
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true);  //активируем       
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM];//называем  
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToSHCenter);

        //1 ПЕРЕХОД развлекательный комплекс
        NUM = 1;
        MMOstart.placesBTS[NUM].SetActive(true);  //активируем      
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToETCenter);

        //2 ПЕРЕХОД -кафе
        NUM = 2;
        MMOstart.placesBTS[NUM].SetActive(true);    //активируем   
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM];//называем 
       MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToCafe);

        //3 ПЕРЕХОД - парк
        NUM = 3;
        MMOstart.placesBTS[NUM].SetActive(true);    //активируем   
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM];//называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToCityPark);

        //4 ПЕРЕХОД - лав отель
        NUM = 4;
        MMOstart.placesBTS[NUM].SetActive(true);    //активируем   
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM];//называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToLoveHotel);




    }
}
