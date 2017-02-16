using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//ПРИРКПЛЕН ИНФО ПАНЕЛЬ PHONE
public class Phone : MonoBehaviour {

    public static GameObject ppdiag_PAN;
    public static GameObject ppsms_PAN;
    public static GameObject ppsettings_PAN;
    public static GameObject ppbrowser_PAN;

    //settings phone
    public static int ppset_wallsnum;//номер обоев
    public static GameObject ppwallsslot;//обои
    public static GameObject ppwallsslot_SET;//обои установка

    void Awake()
    {
        ppdiag_PAN = GameObject.Find("PPdial_PAN");
        ppsms_PAN = GameObject.Find("PPsms_PAN");
        ppsettings_PAN = GameObject.Find("PPsettings_PAN");
        ppbrowser_PAN = GameObject.Find("PPbrowser_PAN");
        ppwallsslot = GameObject.Find("PPstart_screen");
        ppwallsslot_SET = GameObject.Find("PPwallsNameText");
    }
    void OnEnable()
    {
        ppdiag_PAN.SetActive(false);
        ppsms_PAN.SetActive(false);
        ppsettings_PAN.SetActive(false);
        ppbrowser_PAN.SetActive(false);
    }

    //ОТКРЫТЬ ТЕЛЕФОН
    public void phoneOPEN () {
        UIactive.phone.SetActive(true);
        Image tstIMG = ppwallsslot.GetComponent<Image>();
        tstIMG.sprite = Resources.Load<Sprite>("IMG/UI/Phone/phone_wall" + ppset_wallsnum);
    }

    public void phoneCLOSE()
    {
        closeALL();
        UIactive.phone.SetActive(false);
    }

    //РАБОЧИЙ СТОЛ
    public void closeALL()
    {
        ppdiag_PAN.SetActive(false);
        ppsms_PAN.SetActive(false);
        ppsettings_PAN.SetActive(false);
        ppbrowser_PAN.SetActive(false);
        Image tstIMG = ppwallsslot.GetComponent<Image>();
        tstIMG.sprite = Resources.Load<Sprite>("IMG/UI/Phone/phone_wall" + ppset_wallsnum);
    }

    //ОТКРЫТЬ ЗВОНИЛКУ
    public void phoneDialOPEN()
    {   closeALL();
        ppdiag_PAN.SetActive(true);
    }

    //ОТКРЫТЬ SMS
    public void phoneSMSOPEN()
    {
        closeALL();
        ppsms_PAN.SetActive(true);
    }

    //ОТКРЫТЬ НАСТРОЙКИ
    public void phoneSetOPEN()
    {
        closeALL();
        ppsettings_PAN.SetActive(true);
    }

    //ОТКРЫТЬ БРАУЗЕР
    public void phoneBrowserOPEN()
    {
        closeALL();
        ppbrowser_PAN.SetActive(true);
    }




    //НАСТРОЙКИ ТЕЛЕФОНА
    //обои
    public void phoneWallPLUS()
    {
        ppset_wallsnum++;
        if (ppset_wallsnum > 4) { ppset_wallsnum = 0; }
        ppwallsslot_SET.GetComponent<Text>().text = "wall"+ ppset_wallsnum;
    }


    public void phoneWallMINUS()
    {
        ppset_wallsnum--;
        if (ppset_wallsnum < 0) { ppset_wallsnum = 4; }
        ppwallsslot_SET.GetComponent<Text>().text = "wall" + ppset_wallsnum;
    }

}
