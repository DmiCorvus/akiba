using UnityEngine;
using System.Collections;
using TNet;
using UnityEngine.UI;

public class MMOChat : MonoBehaviour {

    public GameObject ChatText1Field;
    public GameObject ChatText2Field;
    public GameObject ChatText3Field;

    public GameObject ChatPanel;

    private float startTime;
    private bool timmerON;

    //счетчик сообщений
    public int counterMSG;

    //поле ввода
    [SerializeField]
    private InputField input;

    // отрисовываем чат при старте
    void OnEnable() {

        startTime = Time.time;
        timmerON = false;

        counterMSG = TNManager.GetChannelData<int>("ChatCountMSG");

        //1слот
        string GetChat1Text;
        GetChat1Text = TNManager.GetChannelData<string>("ChatText1Content");
        ChatText1Field.GetComponent<Text>().text = GetChat1Text;

        //2слот
        string GetChat2Text;
        GetChat2Text = TNManager.GetChannelData<string>("ChatText2Content");
        ChatText2Field.GetComponent<Text>().text = GetChat2Text;

        //3слот
        string GetChat3Text;
        GetChat3Text = TNManager.GetChannelData<string>("ChatText3Content");
        ChatText3Field.GetComponent<Text>().text = GetChat3Text;



    }

    // отрисовываем чат при обновлениях
    void Update () {

        //TIMER
        if (timmerON == true)
        {
            float t = Time.time - startTime;
            ChatPanel.SetActive(true);
            if (t >= 7)
            {
                ChatPanel.SetActive(false);
                timmerON = false;
            }
        }


        int chkNewMSG;
        chkNewMSG = TNManager.GetChannelData<int>("ChatCountMSG");

        //если появились новые сообщения
        if (chkNewMSG != counterMSG)
        {
            counterMSG = chkNewMSG;
            //рисуем
            //1слот
            string GetChat1Text;
            GetChat1Text = TNManager.GetChannelData<string>("ChatText1Content");
            ChatText1Field.GetComponent<Text>().text = GetChat1Text;

            //2слот
            string GetChat2Text;
            GetChat2Text = TNManager.GetChannelData<string>("ChatText2Content");
            ChatText2Field.GetComponent<Text>().text = GetChat2Text;

            //3слот
            string GetChat3Text;
            GetChat3Text = TNManager.GetChannelData<string>("ChatText3Content");
            ChatText3Field.GetComponent<Text>().text = GetChat3Text;
            //подсвечиваем чат
            timmerON = true;
            startTime = Time.time;

        }

       


    }

    //поле ввода
    public void GetInputText(string addText)
    {

        //формируем текстовое поле
        string MSGcreater;
        MSGcreater = MMOsettings.mmoName + ": "+ addText;
        print(MSGcreater);

        if (addText != "")
        {
            TNManager.SetChannelData("ChatTextNEWContent", MSGcreater);

            //задаем параметры для отрисовки
            int counterMSGReWrite;
            counterMSGReWrite = counterMSG + 1;
            TNManager.SetChannelData("ChatCountMSG", counterMSGReWrite);

            //передаем данные
            //3 слот = 2
            string GetChat2Text;
            GetChat2Text = TNManager.GetChannelData<string>("ChatText2Content");
            TNManager.SetChannelData("ChatText3Content", GetChat2Text);
            //2 слот = 1
            string GetChat1Text;
            GetChat1Text = TNManager.GetChannelData<string>("ChatText1Content");
            TNManager.SetChannelData("ChatText2Content", GetChat1Text);
            //1 слот = новому контенту
            string GetChatNew;
            GetChatNew = TNManager.GetChannelData<string>("ChatTextNEWContent");
            TNManager.SetChannelData("ChatText1Content", GetChatNew);


        }



        //очищаем поле
        input.text = "";
    }

    //подсветка чата при вводе
    public void OnGUI()
    {
        //фокус чата     
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("WOW");
            input.ActivateInputField();
            input.Select();

            //подсвечиваем чат
            timmerON = true;
            startTime = Time.time;
        }

    }

}
