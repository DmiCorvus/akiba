using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//ПРИКРЕПЛЕН: UI
//ОПИСАНИЕ: сейв-лоад, квесты
public class UIactive : MonoBehaviour {

    public GameObject itPAN;//ЭТА ПАНЕЛЬ
    public static bool UIpanActive;

    //аудио
    public static GameObject AudioLobby;
    public static GameObject music;
    public Toggle musicSwitcher;

    //телефон
    public static GameObject phone;

    //квест панель
    public static GameObject questPAN;   
    public static GameObject ContentActiveQuest;
    public static GameObject ContentEndedQuest;
    public static GameObject questActivePAN;
    public static GameObject questEndedPAN;

    public static GameObject aboutPAN;
    public static GameObject downPan;//Нижняя панелька
    public static GameObject lobbyIMAGE;//картинка

    //Карточка о ММО группе
    public static GameObject GroupAboutPAN;
    public static GameObject GICplayer1card;
    public static GameObject GICplayer2card;
    public static GameObject GICplayer3card;
    public static GameObject GICplayer4card;

    //Карточка о экипаже
    public static GameObject CrewsAboutPAN;
    public static GameObject CICplayer1card;
    public static GameObject CICplayer2card;
    public static GameObject CICplayer3card;
    public static GameObject CICplayer4card;

    //MAIN PANEL
    public static GameObject mainPanel;


    void Awake () {
        //аудио
        AudioLobby = GameObject.Find("AudioLobby");
        music = GameObject.Find("Audio");
        //     AudioSpace = GameObject.Find("AudioSpace");

        //телефон
        phone = GameObject.Find("PhonePanel");

        //присваиваем значения
        aboutPAN = GameObject.Find("AboutGamePanel");
        downPan = GameObject.Find("downpanel");
        lobbyIMAGE = GameObject.Find("LobbyImage");

        //квест панель     
        questPAN = GameObject.Find("QuestPanel");
        ContentActiveQuest = GameObject.Find("activeQuestGrid");
        ContentEndedQuest = GameObject.Find("endedQuestGrid");
        questActivePAN = GameObject.Find("questActivePAN");
        questEndedPAN = GameObject.Find("questEndedPAN");

        //Карточка о ММО группе
        GroupAboutPAN = GameObject.Find("GroupInfoCard");
        GICplayer1card = GameObject.Find("GICplayer1group");
        GICplayer2card = GameObject.Find("GICplayer2group");
        GICplayer3card = GameObject.Find("GICplayer3group");
        GICplayer4card = GameObject.Find("GICplayer4group");

        //Карточка о экипаже
        CrewsAboutPAN = GameObject.Find("CrewsInfoCard");
        CICplayer1card = GameObject.Find("CICplayer1group");
        CICplayer2card = GameObject.Find("CICplayer2group");
        CICplayer3card = GameObject.Find("CICplayer3group");
        CICplayer4card = GameObject.Find("CICplayer4group");


        //MAIN PANEL
        mainPanel = GameObject.Find("mainPanel");

        
        print("UIworking...");

    }
	
	
	void OnEnable () {
        UIpanActive = true;
        mainPanel.GetComponent<Image>().color = new Color32(188, 188, 188, 255);
        //аудио

        //проверка музыки
        if (PlayerPrefs.GetString("Music") == "ON") { musicSwitcher.isOn = true; }
        if (PlayerPrefs.GetString("Music") == "OFF") { musicSwitcher.isOn = false; }

        phone.SetActive(false);

        aboutPAN.SetActive(false);

        questActivePAN.SetActive(true);
        questEndedPAN.SetActive(false);
        questPAN.SetActive(false);        

        //группа
        GICplayer1card.SetActive(false);
        GICplayer2card.SetActive(false);
        GICplayer3card.SetActive(false);
        GICplayer4card.SetActive(false);
        GroupAboutPAN.SetActive(false);

        //экипаж
        CICplayer1card.SetActive(true);
        CICplayer2card.SetActive(false);
        CICplayer3card.SetActive(false);
        CICplayer4card.SetActive(false);
        CrewsAboutPAN.SetActive(false);


    }

    void Update()
    {
        //УНИЧТОЖАЕМ ЭТУ ПАНЕЛЬ
        if (UIpanActive == false)
        {
            QuestPAN.destroyALLquest = true;
            questPAN.SetActive(true);
            questActivePAN.SetActive(true);
            questEndedPAN.SetActive(true);

            if (QuestPAN.questcounterALL == 0)
            {
                print("ВСЕ КВЕСТЫ УНИЧТОЖЕНЫ");
                //выключить
                itPAN.SetActive(false);
                //активировать OnEnable
                itPAN.SetActive(true);
            }
        }
        //END

    }
}
