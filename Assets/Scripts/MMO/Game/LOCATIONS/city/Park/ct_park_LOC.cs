using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ct_park_LOC : MonoBehaviour {

    public static void ctPark()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/City/Park/park_0_";
        daycycle_loc.DayCyclePIC();

    
        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Городской парк";
            MMOstart.lang_locTEXT1 = "Парк - хорошее место, чтобы погулять или провести здесь своё первое свидание.";

            //переходы
            MMOstart.lang_places[0] = "Центр города";
            MMOstart.lang_places[1] = "Парк аттракционов";

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "City park";
            MMOstart.lang_locTEXT1 = "Park - a good place to take a walk or spend your first date here.";

            //переходы
            MMOstart.lang_places[0] = "City center";
            MMOstart.lang_places[1] = "Amusement park";


        }

        //текст
        MMOstart.locNameTEXT.GetComponent<Text>().text = MMOstart.lang_locname;
        MMOstart.contentTEXT1.GetComponent<Text>().text = MMOstart.lang_locTEXT1;
        MMOstart.contentTEXT2.GetComponent<Text>().text = "";





        //0 ДЕЙСТВИE


        //НПС      


        //0 ПЕРЕХОД в центр
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToCenterCity);

        //1 ПЕРЕХОД к аттракционам
        NUM = 1;
        MMOstart.placesBTS[NUM].SetActive(true);  //активируем       
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM];//называем  
       // MMOstart.placesBTNcommand[NUM].onClick.AddListener(Home_place.goToKitchen);





    }


}
