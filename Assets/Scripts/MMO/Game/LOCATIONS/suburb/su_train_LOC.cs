using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class su_train_LOC : MonoBehaviour {


    public static void Train()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = false;
        MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/Suburb/train");
        UIactive.mainPanel.GetComponent<Image>().color = new Color32(188, 188, 188, 10);

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Поезд / Вагон";
            MMOstart.lang_locTEXT1 = "Поездка на поезде - отличный способ, что бы быстро достичь пункта назначения. "; //Однако стоит опасаться извращенцов, подстерегающих женщин с короткими юбками.
            //переходы
            MMOstart.lang_actions[0] = "Выйти на улицу";

        }
        //текст EN
        if (MMOsettings.LANG == "EN")
        {
            //описание локации
            MMOstart.lang_locname = "Train";
            MMOstart.lang_locTEXT1 = "The train ride is a great way that would quickly reach the destination. However, it is feared perverts, trapping the women with short skirts.";
            //переходы
            MMOstart.lang_actions[0] = "Exit to street";

        }

        //текст
        MMOstart.locNameTEXT.GetComponent<Text>().text = MMOstart.lang_locname;
        MMOstart.contentTEXT1.GetComponent<Text>().text = MMOstart.lang_locTEXT1;
        MMOstart.contentTEXT2.GetComponent<Text>().text = "";

        //если поезд в пути
        if (su_trainwait_QS.trainRide == false)
        {
            su_trainwait_QS.trainWait.SetActive(true);
        }

        //если поезд прибыл
       if (su_trainwait_QS.trainRide == true)
        {
            su_trainwait_QS.trainRide = false;

            if (su_trainwait_QS.destinationTrain == "metro:city_station")
            {
                //0 ДЕЙСТВИE ПРИБЫЛ В ЦЕНТР
                NUM = 0;
                MMOstart.actionBTS[NUM].SetActive(true);
                MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[0];
                MMOstart.actionBTNcommand[NUM].onClick.AddListener(City_place.goToCenterMetro);
            }
            else  if (su_trainwait_QS.destinationTrain == "metro:suburb_station")
            {
                //0 ДЕЙСТВИE ПРИБЫЛ НА ОКРАИНУ
                NUM = 0;
                MMOstart.actionBTS[NUM].SetActive(true);
                MMOstart.actionBTStxt[NUM].GetComponent<Text>().text = MMOstart.lang_actions[0];
                MMOstart.actionBTNcommand[NUM].onClick.AddListener(Suburb_place.goToStation);
            }


        }
        


    }



  
       
   


}
