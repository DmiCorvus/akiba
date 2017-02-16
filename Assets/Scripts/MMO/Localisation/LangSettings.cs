using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangSettings : MonoBehaviour {

    //языки
    public GameObject enlang;
    public GameObject rulang;

    void OnEnable()
    {
        //панель языков
        if (MMOsettings.LANG == "RU")
        {
            enlang.SetActive(false);
            rulang.SetActive(true);
        }
        if (MMOsettings.LANG == "EN")
        {
            enlang.SetActive(true);
            rulang.SetActive(false);
        }

    }

}
