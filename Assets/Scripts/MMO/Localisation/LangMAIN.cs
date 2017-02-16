using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ПРИКРЕПЛЕН к ЛОКАЛИЗАЦИЯ
//УПРАВЛЯЮЩИЙ СКРИПТ

public class LangMAIN : MonoBehaviour {

    public static bool LangActive;
    public static GameObject LangLobby;
    public static GameObject LangInfoPan;


    void Awake()
    {
        LangLobby = GameObject.Find("LangLobby"); 
        LangInfoPan = GameObject.Find("LangInfoPan");

        LangLobby.SetActive(false);
        LangInfoPan.SetActive(false);

        LangActive = true;
        print("Присвоено");
    }


    //ПУСК ЛОКАЛИЗАЦИИ
    public static void LocalistionEnable()
    {
        print("Запущено");
        LangLobby.SetActive(true);
        LangInfoPan.SetActive(true);
    }

}
