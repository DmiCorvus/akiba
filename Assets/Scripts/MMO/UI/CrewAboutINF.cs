using UnityEngine;
using System.Collections;

//Прикреплен ЮИ СИС
//ОПИСАНИЕ общая карточка экипажа
public class CrewAboutINF : MonoBehaviour {

    //ОТКРЫТЬ 
    public void OpenCrewsAboutPAN()
    {
        UIactive.CrewsAboutPAN.SetActive(true);
    }

    //ЗАКРЫТЬ
    public void CloseCrewsAboutPAN()
    {
        UIactive.CrewsAboutPAN.SetActive(false);
    }
}
