using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ct_metro_LOC : MonoBehaviour {

    ///ЛОКАЦИЯ 
    public static void ctMetro()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка

        daycycle_loc.needDayCycle = false;
        MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/City/metro_0_0");
        UIactive.mainPanel.GetComponent<Image>().color = new Color32(188, 188, 188, 255);


        ///
        ///LANG
        ///

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Метро / Кассы";
            MMOstart.lang_locTEXT1 = "Станция метро - здесь можно купить билет на поезд, чтобы отправиться в отдаленные места.";
            //действия
            MMOstart.lang_actions[0] = "Выход в город";
            MMOstart.lang_actions[1] = "Билет до <b>Окраины</b> <color=#D8D83CFF>-10</color>";
         

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Metro / Cashiern";
            MMOstart.lang_locTEXT1 = "Metro Station - here you can buy a train ticket to go to distant places.";
            //действия
            MMOstart.lang_actions[0] = "Exit to the city";
            MMOstart.lang_actions[1] = "Ticket to the <b>Suburb</b> <color=#D8D83CFF>-10</color>";

        }


        ///
        ///LOCATION
        ///
        MMOstart.locNameTEXT.GetComponent<Text>().text = MMOstart.lang_locname;
        MMOstart.contentTEXT1.GetComponent<Text>().text = MMOstart.lang_locTEXT1;
        MMOstart.contentTEXT2.GetComponent<Text>().text = "";



        //0 ДЕЙСТВИE выход центр города 
        NUM = 0;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[NUM];
        MMOstart.actionBTNcommand[NUM].onClick.AddListener(City_place.goToCenterCity);

        //1 ДЕЙСТВИE -  до окраины
        NUM = 1;
        MMOstart.actionBTS[NUM].SetActive(true);
        MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[NUM];
        MMOstart.actionBTNcommand[NUM].onClick.AddListener(City_place.goToSuburbTrain);







    }

}
