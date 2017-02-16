using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ct_lovehotel_LOC : MonoBehaviour {


    public static void ctLoveHotel()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/City/LoveHotel/lovehotel_0_";
        daycycle_loc.DayCyclePIC();

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Лав отель";
            MMOstart.lang_locTEXT1 = "Отель свиданий. Вам нужен партнер, чтобы здесь заказать номер.";
            //действия
            MMOstart.lang_actions[0] = "Войти";       
            //переходы
            MMOstart.lang_places[0] = "Центр города";


        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Love hotel";
            MMOstart.lang_locTEXT1 = "Hotel meeting. You need a partner to order a hotel room.";
            //действия
            MMOstart.lang_actions[0] = "Enter";
            //переходы
            MMOstart.lang_places[0] = "City center";



        }

        //текст
        MMOstart.locNameTEXT.GetComponent<Text>().text = MMOstart.lang_locname;
        MMOstart.contentTEXT1.GetComponent<Text>().text = MMOstart.lang_locTEXT1;
        MMOstart.contentTEXT2.GetComponent<Text>().text = "";





        //0 ДЕЙСТВИE 
        NUM = 0;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[NUM];
        MMOstart.actionBTNcommand[NUM].onClick.AddListener(ct_lovehotel_LOC.ctLoveHotelREG);


        //НПС      


        //0 ПЕРЕХОД в центр
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToCenterCity);

    }

    //РЕГИСТРАЦИЯ В ЛАВ ОТЕЛЕ
    public static void ctLoveHotelREG()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = false;
        MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/City/LoveHotel/lovehotel_reg");

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Лав отель";
            MMOstart.lang_locTEXT1 = "Отель свиданий. Вам нужен партнер, чтобы здесь заказать номер.";
            //действия
            MMOstart.lang_actions[0] = "Заказать номер <color=#D8D83CFF>-25</color>";
            //переходы
            MMOstart.lang_places[0] = "Центр города";

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Love hotel";
            MMOstart.lang_locTEXT1 = "Hotel meeting. You need a partner to order a hotel room.";
            //действия
            MMOstart.lang_actions[0] = "Order number <color=#D8D83CFF>-25</color>";
            //переходы
            MMOstart.lang_places[0] = "City center";

        }

        //текст
        MMOstart.locNameTEXT.GetComponent<Text>().text = MMOstart.lang_locname;
        MMOstart.contentTEXT1.GetComponent<Text>().text = MMOstart.lang_locTEXT1;
        MMOstart.contentTEXT2.GetComponent<Text>().text = "";

        //0 ДЕЙСТВИE 
        NUM = 0;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[NUM];

        //0 ПЕРЕХОД в центр
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToCenterCity);


    }

}
