using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TNet;

public class MMOstart : TNBehaviour {



    public GameObject mmoPanel;//ОСНОВНАЯ ПАНЕЛЬ
    public GameObject lobbyPanel;//ЛОББИ
    public GameObject startScreen;//СТАРТОВЫЙ ЭКРАН    

    public GameObject mmoChatPanel;//+ЧАТ
    public GameObject mmoInfoMSGfield;//+ИНФО ПОЛЕ
    public GameObject mmoShowPlayersPanel; //+ЛЕВАЯ ПАНЕЛЬ
    public GameObject mmoInfoPanel; //+ПРАВАЯ ПАНЕЛЬ - ОБЩАЯ
    public GameObject mmoGroupPanel;//панель группы   

    public GameObject mmoExitGameBTN; //ВЫХОД ИЗ ИГРЫ
    public GameObject mmoExitMenuBTN; //ВЫХОД В ГЛАВНОЕ МЕНЮ
    public GameObject mmoExitMenuPanel; //ВЫХОД В ГЛАВНОЕ МЕНЮ


    //Интерфейс
    public GameObject UIinterface;

    //ЗАПИСЬ ДАННЫХ    
    int datacube;

    //ОБЪЕКТЫ СЦЕНЫ
    public static int sceneBTNset = 0;
    public static GameObject[] actionBTS = new GameObject[5];//кнопки действий
    public static GameObject[] actionBTStxt = new GameObject[5];         //текст кнопок действий 
    public static Button[] actionBTNcommand = new Button[5];//задание действия кнопок



    public static GameObject[] placesBTS = new GameObject[6];//кнопки перемещений
    public static GameObject[] placesBTStxt = new GameObject[6];         //текст кнопок  перемещений
    public static string[] placesBTScommand = new string[6]; 
    public static Button[] placesBTNcommand = new Button[6];//задание действия кнопок



    public static GameObject[] npsBTS = new GameObject[6];//кнопки нпс
    public static GameObject[] npsBTStxt = new GameObject[6];         //текст кнопок  нпс
    public static string[] npsBTScommand = new string[6]; 
    public static Button[] npsBTNcommand = new Button[6];//задание действия кнопок



    public static GameObject SceneImageSlot; //Место где хранится картинка
    public static Image SceneIMG;
    public static GameObject heroInScene; //место где хранится картинка одежды
    public static Image heroInSceneIMG;

    public static GameObject locNameTEXT; //Название локации
    public static GameObject contentTEXT1; //Основной текст
    public static GameObject contentTEXT2; //Описываем действия участников группы.



    //ЛОКАЛИЗАЦИЯ ЛОКАЦИЙ
    public static string lang_locname;
    public static string lang_locTEXT1;
    public static string[] lang_actions = new string[5];
    public static string[] lang_nps = new string[6];
    public static string[] lang_places = new string[6];



    //SAVING LOC DATA


    /// <summary>
    /// Раздел действий
    /// </summary>

    //ПАНЕЛЬ ВЫХОДА В МЕНЮ
    public void ExitPanelON()
    {
        mmoExitMenuPanel.SetActive(true);

    }
    public void ExitPanelOFF()
    {
        mmoExitMenuPanel.SetActive(false);

    }

