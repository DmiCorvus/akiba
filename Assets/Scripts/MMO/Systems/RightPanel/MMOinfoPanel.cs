using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MMOinfoPanel : MonoBehaviour {

    public Text mmoIPplayerName;
    public GameObject mmoIPplayeImage;
    public GameObject aboutPlayerPan;


    //при активации
    void OnEnable () {
        //вписываем имя
        mmoIPplayerName.GetComponent<Text>().text = MMOsettings.mmoName;

        //ВАШ ПОРТРЕТ
        Image tstIMG;
        tstIMG = mmoIPplayeImage.GetComponent<Image>();
        tstIMG.sprite = Resources.Load<Sprite>("IMG/heroes/" + MMOsettings.mmoGender + "/" + MMOsettings.mmoHairColor + "/" + MMOsettings.mmoHeroPICnum);


        //отключаем поля
       // aboutPlayerPan.SetActive(false);

        //включаем поля
        aboutPlayerPan.SetActive(true);
    }




}
