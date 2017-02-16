using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Kitchen_LOC : MonoBehaviour {

    public static void YourKithcen()
    {
        int NUM;
        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        daycycle_loc.needDayCycle = true;
        daycycle_loc.loc_DayCycle_name = "Img/Home/Kitchen/kitchen_0_";
        daycycle_loc.DayCyclePIC();

        //текст RU
        if (MMOsettings.LANG == "RU")
        {
            //описание локации
            MMOstart.lang_locname = "Дом / Кухня";
            MMOstart.lang_locTEXT1 = "Здесь вы можете приготовить что нибудь вкусненькое. Конечно при условии, что вы умеете готовить.";
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
            MMOstart.lang_locname = "House / Kitchen";
            MMOstart.lang_locTEXT1 = "Here you can cook something delicious. Of course, provided that you know how to cook.";
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





        //ДЕЙСТВИE       
        MMOstart.actionBTS[0].SetActive(true);
        MMOstart.actionBTStxt[0].GetComponent<Text>().text = "Готовка";




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
