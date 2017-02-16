using UnityEngine;
using System.Collections;

public class lobbyBTN : MonoBehaviour {

   
    public GameObject startPan;


    public GameObject singlePan;

    public GameObject lobby;

    public GameObject mmoPan;
    public GameObject serverChoose;
    public GameObject heroList;

    public GameObject exitGamePan;//панель выхода из игры
    public GameObject MMOgamePan;
    
    

    //MMO
    public void mmoPanelON()
    {
        mmoPan.SetActive(true);
        heroList.SetActive(false);
        serverChoose.SetActive(true);
        startPan.SetActive(false);
    }
    public void mmoPanelOFF()
    {
        mmoPan.SetActive(false);
        serverChoose.SetActive(false);
        heroList.SetActive(false); 
        startPan.SetActive(true);
    }
    //CONNECT
    public void ConnctingHeroList()
    {
        serverChoose.SetActive(false);
        heroList.SetActive(true);
    }
    //
    public void singlePanelON()
    {
        singlePan.SetActive(true);
        startPan.SetActive(false);
    }
    public void singlePanelOFF()
    {
        singlePan.SetActive(false);
        startPan.SetActive(true);
    }


    //SINGLE GAME START
    public void startSingleGO()
    {
        //disconnect
        singlePan.SetActive(false);
        mmoPan.SetActive(false);
        lobby.SetActive(false);
   
        UIactive.AudioLobby.SetActive(false);
        UIactive.downPan.SetActive(false);
        UIactive.lobbyIMAGE.SetActive(false);
        MMOsettings.singleGame = true;
        MMOgamePan.SetActive(true);  
    }

    //MMO GAME START
    public void startMMOGO()
    {
        singlePan.SetActive(false);
        mmoPan.SetActive(false);
        lobby.SetActive(false);

        UIactive.AudioLobby.SetActive(false);
        UIactive.downPan.SetActive(false);
        UIactive.lobbyIMAGE.SetActive(false);
        MMOsettings.singleGame = false;
        MMOgamePan.SetActive(true);
    }

    //ПАНЕЛЬ ВЫХОДА ИЗ ИГРЫ
    public void ExitPanelON()
    {
        exitGamePan.SetActive(true);

    }
    public void ExitPanelOFF()
    {
        exitGamePan.SetActive(false);

    }
    //выход
    public void ExitGame()
    {
        Application.Quit();
    }

}
