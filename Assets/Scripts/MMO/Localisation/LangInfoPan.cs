using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LangInfoPan : MonoBehaviour {

    //правая панель
    public Text inventoryBTN;
    public Text familyBTN;
    public Text journalBTN;
    public Text aboutBTN;
    public Text groupBTN;
    public Text phoneBTN;

    public Text moneyTXT;
    public Text dateTXT;


    void OnEnable () {

       if(LangMAIN.LangActive == true)
        {
            //РУССКИЙ
            if (MMOsettings.LANG == "RU")
            {
                //правая панель
                inventoryBTN.GetComponent<Text>().text = "Инвентарь";
                familyBTN.GetComponent<Text>().text = "Семья";
                journalBTN.GetComponent<Text>().text = "Журнал";
                aboutBTN.GetComponent<Text>().text = "Об игре";
                groupBTN.GetComponent<Text>().text = "Группа";
                phoneBTN.GetComponent<Text>().text = "Телефон:";
                moneyTXT.GetComponent<Text>().text = "Деньги:";
                dateTXT.GetComponent<Text>().text = "Дата и время:";
            }





            //ENGLISH
            if (MMOsettings.LANG == "EN")
            {
                //правая панель
                inventoryBTN.GetComponent<Text>().text = "Inventory";
                familyBTN.GetComponent<Text>().text = "Family";
                journalBTN.GetComponent<Text>().text = "Journal";
                aboutBTN.GetComponent<Text>().text = "About game";
                groupBTN.GetComponent<Text>().text = "Group";
                phoneBTN.GetComponent<Text>().text = "Phone:";
                moneyTXT.GetComponent<Text>().text = "Money:";
                dateTXT.GetComponent<Text>().text = "Date and time:";
            }


            gameObject.SetActive(false);





        }

    }
}
