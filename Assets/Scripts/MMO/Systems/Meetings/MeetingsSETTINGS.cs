using UnityEngine;
using System.Collections;
using TNet;
using UnityEngine.UI;

//ПРИКРЕПЛЕН: к ммо
//ОПИСАНИЕ: ПАРАМЕТРЫ ВСТРЕЧ
public class MeetingsSETTINGS : MonoBehaviour {

    public static int MTinGuest; //мы в гостях
                                 //наш пол
    public static string MThaircol;                //наш цвет волос
    public static int MTbody;                  //наша внешность

    public static int MTpartnerNUM; //номер партнера - в ММО действиях
    public static int MThosterNUM; //владелец локи номер
    public static int MTpartnerIDloc;  //IDпартнера для локации

    //действия
    public static string MTactions;
    public static string MTactionsPrevious;//предыдущее

    public static bool MTactionsLocked = false;
    public static bool MTactionsWaiting = false;


    public static bool MTnude = false;

    public static string picChange = "";
    //вписываем параметры
    void OnEnable()
    {
        MTinGuest = 0;
        MTnude = false;       

        MTactionsLocked = false;
        MTactionsWaiting = false;
        MTactions = "";
    }



    void Update()
    {

        
        if ((MTinGuest ==1)&&(MMOsettings.mmoGroup ==1)&&(MTactionsLocked == false))       
        {

            //получаем команду события
            MTactions = TNManager.GetChannelData<string>("SXROOMactions" + MMOsettings.mmoGroupID[MThosterNUM]);
            print("test"+MTactions);
        }


        if ((MTinGuest == 1) && (MMOsettings.mmoGroup == 1))
        {

            //СОБЫТИЯ
            if ((MTactions != "")&&(MTactions != MTactionsPrevious))
            {
                print("выполнение XXX");

               // MTactionsLocked = true;                
               // MTactionsWaiting = true;

                //выполняем событие

                //-раздевание
                if (MTactions == "SXROOMundress")
                {
                    MTnude = true;
                    MeetingsROOM.MTEarthRoom();
                }
                //-тискать
                if (MTactions == "SXROOMcuddle")
                {
                    picChange = "SXROOMcuddle";
                    MeetingsROOM.MTEarthRoomProgress();
                }
                //-в трусики
                if (MTactions == "SXROOMpantstouch")
                {
                    picChange = "SXROOMpantstouch";
                    MeetingsROOM.MTEarthRoomProgress();
                }
                //-завалить
                if (MTactions == "SXROOMforcedstart")
                {
                    picChange = "SXROOMforcedstart";
                    MeetingsROOM.MTEarthRoomProgress();
                }
                //-показать грудь
                if (MTactions == "SXROOMshowboobs")
                {
                    picChange = "SXROOMshowboobs";
                    MeetingsROOM.MTEarthRoomProgress();
                }
                //-показать труселя
                if (MTactions == "SXROOMshowpants")
                {
                    picChange = "SXROOMshowpants";
                    MeetingsROOM.MTEarthRoomProgress();
                }
                //-предложить себя
                if (MTactions == "SXROOMgivebody")
                {
                    picChange = "SXROOMgivebody";
                    MeetingsROOM.MTEarthRoomProgress();
                }

                MTactionsPrevious = MTactions;
                MTactions = "";
            }
        }
        









        if ((MTinGuest == 0)&&(MMOsettings.mmoGroup == 1))
        {
            //отлавливаем приглашения            
            int chkinvite;
            chkinvite = TNManager.GetChannelData<int>("MTinviteADD" + MMOsettings.mmoGroupID[MMOsettings.mmoGroupCurrentSlot]);
            if (chkinvite == 1)
            {
               

                TNManager.SetChannelData("MTinviteADD" + MMOsettings.mmoGroupID[MMOsettings.mmoGroupCurrentSlot], 0);// INVITE ADD
                MMOinformer.IMbtnsFormTXT.SetActive(true);//включить поле
                MMOinformer.infoMSGtext.GetComponent<Text>().text = "";//очищаем текст
                //заполнить его
                int chknuminviter; 
                chknuminviter=  TNManager.GetChannelData<int>("MTinviteID" + MMOsettings.mmoGroupID[MMOsettings.mmoGroupCurrentSlot]);
                MMOinformer.IMbtnsFormTXT.GetComponent<Text>().text = "Вас приглашает в гости " + MMOsettings.mmoGroupNames[chknuminviter];//

                //формируем параметры кнопок
                MMOinformer.IMtypeBTNaccept = "acceptInvite";
                MMOinformer.IMtypeBTNcancel = "cancelInvite";

                MTpartnerIDloc = MMOsettings.mmoGroupID[chknuminviter]; //ID 



            }

            //Хост ждет гостя
            int chkinviteHOST;
            chkinviteHOST = TNManager.GetChannelData<int>("MTinviteHOST" + MMOsettings.mmoGroupID[MMOsettings.mmoGroupCurrentSlot]);           

            if ((chkinviteHOST == 1)&&(MMOsettings.locOwner == "owner"))
            {
                TNManager.SetChannelData("MTinviteHOST" + MMOsettings.mmoGroupID[MMOsettings.mmoGroupCurrentSlot], 0);// 0
              //  MMOsettings.locOwner = "owner111111111";


                MMOinformer.IMbtnsFormTXT.SetActive(false);
                MMOinformer.infoMSGtext.GetComponent<Text>().text = "Ждем гостей";

                MThosterNUM = MMOsettings.mmoGroupCurrentSlot;
                MTinGuest = 1;
                //именуем комнату 
                MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
                MMOplayerlist.uniqueLOC = 0;
                MMOshowplayers.yourLoc = "earth/city/guestSEXroom";
                MMOplayerlist.clearYou = true;
                

                if (MMOsettings.mmoGender == "female") {
                    TNManager.SetChannelData("MTinviteHairs" + MMOsettings.mmoGroupID[MMOsettings.mmoGroupCurrentSlot], MMOsettings.mmoHairColor);
                    TNManager.SetChannelData("MTinviteBody" + MMOsettings.mmoGroupID[MMOsettings.mmoGroupCurrentSlot], MMOsettings.dressDesign);
                }

                MeetingsROOM.MTEarthRoom();
            }
        }

    }