    //выход в меню
    public void ExitMENU()
    {
        for (int i = 0; i <= 49; i++) { MMOplayerlist.playersSlot[i] = false; }
        MMOplayerlist.playersALLdestroyPIC = true;//все кнопки уничтожить

        mmoPanel.SetActive(false);
        mmoExitMenuPanel.SetActive(false);

        //выключаем интерфейс
        mmoChatPanel.SetActive(false);
        mmoInfoMSGfield.SetActive(false);
        UIactive.UIpanActive = false;

        MMOplayerlist.destroyIT();

        mmoInfoPanel.SetActive(false);
        //добавляем кнопку выхода
        mmoExitGameBTN.SetActive(true);
        mmoExitMenuBTN.SetActive(false);
        //музыка
        UIactive.AudioLobby.SetActive(true);

        //включаем лобби
        lobbyPanel.SetActive(true);
        startScreen.SetActive(true);
        UIactive.downPan.SetActive(true);
        UIactive.lobbyIMAGE.SetActive(true);

        //отключаемся
        DataCube.destroyINFO = true;
        //TNManager.Disconnect();
    

        //СБРОС ПАРАМЕТРОВ ГРУППЫ:
        MMOsettings.mmoGroup = 0; //0 без группы 
        MMOsettings.mmoGroupLeader = "owner"; //guest определяем лидера группы
        MMOsettings.mmoGroupCurrentSlot = 1; //Ваш слот в текущей группе
        MMOsettings.mmoGroupMaxSize = 4; //размер макс группы
        MMOsettings.mmoGroupCurrentSize = 1; //размер текущей группы

        MMOsettings.guest = false; //мы в гостях
        for (int i = 0; i <= 4; i++)
        {
            MMOsettings.mmoGroupSlot[i] = "free"; //все слоты свободны
        }

        //очищаем ваш слот
        if (MMOsettings.singleGame == false)
        {
            TNManager.SetChannelData(MMOshowplayers.yourSlot + "StatusSlot" + MMOshowplayers.yourLoc, ""); //ПИШЕМ ЧТО СЛОТ ОФФНУТ
           // TNManager.Disconnect();
        }  

    }




    //СТАРТОВЫЕ ПАРАМЕТРЫ
    void OnEnable () {

        //загрузка
        LoadMainDATA();

        UIactive.UIpanActive = true;
        UIinterface.SetActive(true);


        mmoInfoPanel.SetActive(true);
        //отключаем музыку
        UIactive.AudioLobby.SetActive(false);
        //кнопки выхода
        mmoExitGameBTN.SetActive(false);
        mmoExitMenuBTN.SetActive(true);
        //формирование стартовой сцены
        MMOsettings.mmoSecondName = "Сестрёнка";
        MMOshowplayers.yourPRELoc = "house_loc";
        MMOshowplayers.yourLoc = "house_loc";
        MMOplayerlist.uniqueLOC = 1;


        //МУЛЬТИПЛЕЕР
        if (MMOsettings.singleGame == false)
        {
            TNManager.onDisconnect += OnDisconnect; //соединение утеряно
                                                    //выключаем интерфейс

            mmoChatPanel.SetActive(true);
            mmoInfoMSGfield.SetActive(true);
            mmoShowPlayersPanel.SetActive(true);            
            mmoGroupPanel.SetActive(true);

            DataCube.destroyINFO = false;

            print("MULTIPLAYER STARTING");
            MMOteamFIND.searhTeamBTNs();
            allBTNsSet();
            //финальные параметры
            datacube = 1;

            datacubecreating();
        }
        //СИНГЛ
        if (MMOsettings.singleGame == true)
        {

            mmoChatPanel.SetActive(false);
            mmoInfoMSGfield.SetActive(false);
            mmoShowPlayersPanel.SetActive(false);
            mmoGroupPanel.SetActive(false);

            TNServerInstance.Stop();//офф
            TNManager.Disconnect();

            allBTNsSet();
        }


    }

