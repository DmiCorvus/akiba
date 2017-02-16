using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MMOsettings : MonoBehaviour {

    //версия игры
    public Text clientVersionTXTtop;                     //Текст вверху
    public Text clientVersionTXTconnect;                  //Текст при соединении
    public static int clientVersion = 20170203;          //Реальная версия клиента
    public static string clientVersionVISUAL = "0.1a"; //Используется для отображения

    //язык игры
    public static string LANG; 

    //сингл - мультиплеер
    public static bool singleGame = false;

    //индивидуальные настройки
    public static int uniqueIDget;//индификатор   

    public static string mmoName;
    public static string mmoSecondName; //обобщенное имя
    public static int mmoGenderNUM = 0;  //0 - мужской 1 женский
    public static string mmoGender = "male";
    public static int mmoHarirColorNUM = 0; //0 - черный 1 - блонда
    public static string mmoHairColor = "dark";//цвет волос
    public static int mmoHeroPICnum = 0;//номер внешности   



    //формирование группы
    //общее
    public static int mmoGroup = 0; //0 без группы 
    public static string mmoGroupLeader = "owner"; //guest определяем лидера группы
    public static int mmoGroupCurrentSlot = 1; //Ваш слот в текущей группе
    public static int mmoGroupMaxSize = 4; //размер макс группы
    public static int mmoGroupCurrentSize = 1; //размер текущей группы
    //параметры каждого
    public static string[] mmoGroupSlot = new string[5];//слот в группе free/used
    public static int[] mmoGroupID = new int[5];//ID участников группы
    public static string[] mmoGroupNames = new string[5];//имена в группе
    public static string[] mmoGroupGender = new string[5];//пол в группе
    public static string[] mmoGroupPICnum = new string[5];//номер внешности в группе


    //ИНФО СОБЕСЕДНИКА
    public static string mmoNameOther; //имя собеседника
    public static string mmoGenderOther; //пол собеседника
    public static string mmoHairColorOther; //цвет волос собеседника
    public static string mmoHeroPICotherNUM;// номер внешности 
    public static int mmoDataPathOther;//путь к данным собеседника
    public static int mmoDataPathAcceptTeam;//путь к данным для вступления в тиму
    public static int mmoGroupOther; //провряем в группе ли собеседник?



    //Сохранения комнат
    public static int roomDesign = 0; //дизайн комнаты

    //
    public static int dressDesign = 0; //ваша одежда

    //
    public static bool guest = false; //мы в гостях

    //Свойства локаций
    public static string locOwner = "owner"; //владелец локации
    public static int locUniqueID; //уникальный номер локации




    void OnEnable()
    {
        clientVersionTXTtop.GetComponent<Text>().text = clientVersionVISUAL;
        clientVersionTXTconnect.GetComponent<Text>().text = clientVersionVISUAL;

        //проверка языка 
        if (!PlayerPrefs.HasKey("Language"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
            {
                PlayerPrefs.SetString("Language", "RU");
                print("УСТАНОВЛЕН РУС");
                LANG = "RU";
            }

            else
            {                
                PlayerPrefs.SetString("Language", "EN");
                print("УСТАНОВЛЕН ЕНГ");
                LANG = "EN";
            }
        }
        //Устанавливаем язык
        if (PlayerPrefs.GetString("Language") == "RU") { LANG = "RU"; }
        if (PlayerPrefs.GetString("Language") == "EN") { LANG = "EN"; }
        print("ЯЗЫК УСТАНОВЛЕН");



    }
}
