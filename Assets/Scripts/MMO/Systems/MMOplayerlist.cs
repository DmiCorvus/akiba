using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TNet;


//ОПИСАНИЕ: код отображения списка онлайн игроков
//ПРИКРЕПЛЕН: к ммо плайерс лист

public class MMOplayerlist : MonoBehaviour {

    //отключить панель
    public static bool playersPANactive; //условие отключения панели
    public GameObject itPanel;  //выбрали эту панель

    public static int savedPlayersHERE; //сохраняем количество игроков 
    public static int uniqueLOC; //ИНДИВИДУАЛЬНАЯ ЛОКАЦИЯ 0 НЕТ 1 ДА
    public static bool refreshSLOT;//условие отрисовки

    public static bool refreshYou;  //ВПИСЫВАЕМ ВАС
    public static bool clearYou;    //ВЫПИСЫВАЕМ ВАС

    public static int playersOnServer; //счетчик игроков 

    
 

    public static int playerNUMslotCounter; //счетчик слотов
    public static bool destroywaiting; //ОЖИДАНИЕ УНИЧТОЖЕНИЯ
    public static int playerStillAlive; //количество живых игроков

    //СОЗДАЕМ УНИКАЛЬНЫЙ СЛОТ
    public static bool playersALLdestroyPIC; //уничтожаем слоты
    public static int playersSLOTtoCreate; //необходимо создать столько слотов
    public static bool playersSLOTtoCreateWorking; //ЗАПУСК ПРОЦЕССА СОЗДАНИЯ СЛОТА
    public static bool playersSLOTtoCreateWorkingWAIT;//ЖДЕМ ПОКА СОЗДАТЬСЯ КНОПКА
    public static bool[] playersSLOTtoCreateWorkingCurrent = new bool [50]; //СОЗДАН ЛИ ТЕКУЩИЙ СЛОТ?
    public static int playersSLOTtoCreateWorkingNUM;//НОМЕР ЭТОГО СЛОТА

    public Transform setBTNhere;
    //ДАННЫЕ 50 уникальных слотов
    public static bool[] playersSlot = new bool[50];//СЛОТЫ - TRUE - УЖЕ НАРИСОВАН - ОБНУЛИТЬ ПРИ СТАРТЕ
    public static int[] playersSlotID = new int[50];//ID 50 игроков
    public static string[] allPlayersNameData = new string[50];//ИМЕНА ИГРОКОВ
    public static string[] allPlayersPICData = new string[50];//КАРТИНКИ ИГРОКОВ






    public static GameObject contentPlayersGrid;

    void OnEnable()
    {
        playersSLOTtoCreate = 0;
        clearYou = false;
        refreshSLOT = false;
        refreshYou = false;

        playersSLOTtoCreateWorking = false;
        playersSLOTtoCreateWorkingCurrent[0] = false;//fix

        savedPlayersHERE = 1;
        playerStillAlive = 0;

        playersPANactive = true;//панель существует

       // MMOshowplayers.playercreated = false;

        destroywaiting = false;
        playerNUMslotCounter = 0;

        contentPlayersGrid = GameObject.Find("PlayersPanelGrid");
    }

    /// <summary>
    /// ВЫХОД ИЗ ЛОКАЦИИ
    /// </summary>
    void OnDisable()
    {



    }