    //BTNS SET
    void allBTNsSet()
    {
        if(sceneBTNset == 0)
        {

            int checkerBTNS = 0;
            //назначаем кнопки действия
            for (int i = 0; i <= 4; i++)
            {
                actionBTS[i] = GameObject.Find("actionsBTN" + i);
                actionBTStxt[i] = GameObject.Find("actionText" + i);
                actionBTNcommand[i] = actionBTS[i].GetComponent<Button>();//задаем кнопку
                checkerBTNS++;
            }
            //назначаем кнопки переходов
            for (int i = 0; i <= 5; i++)
            {
                placesBTS[i] = GameObject.Find("placeBTN" + i);
                placesBTStxt[i] = GameObject.Find("placeText" + i);
                placesBTNcommand[i] = placesBTS[i].GetComponent<Button>();//задаем кнопку
                checkerBTNS++;
            }
            //назначаем нпс
            for (int i = 0; i <= 5; i++)
            {
                npsBTS[i] = GameObject.Find("npcBTN" + i);
                npsBTStxt[i] = GameObject.Find("npsText" + i);
                npsBTNcommand[i] = npsBTS[i].GetComponent<Button>();//задаем кнопку
                checkerBTNS++;

            }
            //прочее
            SceneImageSlot = GameObject.Find("imageFieldScene");            
            SceneIMG = SceneImageSlot.GetComponent<Image>();

            heroInScene = GameObject.Find("heroInScene");
            heroInSceneIMG = heroInScene.GetComponent<Image>();

            locNameTEXT = GameObject.Find("locName");
            contentTEXT1 = GameObject.Find("contentText1");
            contentTEXT2 = GameObject.Find("contentText2");


            //запускаем сцену
            if (checkerBTNS >= 14)   { startingProgress();      }

        }

        if (sceneBTNset == 1)  { startingProgress();  }

    }

    //START
    void startingProgress()
    {        
        Room_LOC.YourRoom();
    }

    //DATA CUBE (SAVE_LOAD DATA ON SERVER)
    void datacubecreating()
    {

        if (datacube == 1)
        {
            //создаем куб
            Vector3 pos = TouchHandler.worldPos + Vector3.up * 3f;
            Quaternion rot = Quaternion.Euler(Random.value * 180f, Random.value * 180f, Random.value * 180f);
            TNManager.Instantiate("DataWrite", "DataCube", false, pos, rot);
            datacube = 0;

        }
    }




    [RCC]
    static GameObject DataWrite(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        // Instantiate the prefab
        GameObject go = prefab.Instantiate();

        // Set the position and rotation based on the passed values
        Transform t = go.transform;
        t.position = pos;
        t.rotation = rot;

        return go;
    }


    //ОТКЛЮЧАЕМ КНОПКИ ПРИ ПЕРЕХОДАХ
    public static void ClearingBTNS()
    {
        heroInScene.SetActive(false);
        //очистка действий
        for (int i = 0; i <= 4; i++) {
            actionBTNcommand[i].onClick.RemoveAllListeners();
            actionBTS[i].SetActive(false);            
        }

        //очистка локаций
        for (int i = 0; i <= 5; i++)  {
            placesBTNcommand[i].onClick.RemoveAllListeners();
            placesBTS[i].SetActive(false);
        }

        //очистка нпс
        for (int i = 0; i <= 5; i++)  {
            npsBTNcommand[i].onClick.RemoveAllListeners();
            npsBTS[i].SetActive(false);
        }
    }




    void OnDisable()
    {
        TNManager.onDisconnect -= OnDisconnect; //соединение утеряно 
    }
        //отключение
    void OnDisconnect() { print("CONNECTION LOSE"); }

   
    
    //загрузка базовых данных
    void LoadMainDATA()
    {
        //персонаж
        MMOsettings.mmoName = SaveHero.saveNameHero[SaveHero.selectedSlot];
        MMOsettings.mmoGender = SaveHero.saveGenderHero[SaveHero.selectedSlot];
        MMOsettings.mmoHairColor = SaveHero.saveHairColHero[SaveHero.selectedSlot];
        MMOsettings.mmoHeroPICnum = SaveHero.saveAVIpicHero[SaveHero.selectedSlot];
        //семья
        Family.sister = SaveHero.saveSister[SaveHero.selectedSlot];
        Family.sisPersonality = SaveHero.savesisPersona[SaveHero.selectedSlot];
        Family.brother = SaveHero.saveBrother[SaveHero.selectedSlot];
        Family.broPersonality = SaveHero.savebroPersona[SaveHero.selectedSlot];

    }
}
