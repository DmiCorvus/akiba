using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//ПРИКРЕПЛЕН к ЛОКАЛИЗАЦИЯ/ЛОББИ
//ПЕРЕВОД ЛОББИ

public class LangLobby : MonoBehaviour {

    //СТРОКИ
    //1 экран начало игры
    public Text singleGameBTN;
    public Text mmoGameBTN;
    public Text warningTXT;
    //экран настроек игры
    public Text settingsTopTXT;
    public Text musicTXT;
    //старт одиночной игры
    public Text singleTopTXT;
    public Text singleBeginBTN;
    //коннект 
    public Text mmoListServersTopTXT;
    public Text mmoServerNameTXT;
    public Text mmoServerPlaceTXT;
    public Text mmoServerStatusTXT;
    public Text mmoYourVerServerTXT;
    public Text mmoServerVerServerTXT;
    public Text mmoConnectToServerBTN;
    public Text mmoServerNeedUpdateTXT;
    //старт mmo игры
    public Text mmoTopTXT;
    public Text mmoBeginBTN;
    //создание персонажа
    public Text createTopTXT;
    public Text createCharNameTXT;
    public Text createCharGenderTXT;
    public Text createCharHairTXT;
    public Text createCharAviTXT;
    public Text createCharNextBTN;
    //создание семьи
    public Text familyTopTXT;
    public Text familyADDbroTXT;
    public Text familyADDsisTXT;
    public Text familyBROpersona;
    public Text familySISpersona;
    public Text familyComplite;
    //выход из игры
    public Text exitGameYES;
    public Text exitGameNO;
    public Text exitGameTXT;
    //выход в меню
    public Text exitMenuYES;
    public Text exitMenuNO;
    public Text exitMenuTXT;



