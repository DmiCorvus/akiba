using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//ОПИСАНИЕ:НАСТРОЙКИ
//ПРИКРЕПЛЕН: К SETTINGS
public class Settings : MonoBehaviour {

    //общее
    public GameObject settingsPanel;
    private bool applySettings;

    //аудио
    public Toggle musicSwitcher;   
  

    //языки
    public GameObject enlang;
    public GameObject rulang;

    

    void Awake()
    {
              
       
    }

    void Start()
    {
        print("ЯЗЫК ПРИМЕНЕН");
        //Устанавливаем язык
        LangMAIN.LocalistionEnable();

        //проверка музыки
        if (PlayerPrefs.GetString("Music") == "ON") { UIactive.music.SetActive(true); }
        if (PlayerPrefs.GetString("Music") == "OFF") { UIactive.music.SetActive(false); }

        settingsPanel.SetActive(false);

    }

    void OnEnable()
    {

        //панель языков
     /*   if (MMOsettings.LANG == "RU")
        {
            enlang.SetActive(false);
            rulang.SetActive(true);
        }
        if (MMOsettings.LANG == "EN")
        {
            enlang.SetActive(true);
            rulang.SetActive(false);
        }*/



    }



    //ОТКРЫТЬ ПАНЕЛЬ
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    //ЗАКРЫТЬ ПАНЕЛЬ
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }



    //МУЗЫКА
    public void AudioEnable()
    {       
   
           //включить музыку
            if (musicSwitcher.isOn == true)
            {
                UIactive.music.SetActive(true);
                PlayerPrefs.SetString("Music", "ON");
            }
            //выкл
            else if (musicSwitcher.isOn == false)
            {
                UIactive.music.SetActive(false);
                PlayerPrefs.SetString("Music", "OFF");
            }
        
       

    }



    //ЯЗЫК
    //СТАВИМ РУССКИЙ
    public void langSwitcherRU()
    {
        MMOsettings.LANG = "RU";
        enlang.SetActive(false);
        rulang.SetActive(true);
        PlayerPrefs.SetString("Language", "RU");

        //Устанавливаем язык
        LangMAIN.LocalistionEnable();
    }
    //СТАВИМ АНГЛИЙСКИЙ
    public void langSwitcherEN()
    {
        MMOsettings.LANG = "EN";
        enlang.SetActive(true);
        rulang.SetActive(false);
        PlayerPrefs.SetString("Language", "EN");

        //Устанавливаем язык
        LangMAIN.LocalistionEnable();
    }
}
