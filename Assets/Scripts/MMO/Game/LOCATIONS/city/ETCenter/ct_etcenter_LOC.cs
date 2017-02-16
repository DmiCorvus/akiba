using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ct_etcenter_LOC : MonoBehaviour {

    public static void ctETCenter()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/City/ETCenter/etcenter_0_";
        daycycle_loc.DayCyclePIC();

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Развлекательный комплекс";
            MMOstart.lang_locTEXT1 = "Круглосуточный развлекательный комплекс. Подберите развлечение на свой вкус!";
            //действия
            MMOstart.lang_actions[0] = "Зайти";
            //переходы
            MMOstart.lang_places[0] = "Центр города";
            

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Entertainment center";
            MMOstart.lang_locTEXT1 = "Convenience and entertainment complex. Pick entertainment to your taste!";
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
      //  MMOstart.actionBTNcommand[NUM].onClick.AddListener(Suburb_place.goToShop);


        //НПС      


        //0 ПЕРЕХОД в центр
        NUM = 0;
        MMOstart.placesBTS[NUM].SetActive(true); //активируем        
        MMOstart.placesBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_places[NUM]; //называем 
        MMOstart.placesBTNcommand[NUM].onClick.AddListener(City_place.goToCenterCity);





    }
}
