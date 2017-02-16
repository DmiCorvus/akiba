using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class su_road_LOC : MonoBehaviour {


    ///ЛОКАЦИЯ 
    public static void suRoad()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/Suburb/road_0_";
        daycycle_loc.DayCyclePIC();

        ///
        ///LANG
        ///

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Окраина / Дорога";
            MMOstart.lang_locTEXT1 = "Станция расположена довольно далеко от вашего дома. Знакомые говорят, что здесь опасно появляться в позднее время.";

            //переходы
            MMOstart.lang_places[0] = "к Ж/Д станции";
            MMOstart.lang_places[1] = "к вашему дому";

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Suburb / Road";
            MMOstart.lang_locTEXT1 = "The station is located too far from your home. Friends say that it's dangerous to walk late at night.";

            //переходы
            MMOstart.lang_places[0] = "To train station";
            MMOstart.lang_places[1] = "To your house";
        }


        ///
        ///LOCATION
        ///
        MMOstart.locNameTEXT.GetComponent<Text>().text = MMOstart.lang_locname;
        MMOstart.contentTEXT1.GetComponent<Text>().text = MMOstart.lang_locTEXT1;
        MMOstart.contentTEXT2.GetComponent<Text>().text = "";






        //0 ПЕРЕХОД 
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(Suburb_place.goToStation);


        //1 ПЕРЕХОД 
        NUM = 1;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(Suburb_place.goToYard);



    }

}
