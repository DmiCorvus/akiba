using UnityEngine;
using System.Collections;
using TNet;
using UnityEngine.UI;
//ПРИКРЕПЛЕН: к инфо мсг
//ОПИСАНИЕ:

public class MMOteamFIND : MonoBehaviour {

    public GameObject infoMSGteamADDED;
    public Text infoMSGteamADDEDfromPlayer;

   // public GameObject infoMSG;
    public Text infoMSGtext;


    public static GameObject nonTEAM; 
    public static GameObject inTEAM;

    public static bool settingsComplete = false;


    //стартовая очистка
    void OnEnable()
    {
       // infoMSGteamADDED.SetActive(false);
        infoMSGtext.GetComponent<Text>().text = "";

    }

    public static void searhTeamBTNs()
    {
        if (settingsComplete == false)
        {
            nonTEAM = GameObject.Find("nonGruppText");
            inTEAM = GameObject.Find("inGruppText");
            settingsComplete = true;
        }




        nonTEAM.SetActive(true);
        inTEAM.SetActive(false);
    }


    //выход из группы
    public void ExitGroup()
    {
        nonTEAM.SetActive(true);
        inTEAM.SetActive(false);
        MMOsettings.mmoGroup = 0;
        //отправляем что мы не в группе
        TNManager.SetChannelData("yourServerGroup" + MMOsettings.uniqueIDget, 0);//нас

        //выход владельца группы
        if(MMOsettings.mmoGroupLeader == "owner")
        {
            TNManager.SetChannelData("groupSettings" + MMOsettings.uniqueIDget, "");//Лидер сбросил настройки группы
            //команда роспуска группы
        }
        //выход гостя
        else  if (MMOsettings.mmoGroupLeader == "guest")
        {
            MMOsettings.mmoGroupLeader = "owner";
            //команда покидания участника
        }
    }

    //ОТМЕНА ВСТУПЛЕНИЯ
    public static void CancelGroup()
    {
      MMOinformer.IMbtnsFormTXT.SetActive(false);
        print("working...closing...");
    }

