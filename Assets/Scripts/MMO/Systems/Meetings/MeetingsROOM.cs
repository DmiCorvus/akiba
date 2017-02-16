using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TNet;

public class MeetingsROOM : MonoBehaviour {


    ///ЗЕМЛЯ/ ВАША КОМНАТА  ///
    public static void MTEarthRoom()
    {

        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка
        MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/Earth/Room/room" + MMOsettings.roomDesign);
        //текст
        MMOstart.locNameTEXT.GetComponent<Text>().text = "Планета Земля /Комната";
        MMOstart.contentTEXT1.GetComponent<Text>().text = "";
        if (MMOsettings.locOwner == "owner") { MMOstart.contentTEXT2.GetComponent<Text>().text = "Особое: у нас в гостях "+ MMOsettings.mmoGroupNames[MeetingsSETTINGS.MTpartnerNUM]; }
        if (MMOsettings.locOwner == "guest") { MMOstart.contentTEXT2.GetComponent<Text>().text = "Особое: мы в гостях у " + MMOsettings.mmoGroupNames[MeetingsSETTINGS.MTpartnerNUM]; }

        MMOstart.heroInScene.SetActive(true);

        if (MeetingsSETTINGS.MTnude == false)
        {
            //узнаем цвет
            MeetingsSETTINGS.MThaircol = TNManager.GetChannelData<string>("MTinviteHairs" + MMOsettings.mmoGroupID[MeetingsSETTINGS.MThosterNUM]);
            //узнаем тело
            MeetingsSETTINGS.MTbody = TNManager.GetChannelData<int>("MTinviteBody" + MMOsettings.mmoGroupID[MeetingsSETTINGS.MThosterNUM]);
            //рисуем
            MMOstart.heroInSceneIMG.sprite = Resources.Load<Sprite>("Img/Dress/dress_" + MeetingsSETTINGS.MThaircol + MeetingsSETTINGS.MTbody);
        }

        if (MeetingsSETTINGS.MTnude == true)
        {
            //рисуем
            MMOstart.heroInSceneIMG.sprite = Resources.Load<Sprite>("Img/Dress/dress_" + MeetingsSETTINGS.MThaircol + MeetingsSETTINGS.MTbody+"nude");
        }





        //активируем кнопки 
        //   MMOstart.actionBTS[0].SetActive(true);
        //называем кнопку
        //   MMOstart.actionBTStxt[0].GetComponent<Text>().text = "Переставить мебель";
        //назначаем действие кнопки 0
        //    MMOstart.actionBTScommand[0] = "roomDesign";


        //ДЕЙСТВИЯ ОБЩЕЕ     
        MMOstart.actionBTS[0].SetActive(true);
        //называем кнопку
        MMOstart.actionBTStxt[0].GetComponent<Text>().text = "Предложить";
        //назначаем действие кнопки 0
       // MMOstart.actionBTScommand[0] = "sexroom/accept/";

        MMOstart.actionBTS[1].SetActive(true);
        //называем кнопку
        MMOstart.actionBTStxt[1].GetComponent<Text>().text = "Действовать";
        //назначаем действие кнопки 0
      //  MMOstart.actionBTScommand[1] = "sexroom/actions/";






        //активируем переходы
        MMOstart.placesBTS[0].SetActive(true);
        //называем переходы
        MMOstart.placesBTStxt[0].GetComponent<Text>().text = "ЗАВЕРШИТЬ ВСТРЕЧУ";
        //назначаем действие переходу 0
        MMOstart.placesBTScommand[0] = "earth/city";
    }





    public static void MTEarthRoomProgress()
    {

        MMOstart.ClearingBTNS();//очистка кнопок
                                //ВАРИАНТ СЦЕНЫ 0
                                //картинка

        if (MeetingsSETTINGS.picChange == "SXROOMcuddle")     { MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/sex/before/cuddle/" + MeetingsSETTINGS.MThaircol +"_1");  }
        if (MeetingsSETTINGS.picChange == "SXROOMpantstouch") { MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/sex/before/touchpants/" + MeetingsSETTINGS.MThaircol + "_1"); }
        if (MeetingsSETTINGS.picChange == "SXROOMforcedstart") { MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/sex/before/forcedstart/" + MeetingsSETTINGS.MThaircol + "_1"); }
        if (MeetingsSETTINGS.picChange == "SXROOMshowboobs") { MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/sex/before/showboobs/" + MeetingsSETTINGS.MThaircol + "_1"); }
        if (MeetingsSETTINGS.picChange == "SXROOMshowpants") { MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/sex/before/showpants/" + MeetingsSETTINGS.MThaircol + "_1"); }
        if (MeetingsSETTINGS.picChange == "SXROOMgivebody") { MMOstart.SceneIMG.sprite = Resources.Load<Sprite>("Img/sex/before/givebody/" + MeetingsSETTINGS.MThaircol + "_1"); }

        //текст
        MMOstart.locNameTEXT.GetComponent<Text>().text = "Планета Земля /Комната";
        MMOstart.contentTEXT1.GetComponent<Text>().text = "";
        if (MeetingsSETTINGS.picChange == "SXROOMcuddle") { MMOstart.contentTEXT1.GetComponent<Text>().text = "Действие - тискать."; }
        if (MeetingsSETTINGS.picChange == "SXROOMpantstouch") { MMOstart.contentTEXT1.GetComponent<Text>().text = "Действие - залезть в трусики."; }
        if (MeetingsSETTINGS.picChange == "SXROOMforcedstart") { MMOstart.contentTEXT1.GetComponent<Text>().text = "Действие - повалить в койку."; }
        if (MeetingsSETTINGS.picChange == "SXROOMshowboobs") { MMOstart.contentTEXT1.GetComponent<Text>().text = "Действие - показать грудь."; }
        if (MeetingsSETTINGS.picChange == "SXROOMshowpants") { MMOstart.contentTEXT1.GetComponent<Text>().text = "Действие - показать трусики."; }
        if (MeetingsSETTINGS.picChange == "SXROOMgivebody") { MMOstart.contentTEXT1.GetComponent<Text>().text = "Действие - предложить себя."; }

        if (MMOsettings.locOwner == "owner") { MMOstart.contentTEXT2.GetComponent<Text>().text = "Особое: у нас в гостях " + MMOsettings.mmoGroupNames[MeetingsSETTINGS.MTpartnerNUM]; }
        if (MMOsettings.locOwner == "guest") { MMOstart.contentTEXT2.GetComponent<Text>().text = "Особое: мы в гостях у " + MMOsettings.mmoGroupNames[MeetingsSETTINGS.MTpartnerNUM]; }


        //ДЕЙСТВИЯ ОБЩЕЕ     
        MMOstart.actionBTS[0].SetActive(true);
        //называем кнопку
        MMOstart.actionBTStxt[0].GetComponent<Text>().text = "Предложить";
        //назначаем действие кнопки 0
    //    MMOstart.actionBTScommand[0] = "sexroom/accept/";

        MMOstart.actionBTS[1].SetActive(true);
        //называем кнопку
        MMOstart.actionBTStxt[1].GetComponent<Text>().text = "Действовать";
        //назначаем действие кнопки 0
    //    MMOstart.actionBTScommand[1] = "sexroom/actions/";



        //активируем переходы
        MMOstart.placesBTS[0].SetActive(true);
        //называем переходы
        MMOstart.placesBTStxt[0].GetComponent<Text>().text = "ЗАВЕРШИТЬ ВСТРЕЧУ";
        //назначаем действие переходу 0
    //    MMOstart.placesBTScommand[0] = "earth/city";
    }




    }
