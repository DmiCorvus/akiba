using UnityEngine;
using System.Collections;
using TNet;
using UnityEngine.UI;



public class DataCube : TNBehaviour {
    public static bool destroyINFO;

    public  int clearID;
    public  int testID;
    public string clearLoc;
    public  int clearSlot;

    public bool[] placeONserver; //наше место на сервере
    public int serverNUM; //номер

    void OnEnable()
    {
        destroyINFO = false;
    }

    void Update()
    {
        if (tno.isMine)
        {
            clearLoc = MMOshowplayers.yourLoc;
            clearSlot= MMOshowplayers.yourSlot;
        }       


        if ((destroyINFO == true) && (tno.isMine))
        {
            DestroySelf();
        }


    }

    void Start()
    {
        if (tno.isMine)
        {
            //ваш ID
            MMOsettings.uniqueIDget = TNManager.playerID;
            clearID = MMOsettings.uniqueIDget;
            print("ВАШ ID" + MMOsettings.uniqueIDget);
            //отправляем данные вашего персонажа на сервер
            TNManager.SetChannelData("yourNewPlayer" + MMOsettings.uniqueIDget, 1);//1 - соединение установлено

            TNManager.SetChannelData("yourServerName" + MMOsettings.uniqueIDget, MMOsettings.mmoName);//отправили имя

            TNManager.SetChannelData("yourServerGender" + MMOsettings.uniqueIDget, MMOsettings.mmoGender);//отправили пол
            TNManager.SetChannelData("yourServerHairColor" + MMOsettings.uniqueIDget, MMOsettings.mmoHairColor);//отправили цвет волос
            TNManager.SetChannelData("yourServerPICnum" + MMOsettings.uniqueIDget, MMOsettings.mmoHeroPICnum);//отправили Номер внешности

            TNManager.SetChannelData("yourServerGroup" + MMOsettings.uniqueIDget, 0);//0- вы не в группе
            TNManager.SetChannelData("yourServerGroupSize" + MMOsettings.uniqueIDget, 1);//Размер вашей группы
            TNManager.SetChannelData("groupSettings" + MMOsettings.uniqueIDget, "FALSE");//Установки группы
            TNManager.SetChannelData("yourServerGroupADDED" + MMOsettings.uniqueIDget, 0);//0 -нет входящих запросов на пати

            //параметры свиданий
            TNManager.SetChannelData("MTinviteADD" + MMOsettings.uniqueIDget, 0);    // INVITE ADD
            TNManager.SetChannelData("SXROOMactions" + MMOsettings.uniqueIDget, "");

            int tmpPlayers;
            tmpPlayers = TNManager.GetChannelData<int>("playersOnServer") + 1;
            TNManager.SetChannelData("playersOnServer", tmpPlayers);

            tno.Send("SetIDserver", Target.AllSaved, (testID + 1));

            destroyINFO = false;

           // MMOshowplayers.yourLoc = MMOshowplayers.yourLoc + MMOsettings.uniqueIDget;
            MMOshowplayers.playercreated = true;
            MMOplayerlist.clearYou = true;//обновляем слоты


            //команда передачи айди

        }

    }

    [RFC] void SetIDserver(int val)
    {

        {
            uint tempid;
            tempid = tno.uid; //путь на сервере
            testID = (int)tempid;
            //запись ид игрока
            if (tno.isMine)
            {
                TNManager.SetChannelData("DestroyPath"+ testID, MMOsettings.uniqueIDget);
            }
        }  

    }

    void OnDestroy () {

        //очистка данных    
        MMOplayerlist.savedPlayersHERE -= 1;

        if (TNManager.isHosting)
        {
            //спрашиваем ID
            int destroyID = TNManager.GetChannelData<int>("DestroyPath"+ testID);  

            //проверяем очищен ли этот ID
            int chkdestroy = TNManager.GetChannelData<int>("yourNewPlayer" + destroyID);

            //минусуем игрока
            if (chkdestroy == 1)
            {                
                int tmpPlayers = TNManager.GetChannelData<int>("playersOnServer") - 1;
                TNManager.SetChannelData("playersOnServer", tmpPlayers);
            }

            //очищаем ID
            TNManager.SetChannelData("yourNewPlayer" + destroyID, 0);
            print("clearing" + destroyID);
        }  
    }



}

