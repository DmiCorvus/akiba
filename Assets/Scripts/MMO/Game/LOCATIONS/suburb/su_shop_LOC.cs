using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class su_shop_LOC : MonoBehaviour {


    ///ЛОКАЦИЯ 
    public static void suShop()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = false;
        MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/Suburb/shop_0_0");


        ///
        ///LANG
        ///

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Окраина / Магазин";
            MMOstart.lang_locTEXT1 = "Продуктовый магазин - отличное место, чтобы запастись товарами для приготовления пищи.";
            //действия
            MMOstart.lang_actions[0] = "Выйти из магазина";
            MMOstart.lang_actions[1] = "Основные продукты"; //морепродукты мясо яйца
            MMOstart.lang_actions[2] = "Специи"; //соус
            MMOstart.lang_actions[3] = "Овощи/Крупы"; //лук, рис, мука
            MMOstart.lang_actions[4] = "Особое"; //тофу
   

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Suburb / Food shop";
            MMOstart.lang_locTEXT1 = "Food shop - a great place to stock up on goods for cooking.";
            //действия
            MMOstart.lang_actions[0] = "Exit";
            MMOstart.lang_actions[1] = "Main products"; //морепродукты мясо яйца
            MMOstart.lang_actions[2] = "Condiment"; //соус
            MMOstart.lang_actions[3] = "Vegetables/Cereals"; //лук, рис, мука
            MMOstart.lang_actions[4] = "Else"; //тофу

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
        MMOstart.actionBTNcommand[NUM].onClick.AddListener(Suburb_place.goToStation);

        //1 ДЕЙСТВИE 
        NUM = 1;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[NUM];
        //  MMOstart.actionBTNcommand[NUM].onClick.AddListener(Home_place.goToHouse);


        //0 ПЕРЕХОД 
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(Suburb_place.goToRoad);







    }

}
