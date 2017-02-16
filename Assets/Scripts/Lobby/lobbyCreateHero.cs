using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//ПРИКРЕПЛЕН К LOBBY
//ОПИСАНИЕ - создаем героя
public class lobbyCreateHero : MonoBehaviour {

    public GameObject createPAN; //ОБЩАЯ
    public GameObject createBTN; //кнопка вкл/выкл создание персонажа
    public GameObject heroCreatePAN; //ГЕРОЙ
    public GameObject familyCreatePAN; //СЕМЬЯ
    public GameObject genderTXT; //вписываем пол
    public GameObject hairchangePAN; //панель цвета
    public GameObject hairchange; //цвет волос
    public GameObject imageAvi; //картинка аватара
    public GameObject nextBTN;// NEXT

    public GameObject familyCreate;

    public Toggle broToggle;
    public GameObject broPAN;
    public GameObject broPersonality;//кратко
    public GameObject broPersonalityTXT;//подробно

    public Toggle sisToggle;
    public GameObject sisPAN;
    public GameObject sisPersonality; //кратко
    public GameObject sisPersonalityTXT;//подробно

    public GameObject startingScreen;//СТАРТОВЫЙ ЭКРАН

    //ДАННЫЕ ЛОКАЛИЗАЦИИ
    private static string lang_male_gender;
    private static string lang_female_gender;

    private static string lang_broPersonality_0;
    private static string lang_broPersonality_1;
    private static string lang_broPersonality_2;
    private static string lang_broPersonality_0txt;
    private static string lang_broPersonality_1txt;
    private static string lang_broPersonality_2txt;

    private static string lang_sisPersonality_0;
    private static string lang_sisPersonality_1;
    private static string lang_sisPersonality_2;
    private static string lang_sisPersonality_0txt;
    private static string lang_sisPersonality_1txt;
    private static string lang_sisPersonality_2txt;



    //панель семьи
    public void FamilyCreatePAN()
    {
        familyCreate.SetActive(true);
        heroCreatePAN.SetActive(false);
        broToggle.isOn = false;
        broPAN.SetActive(false);
        sisToggle.isOn = false;
        sisPAN.SetActive(false);

        //сброс семьи
        Family.sisPersonality = 1;
        Family.broPersonality = 1;
        Family.sister = false;
        Family.brother = false;

        //характер брата
        broPersonality.GetComponent<Text>().text = lang_broPersonality_1;
        broPersonalityTXT.GetComponent<Text>().text = lang_broPersonality_1txt;
        //характер сестры
        sisPersonality.GetComponent<Text>().text = lang_sisPersonality_1;
        sisPersonalityTXT.GetComponent<Text>().text = lang_sisPersonality_1txt;

    }

    //закрыть панель создания
    public void CloseCreatePAN()
    {
        createPAN.SetActive(false);
        createBTN.SetActive(true);

    }

