using UnityEngine;
using System.Collections;

public class GroupAboutINF : MonoBehaviour {

    //ОТКРЫТЬ 
    public void OpenGroupAboutPAN()
    {
        UIactive.GroupAboutPAN.SetActive(true);
    }

    //ЗАКРЫТЬ
    public void CloseGroupAboutPAN()
    {
        UIactive.GroupAboutPAN.SetActive(false);
    }


}
