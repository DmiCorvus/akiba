using UnityEngine;
using System.Collections;
using TNet;
using UnityEngine.UI;

//ПРИКРЕПЛЕН К ММО
//ОПИСАНИЕ: карточка информации об игроке
public class MMOaboutOtherPlayer : MonoBehaviour {
    public static GameObject aboutOtherPlayerPAN;//О ДРУГОМ ИГРОКЕ

    public static GameObject aboutOtherPlayerName;//ИМЯ ДРУГОГО ИГРОКА
    public static GameObject aboutOtherPlayerGender;//ПОЛ ДРУГОГО ИГРОКА

    public static GameObject aboutOtherPlayerGroup;//СОСТОИТ ЛИ В ГРУППЕ
    public static GameObject aboutOtherPlayerActions;//БЛОКИРУЕМ ДЕЙСТВИЯ

    public static GameObject aboutOtherPlayerPIC;//СЛОТ КАРТИНКИ

    //ИСПОЛЬЗУЕМ УНИКАЛЬНЫЕ ДАННЫЕ:
    public static string mmoCardNameOther; //ИМЯ ДЛЯ КАРТОЧКИ
    public static string mmoCardGenderOther; //ПОЛ ДЛЯ КАРТОЧКИ
    public static string mmoCardHairOther; //ЦВЕТ ВОЛОС
    public static string mmoCardPICnumOther; //номер внешности



    public Text infoMSGtext; //инфо мсг



    public static int getDataPath;
    public static int datapath;

    void Start()
    {
        aboutOtherPlayerName = GameObject.Find("GPImmoNameText");//назначили слот имени
        aboutOtherPlayerGender = GameObject.Find("GPIgenderTXT");//назначили слот пола
        aboutOtherPlayerGroup = GameObject.Find("GPIgroupTXT");//назначили состояние слота в группе
        aboutOtherPlayerPIC = GameObject.Find("GPIImage");//назначили слот картинки
        aboutOtherPlayerActions = GameObject.Find("GPIlistActions");//блок действий себя



        aboutOtherPlayerPAN = GameObject.Find("GetPlayerInfo");
        aboutOtherPlayerPAN.SetActive(false);
    }


    //ОТПРАВЛЯЕМ ЗАПРОС НА ПАТИ
    public void sendingTeam()
    {
        aboutOtherPlayerPAN.SetActive(false);
        
        //если вы лидер группы и у вас есть место
        if ((MMOsettings.mmoGroupLeader == "owner")&&(MMOsettings.mmoGroupCurrentSize < 4))
        {
            //номер вашего слота в будущей группе
            MMOsettings.mmoGroupCurrentSlot = 1;
            //приглашение отправлено
            infoMSGtext.GetComponent<Text>().text = "Приглашение отправлено";
            //формируем текст запроса
            string tempTXT;
            tempTXT = MMOsettings.mmoName + " предлагает войти в команду";
            //отправляем текст запроса
            TNManager.SetChannelData("yourServerGroupADDEDtext" + datapath, tempTXT);
            //отправляем запрос
            TNManager.SetChannelData("yourServerGroupADDED" + datapath, 1);
            //отправляем наш ID
            TNManager.SetChannelData("yourServerGroupADDED_ID" + datapath, MMOsettings.uniqueIDget);
        }
else
        {
            infoMSGtext.GetComponent<Text>().text = "Действие невозможно";
        }
    }

    //ЗАКРЫВАЕМ ПАНЕЛЬ
    public void CloseOtherPanel()
    {
        aboutOtherPlayerPAN.SetActive(false);
    }

    //ОТРИСОВКА ПОРТРЕТОВ
    public static void painterIMG()
    {

        //ПОЛУЧАЕМ ДАННЫЕ ДЛЯ РИСОВКИ
      //  mmoCardGenderOther = TNManager.GetChannelData<string>("yourServerGender" + datapath);//справшиваем пол слота
     //   mmoCardHairOther = TNManager.GetChannelData<string>("yourServerHairColor" + datapath);//справшиваем цвет волос
     //   mmoCardPICnumOther = TNManager.GetChannelData<string>("yourServerPICnum" + datapath);//справшиваем номер внешности

        //РИСУЕМ 
        Image tstIMG = aboutOtherPlayerPIC.GetComponent<Image>();
        tstIMG.sprite = Resources.Load<Sprite>("MMO/heroes/" + mmoCardGenderOther + "/" + mmoCardHairOther + "/" + mmoCardPICnumOther);
        print("Рисуем" + getDataPath);
        //ЗАКОНЧИЛИ РИСОВАТЬ
    }




    //КАРТОЧКА
    public static void aboutOtherPanel()
    {
        print("обращаемся по пути" + datapath);
        aboutOtherPlayerPAN.SetActive(true);
        //формируем запрос к получению информации
        mmoCardGenderOther = TNManager.GetChannelData<string>("yourServerGender" + datapath);//справшиваем пол слота
        mmoCardHairOther = TNManager.GetChannelData<string>("yourServerHairColor" + datapath);//справшиваем цвет волос
        mmoCardPICnumOther = TNManager.GetChannelData<string>("yourServerPICnum" + datapath);//справшиваем номер внешности

        //берем отсюда информацию
        MMOsettings.mmoDataPathOther = datapath;//сохраняем путь собеседника
        //вписываем имя
        mmoCardNameOther = TNManager.GetChannelData<string>("yourServerName" + datapath);

        //если дата путь равен нашему айди
        if (datapath == MMOsettings.uniqueIDget) {
            aboutOtherPlayerName.GetComponent<Text>().text = "Ваш персонаж";
            aboutOtherPlayerActions.SetActive(false);//блок действий
        }
        if (datapath != MMOsettings.uniqueIDget) {
            aboutOtherPlayerName.GetComponent<Text>().text = mmoCardNameOther;
            aboutOtherPlayerActions.SetActive(true);//блок действий
        }
        //вписываем пол
        mmoCardGenderOther = TNManager.GetChannelData<string>("yourServerGender" + datapath);
        if (mmoCardGenderOther == "male") { aboutOtherPlayerGender.GetComponent<Text>().text = "Мужской"; }
        if (mmoCardGenderOther == "female") { aboutOtherPlayerGender.GetComponent<Text>().text = "Женский"; }
        //вписываем группу
        MMOsettings.mmoGroupOther = TNManager.GetChannelData<int>("yourServerGroup" + datapath);
        if (MMOsettings.mmoGroupOther == 1) { aboutOtherPlayerGroup.GetComponent<Text>().text = "Да"; }
        if (MMOsettings.mmoGroupOther == 0) { aboutOtherPlayerGroup.GetComponent<Text>().text = "Нет"; }

        if (MMOsettings.mmoGroupOther == 1)//если в группе нельзя пригласить
        {
            aboutOtherPlayerActions.SetActive(false);//блок действий
        }
        //вписываем картинку
        painterIMG();

    }
 



}