    //отправляем приглос в гости - parnerNUM из актион
    public static void sendInvite()
    {

        //отправляем приглашение по айди      
        TNManager.SetChannelData("MTinviteADD" + MMOsettings.mmoGroupID[MTpartnerNUM], 1);// INVITE ADD
        TNManager.SetChannelData("MTinviteID" + MMOsettings.mmoGroupID[MTpartnerNUM], MMOsettings.mmoGroupCurrentSlot);// путь к нашим данным
    }


    //принимаем приглашение
    public static void acceptInvite()
    {
        MMOinformer.IMbtnsFormTXT.SetActive(false);
        MMOinformer.infoMSGtext.GetComponent<Text>().text = "Идём в гости";

        MTpartnerNUM = TNManager.GetChannelData<int>("MTinviteID" + MMOsettings.mmoGroupID[MMOsettings.mmoGroupCurrentSlot]);

        MTinGuest = 1;
        MThosterNUM = MTpartnerNUM;
        //именуем комнату 
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
        MMOplayerlist.uniqueLOC = 0;
        MMOshowplayers.yourLoc = "earth/city/guestSEXroom";
        MMOplayerlist.clearYou = true;
        //мы гость
        MMOsettings.locOwner = "guest";
       

        //отправить ДА отправителю
        TNManager.SetChannelData("MTinviteHOST" + MMOsettings.mmoGroupID[MTpartnerNUM], 1);// 0
        if (MMOsettings.mmoGender == "female") {
            TNManager.SetChannelData("MTinviteHairs" + MMOsettings.mmoGroupID[MTpartnerNUM], MMOsettings.mmoHairColor);
            TNManager.SetChannelData("MTinviteBody" + MMOsettings.mmoGroupID[MTpartnerNUM], MMOsettings.dressDesign);
        }

        MeetingsROOM.MTEarthRoom();

        print("отправили приглашение игроку номер " + MTpartnerNUM); 
    }

    //отклоняем приглашение
    public static void cancelInvite()
    {
        MMOinformer.IMbtnsFormTXT.SetActive(false);//отклонить
        //отправить нет отправителю
    }


    //РАЗДЕТЬСЯ
    public static void clothOFF()
    {
        //команда действия
        TNManager.SetChannelData("SXROOMactions" + MMOsettings.mmoGroupID[MThosterNUM], "SXROOMundress");
        print("начали выполнение");
    }


    //тискать
    public static void cuddle()
    {
        //команда действия
        TNManager.SetChannelData("SXROOMactions" + MMOsettings.mmoGroupID[MThosterNUM], "SXROOMcuddle");
        print("начали выполнение");
    }

    //залезть в трусики
    public static void pantstouch()
    {
        //команда действия
        TNManager.SetChannelData("SXROOMactions" + MMOsettings.mmoGroupID[MThosterNUM], "SXROOMpantstouch");
        print("начали выполнение");
    }

    //завалить
    public static void forcedstart()
    {
        //команда действия
        TNManager.SetChannelData("SXROOMactions" + MMOsettings.mmoGroupID[MThosterNUM], "SXROOMforcedstart");
        print("начали выполнение");
    }

    //показать грудь
    public static void showboobs()
    {
        //команда действия
        TNManager.SetChannelData("SXROOMactions" + MMOsettings.mmoGroupID[MThosterNUM], "SXROOMshowboobs");
        print("начали выполнение");
    }

    //показать труселя
    public static void showpants()
    {
        //команда действия
        TNManager.SetChannelData("SXROOMactions" + MMOsettings.mmoGroupID[MThosterNUM], "SXROOMshowpants");
        print("начали выполнение");
    }

    //предложить себя
    public static void givebody()
    {
        //команда действия
        TNManager.SetChannelData("SXROOMactions" + MMOsettings.mmoGroupID[MThosterNUM], "SXROOMgivebody");
        print("начали выполнение");
    }

}
