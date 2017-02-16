using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ПРИКРЕПЛЕНО К ВИНДФОРМ
//ОПИСАНИЕ ДИНАМИЧЕСКАЯ СМЕНА ЛОКАЦИИ ПО ВРЕМЕНИ
public class daycycle_loc : MonoBehaviour {


    public static string loc_DayCycle_name; //название локации сменяемой по времени
    public static bool needDayCycle;

   public static void DayCyclePIC ()
    { if (needDayCycle == true)  {MMOstart.SceneIMG.sprite = Resources.Load<Sprite>(loc_DayCycle_name+ MainTime.MTDayCycle);   }     }
}
