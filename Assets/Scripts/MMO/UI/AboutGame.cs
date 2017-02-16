using UnityEngine;
using System.Collections;

public class AboutGame : MonoBehaviour {

    //ОТКРЫТЬ 
    public void OpenAboutPAN()
    {
        UIactive.aboutPAN.SetActive(true);
    }

    //ЗАКРЫТЬ
    public void CloseAboutPAN()
    {
        UIactive.aboutPAN.SetActive(false);
    }
}