    //ОБНОВЛЯЕМ СПИСОК 
    void Update()
    {

        //КНОПКОСОЗДАТЕЛЬ
        if (playersSLOTtoCreateWorking == true)
        {
            //кнопкосоздатель завершил работу
            if (playersSLOTtoCreate <= 0)
            {
                playersSLOTtoCreateWorking = false;
            }

            //ЗАПУСК
            if ((playersSLOTtoCreateWorkingWAIT == false)&&(playersSLOTtoCreateWorking == true))
            {
                for (int i = 1; i <= 49; i++)
                {
                    //если слот задан но не существует и нет паузы
                    if ((playersSLOTtoCreateWorkingCurrent[i] == false)&& (playersSlot[i] = true)&&(playersSLOTtoCreateWorkingWAIT == false))
                    {                        
                        playersSLOTtoCreateWorkingWAIT = true; //останавливаем процесс создания
                        playersSLOTtoCreateWorkingCurrent[i] = true; //мы создали это
                        playersSLOTtoCreateWorkingNUM = i; //мы присвоили номер этому слоту
                        i = 49; //ЦИКЛ СТОП!
                        print("создали НОМЕР " + playersSLOTtoCreateWorkingNUM);
                        //о великий кнопкосоздатель, создай кнопку!
                        GameObject addedquest = Instantiate(Resources.Load<GameObject>("PlayerINFOButton"));
                        //addedquest.transform.SetParent((contentPlayersGrid.transform));
                        addedquest.transform.SetParent(setBTNhere);

                    }

                }

            }



        }

        //ЕНД



        //УНИЧТОЖАЕМ ЭТУ ПАНЕЛЬ
        if(playersPANactive == false)
        {
            for (int i = 0; i <= 49; i++) { playersSlot[i] = false; } //все кнопки чисты
            playersALLdestroyPIC = true;                                             //все кнопки уничтожить
                                        
            print(playerNUMslotCounter);
            if (playerNUMslotCounter == 0)
            {
                print("ВСЕ КНОПКИ УНИЧТОЖЕНЫ");
                itPanel.SetActive(false);
            }

        }
        //END




        //ОБНОВЛЕНИЕ СПИСКА АКТИВИРУЕТСЯ ПОСЛЕ СОЗДАНИЯ ИГРОКА (Панель активна)
        if ((MMOshowplayers.playercreated == true)&&(playersPANactive != false)&&(playersSLOTtoCreateWorking == false))
        {
            //1.вход в локацию
            if (refreshYou == true)
            {
                print("Подготовка данных к рисовке вашего слота");
                //Уничтожение кнопок
                playersALLdestroyPIC = true;   //все кнопки уничтожить
                for (int i = 0; i <= 49; i++)//все кнопки очистить
                {
                    playersSlot[i] = false;
                    playersSLOTtoCreateWorkingCurrent[i] = false;
                } 
                destroywaiting = true;         //ждем результата
                clearYou = false;              //мы уже очищены = false
                refreshSLOT = false;           //отключить Обновление локации
            }
            //1.END

            //2.процесс уничтожения кнопок 
            if (destroywaiting == true)
            {                
                //-ПОЛНАЯ ОЧИСТКА ЛОКАЦИИ
                if ((refreshYou == true)&&(playerNUMslotCounter==0))
                {      
                    print("ВСЕ КНОПКИ УНИЧТОЖЕНЫ");
                    destroywaiting = false;    //всем выбранным кнопкам хана                    
                    refreshYou = false;        //мы подготовились ко входу
                    refreshSLOT = false;       //отключить Обновление локации
                    EnterInLoc();              // входим в локацию

                }             
                //-ОБНОВЛЕНИЕ ЛОКАЦИИ
                else if (refreshYou == false)
                {
               //     print("ПОПЫТКА ВЫБОРОЧНО УНИЧТОЖИТЬ КНОПКИ"+ playerNUMslotCounter+" "+ playerStillAlive);
                    if (playerNUMslotCounter == 0)  //playerStillAlive
                    {
                        print("ВЫБОРОЧНО УНИЧТОЖИТЬ КНОПКИ");
                                                    //поиск кнопок которые надо отключить
                        destroywaiting = false;     // всем выбранным кнопкам хана                     
                        refreshSLOT = false;        //отключить Обновление локации

                        //ТМП АНДЕБАГЕРР
                        //очищаем наш слот в локации
                        TNManager.SetChannelData(MMOshowplayers.yourSlot + "StatusSlot" + MMOshowplayers.yourLoc, "");

                        //минусуем
                        int chkroom = TNManager.GetChannelData<int>("locCounter" + MMOshowplayers.yourLoc) - 1;
                        TNManager.SetChannelData("locCounter" + MMOshowplayers.yourLoc, chkroom);
                        print("Очистили слот: " + MMOshowplayers.yourSlot + "В локации: " + MMOshowplayers.yourLoc);

                        refreshSLOT = false;       //отключить обновление слота
                        clearYou = false;          //уже стерли
                        refreshYou = true;         //подготовились ко входу  
                        //ТМП АНДЕБАГГЕР ЕНД 

                    }
                }
            }
            //2.END

            //3. стираем наши данные
            if (clearYou == true)
            { 
                //очищаем наш слот в локации
                TNManager.SetChannelData(MMOshowplayers.yourSlot + "StatusSlot" + MMOshowplayers.yourPRELoc, "");

                //минусуем
                int chkroom = TNManager.GetChannelData<int>("locCounter" + MMOshowplayers.yourPRELoc) - 1;
                TNManager.SetChannelData("locCounter" + MMOshowplayers.yourPRELoc, chkroom);
                print("Очистили слот: " + MMOshowplayers.yourSlot + "В локации: " + MMOshowplayers.yourPRELoc);

                refreshSLOT = false;       //отключить обновление слота
                clearYou = false;          //уже стерли
                refreshYou = true;         //подготовились ко входу      
            }






            //4.обновление слотов
            if (refreshSLOT == true)
            {              
                //спрашиваем сколько тут сейчас игроков  
                int chkplayers_inroom = TNManager.GetChannelData<int>("locCounter" + MMOshowplayers.yourLoc);
                //если ЧК плеер неравно СЕЙВПЛЕЕР
                    if (savedPlayersHERE != chkplayers_inroom)
                    {
                        
                        print("количество игроков изменилось");
                         //провести проверку слотов
                        SlotsCHECKING();
                    }
                

            }
            //5.конец системы отображения



        }


        


    }



