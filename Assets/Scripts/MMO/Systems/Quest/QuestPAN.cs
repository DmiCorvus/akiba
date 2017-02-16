using UnityEngine;
using System.Collections;

public class QuestPAN : MonoBehaviour {

    public static string questcreator = "";

    public static bool destroyALLquest; //уничтожить все квесты
    public static int questcounterALL; //считаем все квесты


    //0- не взят 
    //single - Одиночный

    //квесты Маркуса
    public static int markus_havequest = 0; //у маркуса есть квесты
    public static bool markus_readyaccept = false; //готовы к началу квеста
    //public static bool markus_questgived = false; //уже выполняем

    //СИНГЛ
    //1кв  
    public static int single_Markus_starting = 0;              //0 - не взят 1 взят 2 выполнен
    public static int single_Markus_starting_phase = 0;       //фаза квеста
    public static string single_Markus_starting_phasetxt = ""; //прогресс квеста

    //ММО
    //1кв
    public static int mmo_Markus_starting = 0;             //0 - не взят 1 взят 2 выполнен
    public static int mmo_Markus_starting_phase = 0;       //фаза квеста
    public static string mmo_Markus_starting_phasetxt = ""; //прогресс квеста

    



    //список квестов
    void OnEnable()
    {
        destroyALLquest = false;
        questcounterALL = 0;


        //ДЕФОЛТ СТАРТ
        //дефолт маркус
        markus_readyaccept = false; //готовы к началу квеста
        //дефолт ММО
        if (MMOsettings.singleGame == false) { markus_havequest = 1; }//у маркуса есть квесты
        //дефолт СИНГЛ
        if (MMOsettings.singleGame == true) { markus_havequest = 0; }//у маркуса есть квесты

        //ОДИНОЧНАЯ
        //маркус1квест
        single_Markus_starting = 0;
        single_Markus_starting_phase = 0;
        single_Markus_starting_phasetxt = "";

        //ММО
        //маркус1квест
        mmo_Markus_starting = 0;
        mmo_Markus_starting_phase = 0;       
        mmo_Markus_starting_phasetxt = "";






    }






    //ОТКРЫТЬ ЖУРНАЛ
    public void OpenQuestPAN()
    {
        UIactive.questPAN.SetActive(true);

        UIactive.questActivePAN.SetActive(true);
        UIactive.questEndedPAN.SetActive(false);
        
    }

    //ЗАКРЫТЬ
    public void CloseQuestPAN()
    {
        UIactive.questPAN.SetActive(false);
    }

    //АКТИВНЫЕ КВЕСТЫ
    public void ActiveQuestPAN()
    {
        UIactive.questActivePAN.SetActive(true);
        UIactive.questEndedPAN.SetActive(false);
    }

    //ЗАВЕРШЕННЫЕ КВЕСТЫ
    public void EndedQuestPAN()
    {
        UIactive.questActivePAN.SetActive(false);
        UIactive.questEndedPAN.SetActive(true);
    }
}
