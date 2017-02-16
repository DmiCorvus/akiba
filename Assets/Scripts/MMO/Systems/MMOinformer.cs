using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MMOinformer : MonoBehaviour {

    public static GameObject infoMSGtext;

    public static GameObject IMbtnsFormTXT;
    public static GameObject IMacceptBTN;
    public static GameObject IMcancelBTN;

    public static string IMtypeBTNaccept;
    public static string IMtypeBTNcancel;

    public bool settingsComplete = false;

    void OnEnable()
    {
        if (settingsComplete == false)
        {

            infoMSGtext = GameObject.Find("infoTXT");

            //поле принятия решений
            IMbtnsFormTXT = GameObject.Find("IMbtnsFormTXT");
            IMacceptBTN = GameObject.Find("IMacceptBTN");
            IMcancelBTN = GameObject.Find("IMcancelBTN");
            settingsComplete = true;

        }


        IMbtnsFormTXT.SetActive(false);


    }


    ///ACCEPT BTN
    ///
    public  void IMaccept()
    {
        if (IMtypeBTNaccept == "acceptGroup")    {         MMOteamFIND.EnterGroup();     }
        //

        else  if (IMtypeBTNaccept == "acceptInvite")   {         MeetingsSETTINGS.acceptInvite();   }
        //
    }





    ///CANCEL BTN
    ///
    public  void IMcancel()
    {
        //
        if (IMtypeBTNcancel == "cancelGroup")    {  MMOteamFIND.CancelGroup();     }      //

        //
        else  if (IMtypeBTNcancel == "cancelInvite")   {        MeetingsSETTINGS.cancelInvite();    }      //

    }



}