    //ПРОВЕРКА СОСТОЯНИЯ СЛОТОВ
    void SlotsCHECKING()
    {
        playerStillAlive = 0; //количесто игроков тут сбрасываем на ноль
        for (int i = 1; i <= 49; i++)
        {
            string chkslot = TNManager.GetChannelData<string>(i + "StatusSlot" + MMOshowplayers.yourLoc);

            if (chkslot != "USED")//уничтожаем вышедших
            {
                playersSlot[i] = false;
                //print("уничтожить слот " + i);
            }
            if (chkslot == "USED")//узнаем количество игроков тут
            {
                playerStillAlive += 1;
                print("не уничтожать слот "+i);
            } 
        }
        //если количество живых стало больше то рисуем иначе уничтожаем
        if(playerStillAlive > savedPlayersHERE)
        {
            print("проверка слотов, дорисовываем новые");
            DrawSlots();
            savedPlayersHERE = playerStillAlive;
        }

        else // if (playerStillAlive < savedPlayersHERE)
        {
            print("проверка слотов, убираем лишние");
            savedPlayersHERE = playerStillAlive;
            destroywaiting = true;
            //тотал уничтожение

            //ТМП ДЕБАГГЕР
            playersALLdestroyPIC = true;
            for (int i = 0; i <= 49; i++)//все кнопки очистить
            {
                playersSlot[i] = false;
                playersSLOTtoCreateWorkingCurrent[i] = false;
            }
        }

        
    }



    //ВХОД В ЛОКАЦИЮ
    void EnterInLoc()
    {

               //print
                print("Идет ваш вход в локацию");
                //ИМЯ для уникальной локации
                if (uniqueLOC == 1)
                {
                    //для владельца Локации
                    if (MMOsettings.locOwner == "owner")
                    {
                        MMOsettings.locUniqueID = MMOsettings.uniqueIDget;
                        MMOshowplayers.yourLoc = MMOshowplayers.yourLoc + MMOsettings.uniqueIDget;
                        print("вход хозяина ");
                    }

                    //для гостя
                    if (MMOsettings.locOwner == "guest")
                    {
                        MMOsettings.locUniqueID = MMOsettings.mmoGroupID[MeetingsSETTINGS.MTpartnerNUM];
                        print("вход гостя " + MMOsettings.mmoGroupID[MeetingsSETTINGS.MTpartnerNUM]);

                        MMOshowplayers.yourLoc = MMOshowplayers.yourLoc + MMOsettings.uniqueIDget;
                    }
                    //  uniqueLOC = 0;
                }

                for (int i = 1; i <= 49; i++)
                {
                    string chkslot;
                    chkslot = TNManager.GetChannelData<string>(i + "StatusSlot" + MMOshowplayers.yourLoc);//ЛОКАЦИЯ СЛОТЫ

                    //если слот свободен занимаем его
                    if (chkslot != "USED")
                    {
                        print("Удалось найти слот" + i + "в локации" + MMOshowplayers.yourLoc);
                        TNManager.SetChannelData(i + "StatusSlot" + MMOshowplayers.yourLoc, "USED"); //ПИШЕМ ЧТО СЛОТ ЗАНЯТ

                        //вписываем наш индификатор
                        TNManager.SetChannelData(i + "pathTOdata" + MMOshowplayers.yourLoc, MMOsettings.uniqueIDget); //конкретная инфа для конкретного слота в конкретной локации

                        int chkloc = TNManager.GetChannelData<int>("locCounter" + MMOshowplayers.yourLoc) + 1;//пишем +1 что мы в комнате
                        TNManager.SetChannelData("locCounter" + MMOshowplayers.yourLoc, chkloc);

                        MMOshowplayers.yourSlot = i;//сохраняем слот для очистки
                        print("плюс в локацию" + chkloc + "LOC" + MMOshowplayers.yourLoc);
                        i = 49; //останавливаем цикл                               
                        DrawSlots(); // КОМАНДА РИСОВАНИЯ  
                    }

                }  

        

    }


