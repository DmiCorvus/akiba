using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MMOcreate2 : MonoBehaviour {

    public Text nameHeroField;


    public GameObject playerImage;

    //выбор класса
    public GameObject[] classSelect = new GameObject[3];
    //девственность
    public Toggle virginToggle;

    public void OnEnable()
    {
        nameHeroField.GetComponent<Text>().text = MMOsettings.mmoName;

        //ВАШ ПОРТРЕТ
        Image tstIMG;
        tstIMG = playerImage.GetComponent<Image>();
        //установка портретов
        tstIMG.sprite = Resources.Load<Sprite>("MMO/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);

    }


    //девственность
    public void virginCHK()
    {

    }



    }