    //открыть панель создания
    public void OpenCreatePAN()
    {
        //СБРОС
        MMOsettings.mmoName = "";
        MMOsettings.mmoGender = "male";
        MMOsettings.mmoGenderNUM = 0;
        MMOsettings.mmoHairColor = "dark";
        MMOsettings.mmoHarirColorNUM = 0;
        MMOsettings.mmoHeroPICnum = 0;

        //локализация
        if (MMOsettings.LANG == "RU")
        {
            lang_male_gender = "Мужской";
            lang_female_gender = "Женский";

            lang_broPersonality_0 = "Милый";
            lang_broPersonality_1 = "ОЯШ";
            lang_broPersonality_2 = "Психопат";
            lang_broPersonality_0txt = "Миленький. Бонус к подчинению.";
            lang_broPersonality_1txt = "Обычный. Равноценные бонусы к доминации/подчинению.";
            lang_broPersonality_2txt = "Грубый. Бонус к доминации.";

            lang_sisPersonality_0 = "Моэ";
            lang_sisPersonality_1 = "Цундере";
            lang_sisPersonality_2 = "Яндере";
            lang_sisPersonality_0txt = "Миленькая. Бонус к подчинению.";
            lang_sisPersonality_1txt = "Капризная. Равноценные бонусы к доминации/подчинению.";
            lang_sisPersonality_2txt = "Стерва-психопатка. Бонус к доминации.";
        }

        if (MMOsettings.LANG == "EN")
        {
            lang_male_gender = "Male";
            lang_female_gender = "Female";

            lang_broPersonality_0 = "Cute";
            lang_broPersonality_1 = "Normal";
            lang_broPersonality_2 = "Psycho";
            lang_broPersonality_0txt = "Cute. Bonus for submission.";
            lang_broPersonality_1txt = "Normal. Equivalent bonuses to the domination /  submission.";
            lang_broPersonality_2txt = "Rude. Bonus domination.";

            lang_sisPersonality_0 = "Cute";
            lang_sisPersonality_1 = "Tsundere";
            lang_sisPersonality_2 = "Yandere";
            lang_sisPersonality_0txt = "Cute. Bonus for submission.";
            lang_sisPersonality_1txt = "Capricious. Equivalent bonuses to the domination /  submission.";
            lang_sisPersonality_2txt = "Bitch-psychopath. Bonus domination.";
        }

        createPAN.SetActive(true);
        heroCreatePAN.SetActive(true);
        familyCreatePAN.SetActive(false);
        nextBTN.SetActive(false);
        familyCreate.SetActive(false);
        createBTN.SetActive(false);
        hairchangePAN.SetActive(false);

        genderTXT.GetComponent<Text>().text = lang_male_gender;

        //ВАШ ПОРТРЕТ
        Image tstIMG = imageAvi.GetComponent<Image>();
        tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
    }

    //ввод имени
    public void GetInputName(string name)
    {
        Debug.Log("ВАШЕ ИМЯ" + name);
        MMOsettings.mmoName = name;
        if (MMOsettings.mmoName != "")
        {
            nextBTN.SetActive(true);
        }
    }

    //+смена пола
    public void GenderPLUS()
    {
      MMOsettings.mmoGenderNUM++;
        if (MMOsettings.mmoGenderNUM > 1) { MMOsettings.mmoGenderNUM = 0; }
        //Муж
        if (MMOsettings.mmoGenderNUM == 0)
        {          
            genderTXT.GetComponent<Text>().text = lang_male_gender;
            MMOsettings.mmoGender = "male";
            MMOsettings.mmoHairColor = "dark";
            MMOsettings.mmoHarirColorNUM = 0;
            MMOsettings.mmoHeroPICnum = 0;
            hairchangePAN.SetActive(false);
            //ВАШ ПОРТРЕТ
            Image tstIMG = imageAvi.GetComponent<Image>();
            tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
        }

        //Жен
        if (MMOsettings.mmoGenderNUM == 1)
        { 
            genderTXT.GetComponent<Text>().text = lang_female_gender;
            MMOsettings.mmoGender = "female";
            MMOsettings.mmoHairColor = "dark";
            MMOsettings.mmoHarirColorNUM = 0;
            MMOsettings.mmoHeroPICnum = 0;
            hairchangePAN.SetActive(true);
            hairchange.GetComponent<Image>().color = new Color32(68, 68, 68, 255);
            //ВАШ ПОРТРЕТ
            Image tstIMG = imageAvi.GetComponent<Image>();
            tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
        }
    }
    //-смена пола
    public void GenderMINUS()
    {
        MMOsettings.mmoGenderNUM--;
        if (MMOsettings.mmoGenderNUM < 0) { MMOsettings.mmoGenderNUM = 1; }
        //Муж
        if (MMOsettings.mmoGenderNUM == 0)
        {
            genderTXT.GetComponent<Text>().text = lang_male_gender;
            MMOsettings.mmoGender = "male";
            MMOsettings.mmoHairColor = "dark";
            MMOsettings.mmoHarirColorNUM = 0;            
            MMOsettings.mmoHeroPICnum = 0;
            hairchangePAN.SetActive(false);
            //ВАШ ПОРТРЕТ
            Image tstIMG = imageAvi.GetComponent<Image>();
            tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
        }

        //Жен
        if (MMOsettings.mmoGenderNUM == 1)
        {
            genderTXT.GetComponent<Text>().text = lang_female_gender;
            MMOsettings.mmoGender = "female";
            MMOsettings.mmoHairColor = "dark";
            MMOsettings.mmoHarirColorNUM = 0;
            MMOsettings.mmoHeroPICnum = 0;
            hairchangePAN.SetActive(true);
            hairchange.GetComponent<Image>().color = new Color32(68, 68, 68, 255);
            //ВАШ ПОРТРЕТ
            Image tstIMG = imageAvi.GetComponent<Image>();
            tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
        }
    }




