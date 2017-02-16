using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//ПРИКРЕПЛЕН - К КВЕСТУ В ЖУРНАЛЕ
//ОПИСАНИЕ служит для вывода текст инфы квеста

public class QuestBTN : MonoBehaviour {

    public GameObject questTXTinf;      //ПОЛЕ ОПИСАНИЯ КВЕСТА
    public GameObject questTXTprogress; //ПОЛЕ ПРОГРЕССА КВЕСТА

    private string questNAME; //ИМЯ КВЕСТА


    //ПАРАМЕТРЫ ПРИ СОЗДАНИИ КВЕСТА
    void Awake () {
            questNAME = QuestPAN.questcreator;
            QuestPAN.questcounterALL += 1;
            QuestPAN.questcreator = "";
    }
	
    //ПАРАМЕТРЫ ТЕКСТОВ
    void OnGUI()
    {

        //СИНГЛ КВЕСТЫ
        //starting маркус1
        if (questNAME == "QC:npc_markus_singlestarting")
        {
            questTXTinf.GetComponent<Text>().text = "<b>ПОЕХАЛИ!!!</b> - генерал Маркус с планеты Земля поручил вам нанять пилота и провести проверку систем корабля в космосе.";
            questTXTprogress.GetComponent<Text>().text = QuestPAN.single_Markus_starting_phasetxt;
        }
        //ending
        //СИНГЛ ЭНД



        //ММО КВЕСТЫ
        //starting маркус1
        if (questNAME == "QC:npc_markus_mmostarting")
        {
            questTXTinf.GetComponent<Text>().text = "<b>ПОЕХАЛИ!!!</b> - генерал Маркус с планеты Земля поручил вам познакомиться с экипажем и провести проверку систем корабля в космосе.";
            questTXTprogress.GetComponent<Text>().text = QuestPAN.mmo_Markus_starting_phasetxt;
        }
        //ending

    }






    //МИНУС КВЕСТ
    void OnDestroy()
    {
        QuestPAN.questcounterALL -= 1; 
    }
	

    //ОБНОВЛЕНИЯ В РЕАЛЬНОМ ВРЕМЕНИ
	void Update ()
    {
        //уничтожить ВСЁ
        if (QuestPAN.destroyALLquest == true) { Destroy(gameObject); }
    }
}
