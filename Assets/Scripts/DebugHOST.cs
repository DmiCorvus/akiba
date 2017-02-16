using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TNet;

public class DebugHOST : MonoBehaviour {
    public GameObject debugID;
    public GameObject debugOnline;
    int Online;

    public GameObject debugGenderSave;

    //public GameObject[] plSLOTS = new GameObject[10];

    void Update()
    {
        Online = TNManager.GetChannelData<int>("yourNewPlayer" + MMOsettings.uniqueIDget);
    }

    // Update is called once per frame
    void OnGUI () {
        debugID.GetComponent<Text>().text = ""+ MMOsettings.uniqueIDget;
        debugOnline.GetComponent<Text>().text = "" + Online;

        debugGenderSave.GetComponent<Text>().text = "" + SaveHero.saveGenderHero;
    }

    public void refresh()
    {
        MMOplayerlist.clearYou = true;
    }
}