    //+цвет волос
    public void HairPLUS()
    {
        MMOsettings.mmoHarirColorNUM++;
        if (MMOsettings.mmoHarirColorNUM > 1) { MMOsettings.mmoHarirColorNUM = 0; }
        //черный
        if (MMOsettings.mmoHarirColorNUM == 0)
        {
            hairchange.GetComponent<Image>().color = new Color32(68, 68, 68, 255);
            MMOsettings.mmoHairColor = "dark";
            //ВАШ ПОРТРЕТ
            Image tstIMG = imageAvi.GetComponent<Image>();
            tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
        }

        //блонда
        if (MMOsettings.mmoHarirColorNUM == 1)
        {
            hairchange.GetComponent<Image>().color = new Color32(218, 218, 218, 255);
            MMOsettings.mmoHairColor = "blonde";
            //ВАШ ПОРТРЕТ
            Image tstIMG = imageAvi.GetComponent<Image>();
            tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
        }
    }


    public void HairMinus()
    {
        MMOsettings.mmoHarirColorNUM--;
        if (MMOsettings.mmoHarirColorNUM < 0) { MMOsettings.mmoHarirColorNUM = 1; }
        //черный
        if (MMOsettings.mmoHarirColorNUM == 0)
        {
            hairchange.GetComponent<Image>().color = new Color32(68, 68, 68, 255);
            MMOsettings.mmoHairColor = "dark";
            //ВАШ ПОРТРЕТ
            Image tstIMG = imageAvi.GetComponent<Image>();
            tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
        }

        //блонда
        if (MMOsettings.mmoHarirColorNUM == 1)
        {
            hairchange.GetComponent<Image>().color = new Color32(218, 218, 218, 255);
            MMOsettings.mmoHairColor = "blonde";
            //ВАШ ПОРТРЕТ
            Image tstIMG = imageAvi.GetComponent<Image>();
            tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
        }
    }