    void OnEnable()
    {

        if (LangMAIN.LangActive == true)
        {

            //РУССКИЙ
            if (MMOsettings.LANG == "RU")
            {
                //1 экран начало игры
                singleGameBTN.GetComponent<Text>().text = "Одиночная игра";
                mmoGameBTN.GetComponent<Text>().text = "Мультиплеер";
                warningTXT.GetComponent<Text>().text = "* Начиная эту игру пользователь подтверждает, что ему более 18 лет";
                //экран настроек игры
                settingsTopTXT.GetComponent<Text>().text = "НАСТРОЙКИ";
                musicTXT.GetComponent<Text>().text = "Музыка";
                //старт одиночной игры
                singleTopTXT.GetComponent<Text>().text = "ОДИНОЧНАЯ ИГРА";
                singleBeginBTN.GetComponent<Text>().text = "ВОЙТИ В ГОРОД";
                //коннект 
                mmoListServersTopTXT.GetComponent<Text>().text = "СПИСОК СЕРВЕРОВ";
                mmoServerNameTXT.GetComponent<Text>().text = "Название:";
                mmoServerPlaceTXT.GetComponent<Text>().text = "Местоположение:";
                mmoServerStatusTXT.GetComponent<Text>().text = "Статус:";
                mmoYourVerServerTXT.GetComponent<Text>().text = "Ваша версия игры:";
                mmoServerVerServerTXT.GetComponent<Text>().text = "Версия на сервере:";
                mmoConnectToServerBTN.GetComponent<Text>().text = "ПРИСОЕДИНИТЬСЯ";
                mmoServerNeedUpdateTXT.GetComponent<Text>().text = "Требуется обновление";
                //старт mmo игры
                mmoTopTXT.GetComponent<Text>().text = "МУЛЬТИПЛЕЕР";
                mmoBeginBTN.GetComponent<Text>().text = "ВОЙТИ В ГОРОД";
                //создание персонажа
                createTopTXT.GetComponent<Text>().text = "СОЗДАНИЕ ПЕРСОНАЖА";
                createCharNameTXT.GetComponent<Text>().text = "Имя персонажа:";
                createCharGenderTXT.GetComponent<Text>().text = "Пол персонажа:";
                createCharHairTXT.GetComponent<Text>().text = "Цвет волос:";
                createCharAviTXT.GetComponent<Text>().text = "Аватар:";
                createCharNextBTN.GetComponent<Text>().text = "ДАЛЕЕ";
                //создание семьи
                familyTopTXT.GetComponent<Text>().text = "СОЗДАНИЕ ПЕРСОНАЖА / СЕМЬЯ";
                familyADDbroTXT.GetComponent<Text>().text = "Добавить брата";
                familyADDsisTXT.GetComponent<Text>().text = "Добавить сестру";
                familyBROpersona.GetComponent<Text>().text = "Характер:";
                familySISpersona.GetComponent<Text>().text = "Характер:";
                familyComplite.GetComponent<Text>().text = "ЗАВЕРШИТЬ";
                //выход из игры
                exitGameYES.GetComponent<Text>().text = "ДА";
                exitGameNO.GetComponent<Text>().text = "НЕТ";
                exitGameTXT.GetComponent<Text>().text = "Вы уверены, что хотите выйти игры?";
                //выход в меню
                exitMenuYES.GetComponent<Text>().text = "ДА";
                exitMenuNO.GetComponent<Text>().text = "НЕТ";
                exitMenuTXT.GetComponent<Text>().text = "Вы уверены, что хотите выйти в главное меню?";

            }



            //ENGLISH
            if (MMOsettings.LANG == "EN")
            {
                //1 экран начало игры
                singleGameBTN.GetComponent<Text>().text = "Single game";
                mmoGameBTN.GetComponent<Text>().text = "Multiplayer";
                warningTXT.GetComponent<Text>().text = "* Starting this game the user confirms that he was more than 18 years";
                //экран настроек игры
                settingsTopTXT.GetComponent<Text>().text = "SETTINGS";
                musicTXT.GetComponent<Text>().text = "Music";
                //старт одиночной игры
                singleTopTXT.GetComponent<Text>().text = "SINGLE GAME";
                singleBeginBTN.GetComponent<Text>().text = "ENTER TO THE CITY";
                //коннект 
                mmoListServersTopTXT.GetComponent<Text>().text = "LIST OF SERVERS";
                mmoServerNameTXT.GetComponent<Text>().text = "Name:";
                mmoServerPlaceTXT.GetComponent<Text>().text = "Location:";
                mmoServerStatusTXT.GetComponent<Text>().text = "Status:";
                mmoYourVerServerTXT.GetComponent<Text>().text = "Your game version:";
                mmoServerVerServerTXT.GetComponent<Text>().text = "Server game version:";
                mmoConnectToServerBTN.GetComponent<Text>().text = "CONNECT";
                mmoServerNeedUpdateTXT.GetComponent<Text>().text = "Need update";
                //старт mmo игры
                mmoTopTXT.GetComponent<Text>().text = "MULTIPLAYER";
                mmoBeginBTN.GetComponent<Text>().text = "ENTER TO THE CITY";
                //создание персонажа
                createTopTXT.GetComponent<Text>().text = "CHARACTER CREATION";
                createCharNameTXT.GetComponent<Text>().text = "Character name:";
                createCharGenderTXT.GetComponent<Text>().text = "Gender:";
                createCharHairTXT.GetComponent<Text>().text = "Hair color:";
                createCharAviTXT.GetComponent<Text>().text = "Avatar:";
                createCharNextBTN.GetComponent<Text>().text = "NEXT";
                //создание семьи
                familyTopTXT.GetComponent<Text>().text = "CHARACTER CREATION / FAMILY";
                familyADDbroTXT.GetComponent<Text>().text = "Add brother";
                familyADDsisTXT.GetComponent<Text>().text = "Add sister";
                familyBROpersona.GetComponent<Text>().text = "Personality:";
                familySISpersona.GetComponent<Text>().text = "Personality:";
                familyComplite.GetComponent<Text>().text = "DONE";
                //выход из игры
                exitGameYES.GetComponent<Text>().text = "YES";
                exitGameNO.GetComponent<Text>().text = "NO";
                exitGameTXT.GetComponent<Text>().text = "Are you sure you want to quit the game?";
                //выход в меню
                exitMenuYES.GetComponent<Text>().text = "YES";
                exitMenuNO.GetComponent<Text>().text = "NO";
                exitMenuTXT.GetComponent<Text>().text = "Are you sure you want to exit to the main menu?";

            }



            gameObject.SetActive(false);


        }


    }
}
