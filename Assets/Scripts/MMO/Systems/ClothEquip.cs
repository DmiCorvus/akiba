using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ПРИКРЕПЛЕН к ММОГЕЙМ
//ОПИСАНИЕ подбор одежды

public class ClothEquip : MonoBehaviour {

    public static GameObject ClothEquipPAN; //панель экипировки



	void Awake () {
        ClothEquipPAN = GameObject.Find("ClothChoose");
    }
	
	
	void OnEnable () {
        ClothEquipPAN.SetActive(false);
    }

    //открыть
   public static void ClothEquipPANopen()
    {
        ClothEquipPAN.SetActive(true);
    }
    //закрыть
   public void ClothEquipPANclose()
    {
        ClothEquipPAN.SetActive(false);
    }
}
