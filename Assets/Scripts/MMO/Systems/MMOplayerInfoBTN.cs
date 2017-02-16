using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TNet;


public class MMOplayerInfoBTN : MonoBehaviour {

    public GameObject playerPIC;
    public GameObject playerName;
    public static int destroyme;
    public int TESTDESTROY;
    public int TESTID;

    public static int datapathTMP; //ВРЕМЕННЫЙ ПУТЬ
    //КАРТОЧКА
    public GameObject playerCARDopen;




    void Start () {

        destroyme = MMOplayerlist.playersSLOTtoCreateWorkingNUM;
        TESTDESTROY = destroyme;
        //сохраняем путь
        datapathTMP = MMOplayerlist.playersSlotID[destroyme];
        TESTID = datapathTMP;
        print("Задали путь" + datapathTMP);

        //считаем количество слотов игроков
        MMOplayerlist.playerNUMslotCounter += 1;    

        //вписать имя 
        playerName.GetComponent<Text>().text = MMOplayerlist.allPlayersNameData[destroyme];
        //нарисовать картинку

        Image tstIMG = playerPIC.GetComponent<Image>();
        tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOplayerlist.allPlayersPICData[destroyme]);

        //теперь мы создали это
        MMOplayerlist.playersSLOTtoCreateWorkingWAIT = false;
        //надо меньше на 1 кнопку создавать
        MMOplayerlist.playersSLOTtoCreate -= 1;
        print("команда уничтожения этого слота" + destroyme);

    }
	


	void Update () {
        //уничтожить ЭТО
        if  (MMOplayerlist.playersSlot[destroyme] == false)  {Destroy(gameObject); }
        //уничтожить ВСЁ
        if (MMOplayerlist.playersALLdestroyPIC == true){  Destroy(gameObject); }
    }


    
    void OnDestroy()
    {
        //минусуем количество слотов игроков
        MMOplayerlist.playerNUMslotCounter -= 1;
        //слот теперь не создан
        MMOplayerlist.playersSLOTtoCreateWorkingCurrent[destroyme] = false;
        
    }


    //кнопка открытия карточки
    public void OpenPlayerCard()
    {
        print("btn");
        MMOaboutOtherPlayer.getDataPath = destroyme;
        MMOaboutOtherPlayer.datapath = TESTID;
        print("путь в карте" + MMOaboutOtherPlayer.datapath);
        print("путь наш" + datapathTMP);
        print("путь наш2" + TESTID);

        MMOaboutOtherPlayer.aboutOtherPlayerPAN.SetActive(true);
        MMOaboutOtherPlayer.aboutOtherPanel();
    }
}
