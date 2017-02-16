using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TNet;

//ЗДЕСЬ ХРАНИТСЯ ОБЩАЯ ИНФОРМАЦИЯ ДЛЯ ОТОБРАЖЕНИЯ //MMOSHOW
public class MMOshowplayers : MonoBehaviour {

       
    public static string[] allPlayersNameData = new string[50];//ИМЕНА ИГРОКОВ

    public static Text[] PlayersNamesField = new Text[10];//ВПИСЫВАЕМ ТЕКСТ
    public static string[] allPlayersPICData = new string[50];//КАРТИНКИ ИГРОКОВ
    public static GameObject[] playersPICSlot = new GameObject[10];//СЛОТЫ  С КАРТИНКАМИ

    public static int yourSlot;// ВАШ СЛОТ - ДЛЯ ОЧИСТКИ = i
    public static string yourLoc; //ЛОКАЦИЯ ГДЕ ВЫ НАХОДИТЕСЬ MMOshowplayers.yourLoc
    public static string yourPRELoc; //ЛОКАЦИЯ ГДЕ ВЫ НАХОДИЛИСЬ ДО ЭТОГО MMOshowplayers.yourPRELoc  
    public static string locname = "Орбита планеты Земля 0-1-3";

    public static int tmpSavePlayers; //сохраняем количество игроков
    public GameObject playersOnServer;

    public static string settingsSlotComplete;

    public static bool playercreated = false;

    void Start()
    {     
   

    }

    void OnEnable()
    {
          locname = "";
          playercreated = false;

        for (int i = 0; i <= 49; i++)
        {
           // playersSlot[i] = false;
            allPlayersNameData[i] = "";

        }
    }


    //количество игроков на сервере
    void Update()
    {
        int tmpPlayers;
        tmpPlayers = TNManager.GetChannelData<int>("playersOnServer");

        if (tmpPlayers != tmpSavePlayers)
        {
            tmpSavePlayers = tmpPlayers;
            //вписываем текст
            playersOnServer.GetComponent<Text>().text = ""+ tmpPlayers;
        }
    }



}