    //РИСУЕМ
    public static void DrawSlots()
    {      
        playersALLdestroyPIC = false; //НЕ УНИЧТОЖАТЬ КАРТИНКИ        
        print("обращение к рисоватору");

        //записываем новые
        for (int i = 1; i <= 49; i++)
        {

            //берем отсюда информацию
            int datapath = TNManager.GetChannelData<int>(i + "pathTOdata" + MMOshowplayers.yourLoc);
            //проверяем онлайн ли игрок:?
            int chkonline = TNManager.GetChannelData<int>("yourNewPlayer" + datapath);
            //проверяем слот
            string chkslot = TNManager.GetChannelData<string>(i + "StatusSlot" + MMOshowplayers.yourLoc);


            //если слот не свободен и игрок онлайн
            if ((chkslot == "USED") && (chkonline == 1))
            {
                //если слот не был нарисован ранее
                if (playersSlot[i] != true)
                {
                    print("слот занят" + i);
                    savedPlayersHERE += 1;
                    //сохраняем ID
                    playersSlotID[i] = datapath;
                    //справшиваем имя слота и вписываем имя
                    allPlayersNameData[i] = TNManager.GetChannelData<string>("yourServerName" + datapath);
                    //справшиваем картинку слота
                    allPlayersPICData[i] = TNManager.GetChannelData<string>("yourServerPIC" + datapath);

                    //ПОЛУЧАЕМ ДАННЫЕ ДЛЯ РИСОВКИ
                    MMOsettings.mmoGenderOther = TNManager.GetChannelData<string>("yourServerGender" + datapath);//справшиваем пол слота
                    MMOsettings.mmoHairColorOther = TNManager.GetChannelData<string>("yourServerHairColor" + datapath);//справшиваем цвет волос
                    MMOsettings.mmoHeroPICotherNUM = TNManager.GetChannelData<string>("yourServerPICnum" + datapath);//справшиваем номер внешности   
                    //ФОРМИРУЕМ СТРОКУ
                    allPlayersPICData[i] = MMOsettings.mmoGenderOther + "/" + MMOsettings.mmoHairColorOther + "/" + MMOsettings.mmoHeroPICotherNUM;

                    

                    playersSLOTtoCreate += 1;             //сколько игроков надо создать
                    playersSlot[i] = true; //этого игрока не уничтожать                  
                    

                    //не обновлять локацию после рисования
                    int chkplayers_inroom = TNManager.GetChannelData<int>("locCounter" + MMOshowplayers.yourLoc);
                    savedPlayersHERE = chkplayers_inroom;
                    print("REFRESH TRUE");
                    refreshSLOT = true;
                    
                }
                else  if (playersSlot[i] != true) //этот игрок уже был нарисован
                {
                    //не обновлять локацию после рисования
                    int chkplayers_inroom = TNManager.GetChannelData<int>("locCounter" + MMOshowplayers.yourLoc);
                    savedPlayersHERE = chkplayers_inroom;

                    print("REFRESH TRUE");
                    refreshSLOT = true;
                }
                                     //создать слот игрока
                                                      //РИСУЕМ                     
                                                      // Image tstIMG;
                                                      //   tstIMG = MMOshowplayers.playersPICSlot[i].GetComponent<Image>();
                                                      //   tstIMG.sprite = Resources.Load<Sprite>("MMO/heroes/" + MMOsettings.mmoGenderOther + "/" + MMOsettings.mmoHairColorOther + "/" + MMOsettings.mmoHeroPICotherNUM);               
            }
            else { playersSlot[i] = false; } //УНИЧТОЖАЕМ БЕСХОЗНЫЕ СЛОТЫ


            //очищаем ливеров
            if ((chkslot == "USED") && (chkonline == 0))
            {
                TNManager.SetChannelData(i + "StatusSlot" + MMOshowplayers.yourLoc, "");
            }

            if (i == 49) { CreatorPlayer(); print("необходимо создать игроков " + playersSLOTtoCreate); }

        }

        refreshSLOT = true; //АКТИВИРУЕМ ОБНОВЛЕНИЕ


    }



    //функция создания
    public static void CreatorPlayer()
    {

        //сколько слотов надо создать?
        if (playersSLOTtoCreate > 0)
        {
            //обращение к кнопкосоздателю
            playersSLOTtoCreateWorking = true;
        }
        //если вдруг не надо, то не создаем
        else  if (playersSLOTtoCreate <= 0)
        {

        }





        
    }




    //функция уничтожения панели
    public static void destroyIT()
    {
        playersPANactive = false;
    }


    //ТРЕБУЕТСЯ ОЧИСТКА
  /* public static void NEEDCLEAR()
    {
        MMOshowplayers.yourPRELoc = MMOshowplayers.yourLoc;
      //  MMOshowplayers.TMPUNIQUELOC = MMOplayerlist.uniqueLOC;
      //  MMOshowplayers.yourLoc = MMOstart.placesBTScommand[0];
        MMOplayerlist.clearYou = true;
    }*/

}
