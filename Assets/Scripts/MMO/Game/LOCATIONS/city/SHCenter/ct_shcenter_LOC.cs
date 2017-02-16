using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ct_shcenter_LOC : MonoBehaviour {

    public static void ctSHCenter()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/City/SHCenter/shcenter_0_";
        daycycle_loc.DayCyclePIC();

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Торговый центр";
            MMOstart.lang_locTEXT1 = "Круглосуточный торговый комплекс - место где можно купить себе обновку.";
            //действия
            MMOstart.lang_actions[0] = "Отдел одежды";
            MMOstart.lang_actions[1] = "Бытовая техника";
            //переходы
            MMOstart.lang_places[0] = "Центр города";


        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Shopping center";
            MMOstart.lang_locTEXT1 = "Convenience shopping mall - a place where you can buy new clothes and more.";
            //действия
            MMOstart.lang_actions[0] = "Clothing department";
            MMOstart.lang_actions[1] = "Household appliances division";
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
        //  MMOstart.actionBTNcommand[NUM].onClick.AddListener(Suburb_place.goToShop);

        //1 ДЕЙСТВИE 
        NUM = 1;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[NUM];
        //  MMOstart.actionBTNcommand[NUM].onClick.AddListener(Suburb_place.goToShop);

        //НПС      


        //0 ПЕРЕХОД в центр
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToCenterCity);





    }


}
