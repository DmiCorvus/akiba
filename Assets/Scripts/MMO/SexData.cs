using UnityEngine;
using System.Collections;

//ПРИКРЕПЛЕН К ММО
//ОПИСАНИЕ: содержит инфу о ваших секс сценах

public class SexData : MonoBehaviour {

    public static bool earth_npc_drinkerscene = false; //был секс с пьяницей


    void OnEnable()
    {
        earth_npc_drinkerscene = false;

    }


}