    //ВСТУПАЕМ В ГРУППУ
    public static void EnterGroup()
    {
        MMOinformer.IMbtnsFormTXT.SetActive(false);
        //если мы уже в группе ДОРАБОТАТЬ!!!!

        //ID владельца пати
        MMOsettings.mmoDataPathAcceptTeam = TNManager.GetChannelData<int>("yourServerGroupADDED_ID"+ MMOsettings.uniqueIDget);


        //спрашиваем онлайн ли игрок?
        int chkOnline;
        chkOnline = TNManager.GetChannelData<int>("yourNewPlayer" + MMOsettings.mmoDataPathAcceptTeam);
        //спрашиваем как много у него человек в группе
        int chkSize;
        chkSize = TNManager.GetChannelData<int>("yourServerGroupSize" + MMOsettings.mmoDataPathAcceptTeam);

        //если оффлайн или нет места
        if ((chkOnline == 0)|(chkSize >=4))
            {
            // infoMSGteamADDED.SetActive(false);
            //пишем текст
            MMOinformer.infoMSGtext.GetComponent<Text>().text = "Приглашение устарело";
            }

        //если онлайн и есть место
            if ((chkOnline == 1) && (chkSize < 4))
        {
                //пишем на сервер
                TNManager.SetChannelData("yourServerGroup" + MMOsettings.uniqueIDget, 1);//нас
                TNManager.SetChannelData("yourServerGroup" + MMOsettings.mmoDataPathAcceptTeam, 1);//отправителя  

                nonTEAM.SetActive(false);
                inTEAM.SetActive(true);

                MMOinformer.infoMSGtext.GetComponent<Text>().text = "Вы вступили в группу";
                MMOsettings.mmoGroup = 1;
                print("вступили в группу" + "А=" + MMOsettings.uniqueIDget + "B=" + MMOsettings.mmoDataPathAcceptTeam);


                //посылаем отправителю уведомление
                TNManager.SetChannelData("yourServerGroupENTERED" + MMOsettings.mmoDataPathAcceptTeam, 1);

                MMOsettings.mmoGroupLeader = "guest";   //мы теперь гость группы

                //спрашиваем установленны ли параметры группы?
                string chkGroupSettigs;
                chkGroupSettigs = TNManager.GetChannelData<string>("groupSettings" + MMOsettings.mmoDataPathAcceptTeam);


                //если их нет то формируем ИХ
                if (chkGroupSettigs != "DONE")
                {
                //локальные переменные
                MMOsettings.mmoGroupCurrentSlot = 2;//ваш номер в группе
                MMOsettings.mmoGroupID[1] = MMOsettings.mmoDataPathAcceptTeam; //ID лидера группы
                MMOsettings.mmoGroupID[2] = MMOsettings.uniqueIDget; //ID ваш

                MMOsettings.mmoGroupNames[1] = TNManager.GetChannelData<string>("yourServerName" + MMOsettings.mmoGroupID[1]);//имена
                MMOsettings.mmoGroupNames[2] = MMOsettings.mmoName;

                MMOsettings.mmoGroupGender[1] = TNManager.GetChannelData<string>("yourServerGender" + MMOsettings.mmoGroupID[1]);//пол
                MMOsettings.mmoGroupGender[2] = MMOsettings.mmoGender;

                MMOsettings.mmoGroupSlot[1] = "USED";//статусы слотов
                MMOsettings.mmoGroupSlot[2] = "USED";
                MMOsettings.mmoGroupSlot[3] = "FREE";
                MMOsettings.mmoGroupSlot[4] = "FREE";
                //серверные переменные
                TNManager.SetChannelData("groupSettings" + MMOsettings.mmoDataPathAcceptTeam, "DONE");//Лидер настроил группу

                TNManager.SetChannelData("groupSettingsSlotID1" + MMOsettings.mmoGroupID[1], MMOsettings.mmoGroupID[1]);//ID лидера
                TNManager.SetChannelData("groupSettingsSlotID2" + MMOsettings.mmoGroupID[1], MMOsettings.mmoGroupID[2]);//ID ваш собственный

                TNManager.SetChannelData("groupSettingsSlot1" + MMOsettings.mmoGroupID[1], "USED");//отправляем слоты на сервер
                TNManager.SetChannelData("groupSettingsSlot2" + MMOsettings.mmoGroupID[1], "USED");
                TNManager.SetChannelData("groupSettingsSlot3" + MMOsettings.mmoGroupID[1], "FREE");
                TNManager.SetChannelData("groupSettingsSlot4" + MMOsettings.mmoGroupID[1], "FREE");

                TNManager.SetChannelData("groupSettingsName1" + MMOsettings.mmoGroupID[1], MMOsettings.mmoGroupNames[1]); //отправляем имя Лидера
                TNManager.SetChannelData("groupSettingsGender1" + MMOsettings.mmoGroupID[1], MMOsettings.mmoGroupGender[1]); //отправляем  пол Лидера

                TNManager.SetChannelData("groupSettingsName2"  + MMOsettings.mmoGroupID[1], MMOsettings.mmoName); //отправляем наше имя
                TNManager.SetChannelData("groupSettingsGender2" + MMOsettings.mmoGroupID[1], MMOsettings.mmoGender); //отправляем наш пол

                //отправляем команду на +1 группы  
                TNManager.SetChannelData("yourServerGroupSize" + MMOsettings.mmoGroupID[1], 2);
            }




                //ЕСЛИ ПАРАМЕТРЫ УЖЕ БЫЛИ СФОРМИРОВАНЫ
                else if (chkGroupSettigs == "DONE")
            {
                MMOsettings.mmoGroupID[1] = MMOsettings.mmoDataPathAcceptTeam; //ID лидера группы
                //поиск места в группе
                for (int i = 1; i <= 5; i++)
                {
                    //проверяем слот
                    MMOsettings.mmoGroupSlot[i] = TNManager.GetChannelData<string>("groupSettingsSlotID" + i + MMOsettings.mmoGroupID[1]);
                    //занимаем слот
                    if (MMOsettings.mmoGroupSlot[i]== "FREE")
                    {
                        MMOsettings.mmoGroupCurrentSlot = i; //наш номер в группе
                                                             //отправляем наши данные
                        TNManager.SetChannelData("groupSettingsSlotID"+i + MMOsettings.mmoGroupID[1], MMOsettings.uniqueIDget);//наш ID
                        TNManager.SetChannelData("groupSettingsSlot"+i + MMOsettings.mmoGroupID[1], "USED");//отправляем слот
                        TNManager.SetChannelData("groupSettingsName"+i + MMOsettings.mmoGroupID[1], MMOsettings.mmoName); //отправляем наше имя
                        TNManager.SetChannelData("groupSettingsGender" + i + MMOsettings.mmoGroupID[1], MMOsettings.mmoGender); //отправляем наш пол

                        //вписываем все параметры
                        //ID игроков
                        MMOsettings.mmoGroupID[1] = TNManager.GetChannelData<int>("groupSettingsSlotID1" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupID[2] = TNManager.GetChannelData<int>("groupSettingsSlotID2" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupID[3] = TNManager.GetChannelData<int>("groupSettingsSlotID3" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupID[4] = TNManager.GetChannelData<int>("groupSettingsSlotID4" + MMOsettings.mmoGroupID[1]);
                        //слоты
                        MMOsettings.mmoGroupSlot[1] = TNManager.GetChannelData<string>("groupSettingsSlot1" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupSlot[2] = TNManager.GetChannelData<string>("groupSettingsSlot2" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupSlot[3] = TNManager.GetChannelData<string>("groupSettingsSlot3" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupSlot[4] = TNManager.GetChannelData<string>("groupSettingsSlot4" + MMOsettings.mmoGroupID[1]);
                        //имена
                        MMOsettings.mmoGroupNames[1] = TNManager.GetChannelData<string>("groupSettingsName1" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupNames[2] = TNManager.GetChannelData<string>("groupSettingsName2" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupNames[3] = TNManager.GetChannelData<string>("groupSettingsName3" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupNames[4] = TNManager.GetChannelData<string>("groupSettingsName4" + MMOsettings.mmoGroupID[1]);
                        //пол
                        MMOsettings.mmoGroupGender[1] = TNManager.GetChannelData<string>("groupSettingsGender1" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupGender[2] = TNManager.GetChannelData<string>("groupSettingsGender2" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupGender[3] = TNManager.GetChannelData<string>("groupSettingsGender3" + MMOsettings.mmoGroupID[1]);
                        MMOsettings.mmoGroupGender[4] = TNManager.GetChannelData<string>("groupSettingsGender4" + MMOsettings.mmoGroupID[1]);
                        i = 5; //СТОП
                               //отправляем +1
                        int groupSIZE;
                        groupSIZE = TNManager.GetChannelData<int>("yourServerGroupSize" + MMOsettings.mmoGroupID[1]) + 1;
                        TNManager.SetChannelData("yourServerGroupSize" + MMOsettings.mmoGroupID[1], groupSIZE);
                    }
                }

            }


            }


        

    }

    //ОТЛАВЛИВАЕМ ГРУППУ
    void Update () {

        //проверяем инфо о группах
        int groupCHK;
        groupCHK = TNManager.GetChannelData<int>("yourServerGroupADDED" + MMOsettings.uniqueIDget);

        //если запрос поступил 
        if (groupCHK == 1)
        {
            //обнуляем
            infoMSGtext.GetComponent<Text>().text = "";
            TNManager.SetChannelData("yourServerGroupADDED" + MMOsettings.uniqueIDget, 0);//0 -нет входящих запросов на пати
            //рисуем            
            infoMSGteamADDED.SetActive(true);       
            //вписываем текст
            string tempTXT;
            tempTXT = TNManager.GetChannelData<string>("yourServerGroupADDEDtext" + MMOsettings.uniqueIDget);
            infoMSGteamADDEDfromPlayer.GetComponent<Text>().text = tempTXT;
            //спрашиваем ID
            MMOsettings.mmoDataPathAcceptTeam = TNManager.GetChannelData<int>("yourServerGroupADDED_ID"+ MMOsettings.uniqueIDget);

            //формируем параметры кнопок
            MMOinformer.IMtypeBTNaccept = "acceptGroup";
            MMOinformer.IMtypeBTNcancel = "cancelGroup";
        }

        //проверям если игрок вступил по отправленному приглашению
        int groupSendingCHK;
        groupSendingCHK = TNManager.GetChannelData<int>("yourServerGroupENTERED" + MMOsettings.uniqueIDget);
        //если игрок вступил
        if (groupSendingCHK == 1)
        {
            TNManager.SetChannelData("yourServerGroupENTERED" + MMOsettings.uniqueIDget, 0);
            //пишем что мы в группе
            nonTEAM.SetActive(false);
            inTEAM.SetActive(true);

            infoMSGtext.GetComponent<Text>().text = "Игрок принял ваше приглашение";
            MMOsettings.mmoGroup = 1;
            //вписываем все параметры
            //ID игроков
            MMOsettings.mmoGroupID[1] = TNManager.GetChannelData<int>("groupSettingsSlotID1" + MMOsettings.uniqueIDget);
            MMOsettings.mmoGroupID[2] = TNManager.GetChannelData<int>("groupSettingsSlotID2" + MMOsettings.uniqueIDget);
            MMOsettings.mmoGroupID[3] = TNManager.GetChannelData<int>("groupSettingsSlotID3" + MMOsettings.uniqueIDget);
            MMOsettings.mmoGroupID[4] = TNManager.GetChannelData<int>("groupSettingsSlotID4" + MMOsettings.uniqueIDget);
            //слоты
            MMOsettings.mmoGroupSlot[1] = TNManager.GetChannelData<string>("groupSettingsSlot1" + MMOsettings.uniqueIDget);
            MMOsettings.mmoGroupSlot[2] = TNManager.GetChannelData<string>("groupSettingsSlot2" + MMOsettings.uniqueIDget);
            MMOsettings.mmoGroupSlot[3] = TNManager.GetChannelData<string>("groupSettingsSlot3" + MMOsettings.uniqueIDget);
            MMOsettings.mmoGroupSlot[4] = TNManager.GetChannelData<string>("groupSettingsSlot4" + MMOsettings.uniqueIDget);
            //имена
            MMOsettings.mmoGroupNames[1] = TNManager.GetChannelData<string>("groupSettingsName1" + MMOsettings.mmoGroupID[1]);
            MMOsettings.mmoGroupNames[2] = TNManager.GetChannelData<string>("groupSettingsName2" + MMOsettings.mmoGroupID[1]);
            MMOsettings.mmoGroupNames[3] = TNManager.GetChannelData<string>("groupSettingsName3" + MMOsettings.mmoGroupID[1]);
            MMOsettings.mmoGroupNames[4] = TNManager.GetChannelData<string>("groupSettingsName4" + MMOsettings.mmoGroupID[1]);
            //пол
            MMOsettings.mmoGroupGender[1] = TNManager.GetChannelData<string>("groupSettingsGender1" + MMOsettings.mmoGroupID[1]);
            MMOsettings.mmoGroupGender[2] = TNManager.GetChannelData<string>("groupSettingsGender2" + MMOsettings.mmoGroupID[1]);
            MMOsettings.mmoGroupGender[3] = TNManager.GetChannelData<string>("groupSettingsGender3" + MMOsettings.mmoGroupID[1]);
            MMOsettings.mmoGroupGender[4] = TNManager.GetChannelData<string>("groupSettingsGender4" + MMOsettings.mmoGroupID[1]);

        }

        //КОМАНДА ОБНОВЛЕНИЯ ПАРАМЕТРОВ ГРУППЫ
        if (MMOsettings.mmoGroup == 1)
        {
            if (MMOsettings.mmoGroupCurrentSlot == 1) { MMOsettings.mmoGroupID[1] = MMOsettings.uniqueIDget; }//если мы первый игрок то задаем переменную         

            //проверяем размер группы
            int groupSIZE;
            groupSIZE = TNManager.GetChannelData<int>("yourServerGroupSize" + MMOsettings.mmoGroupID[1]);

            if (groupSIZE != MMOsettings.mmoGroupCurrentSize)
            {
                MMOsettings.mmoGroupCurrentSize = groupSIZE;
                print("ОБНОВЛЕНЫ ПАРАМЕТРЫ ГРУППЫ");
                //вписываем все параметры
                //ID игроков
                MMOsettings.mmoGroupID[1] = TNManager.GetChannelData<int>("groupSettingsSlotID1" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupID[2] = TNManager.GetChannelData<int>("groupSettingsSlotID2" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupID[3] = TNManager.GetChannelData<int>("groupSettingsSlotID3" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupID[4] = TNManager.GetChannelData<int>("groupSettingsSlotID4" + MMOsettings.mmoGroupID[1]);
                //слоты
                MMOsettings.mmoGroupSlot[1] = TNManager.GetChannelData<string>("groupSettingsSlot1" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupSlot[2] = TNManager.GetChannelData<string>("groupSettingsSlot2" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupSlot[3] = TNManager.GetChannelData<string>("groupSettingsSlot3" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupSlot[4] = TNManager.GetChannelData<string>("groupSettingsSlot4" + MMOsettings.mmoGroupID[1]);
                //имена
                MMOsettings.mmoGroupNames[1] = TNManager.GetChannelData<string>("groupSettingsName1" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupNames[2] = TNManager.GetChannelData<string>("groupSettingsName2" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupNames[3] = TNManager.GetChannelData<string>("groupSettingsName3" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupNames[4] = TNManager.GetChannelData<string>("groupSettingsName4" + MMOsettings.mmoGroupID[1]);
                //пол
                MMOsettings.mmoGroupGender[1] = TNManager.GetChannelData<string>("groupSettingsGender1" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupGender[2] = TNManager.GetChannelData<string>("groupSettingsGender2" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupGender[3] = TNManager.GetChannelData<string>("groupSettingsGender3" + MMOsettings.mmoGroupID[1]);
                MMOsettings.mmoGroupGender[4] = TNManager.GetChannelData<string>("groupSettingsGender4" + MMOsettings.mmoGroupID[1]);
            }                   

        }


    }
}