    //+портрет
    public void AviPlus()
    {

        MMOsettings.mmoHeroPICnum++;
        if (MMOsettings.mmoHeroPICnum > 9) { MMOsettings.mmoHeroPICnum = 0; }

        //ВАШ ПОРТРЕТ
        Image tstIMG = imageAvi.GetComponent<Image>();
        tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
    }
    public void AviMinus()
    {
        MMOsettings.mmoHeroPICnum--;
        if (MMOsettings.mmoHeroPICnum < 0) { MMOsettings.mmoHeroPICnum = 9; }

        //ВАШ ПОРТРЕТ
        Image tstIMG = imageAvi.GetComponent<Image>();
        tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);
    }

    //+брат
    public void addbrother()
    {
        if (broToggle.isOn == false) {Family.brother = false; broPAN.SetActive(false); }
        if (broToggle.isOn == true) { Family.brother = true; broPAN.SetActive(true); }

    }

    //+сестра
    public void addsister()
    {
        if (sisToggle.isOn == false) { Family.sister = false; sisPAN.SetActive(false); }
        if (sisToggle.isOn == true) { Family.sister = true; sisPAN.SetActive(true); }

    }

    //+характер брата
    public void brotherPersonalityPLUS()
    {
        Family.broPersonality ++;
        if (Family.broPersonality > 2) { Family.broPersonality = 0; }
        if (Family.broPersonality == 0)
        {
            //характер брата
            broPersonality.GetComponent<Text>().text = lang_broPersonality_0;
            broPersonalityTXT.GetComponent<Text>().text = lang_broPersonality_0txt;
        }
        if (Family.broPersonality == 1)
        {
            broPersonality.GetComponent<Text>().text = lang_broPersonality_1;
            broPersonalityTXT.GetComponent<Text>().text = lang_broPersonality_1txt;
        }
        if (Family.broPersonality == 2)
        {
            broPersonality.GetComponent<Text>().text = lang_broPersonality_2;
            broPersonalityTXT.GetComponent<Text>().text = lang_broPersonality_2txt;
        }

    }

    //-характер брата
    public void brotherPersonalityMINUS()
    {
        Family.broPersonality--;
        if (Family.broPersonality < 0) { Family.broPersonality = 2; }
        if (Family.broPersonality == 0)
        {
            //характер брата
            broPersonality.GetComponent<Text>().text = lang_broPersonality_0;
            broPersonalityTXT.GetComponent<Text>().text = lang_broPersonality_0txt;
        }
        if (Family.broPersonality == 1)
        {
            broPersonality.GetComponent<Text>().text = lang_broPersonality_1;
            broPersonalityTXT.GetComponent<Text>().text = lang_broPersonality_1txt;
        }
        if (Family.broPersonality == 2)
        {
            broPersonality.GetComponent<Text>().text = lang_broPersonality_2;
            broPersonalityTXT.GetComponent<Text>().text = lang_broPersonality_2txt;
        }

    }

    //+характер сестра
    public void sisterPersonalityPLUS()
    {
        Family.sisPersonality++;
        if (Family.sisPersonality > 2) { Family.sisPersonality = 0; }
        if (Family.sisPersonality == 0)
        {
            //характер брата
            sisPersonality.GetComponent<Text>().text = lang_sisPersonality_0;
            sisPersonalityTXT.GetComponent<Text>().text = lang_sisPersonality_0txt;
        }
        if (Family.sisPersonality == 1)
        {
            sisPersonality.GetComponent<Text>().text = lang_sisPersonality_1;
            sisPersonalityTXT.GetComponent<Text>().text = lang_sisPersonality_1txt;
        }
        if (Family.sisPersonality == 2)
        {
            sisPersonality.GetComponent<Text>().text = lang_sisPersonality_2;
            sisPersonalityTXT.GetComponent<Text>().text = lang_sisPersonality_2txt;
        }

    }

    //-характер сестра
    public void sisterPersonalityMINUS()
    {
        Family.sisPersonality--;
        if (Family.sisPersonality < 0) { Family.sisPersonality = 2; }
        if (Family.sisPersonality == 0)
        {
            //характер брата
            sisPersonality.GetComponent<Text>().text = lang_sisPersonality_0;
            sisPersonalityTXT.GetComponent<Text>().text = lang_sisPersonality_0txt;
        }
        if (Family.sisPersonality == 1)
        {
            sisPersonality.GetComponent<Text>().text = lang_sisPersonality_1;
            sisPersonalityTXT.GetComponent<Text>().text = lang_sisPersonality_1txt;
        }
        if (Family.sisPersonality == 2)
        {
            sisPersonality.GetComponent<Text>().text = lang_sisPersonality_2;
            sisPersonalityTXT.GetComponent<Text>().text = lang_sisPersonality_2txt;
        }

    }


    //ФИНИШ
    public void closeANDsaveHero()
    {
        SaveHero.SaveHeroes();

        startingScreen.SetActive(true);
        createPAN.SetActive(false);
        createBTN.SetActive(true);
    }


}
