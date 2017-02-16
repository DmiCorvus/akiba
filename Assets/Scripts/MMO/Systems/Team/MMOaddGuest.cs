using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TNet;


//ЗАПРОС НА ПРИГЛАШЕНИЕ В ГОСТИ
public class MMOaddGuest : MonoBehaviour {


    public static void SendGuest()
    {
        //первым делом проверяем в группе ли мы
        if (MMOsettings.mmoGroup == 1)
        {

            //Последовательно проверям слоты группы
            for (int i = 1; i <= 4; i++)
            {


                if ((MMOsettings.mmoGroupSlot[i] == "USED") && (MMOsettings.mmoGroupCurrentSlot != i))
                {
                    //получаем имя
                 //   string tmpNAME;
                //    tmpNAME= TNManager.GetChannelData<string>("yourServerName" + MMOsettings.mmoGroupID[i]);

                //мужики не приглашают мужиков
                if((MMOsettings.mmoGender == "male")&&(MMOsettings.mmoGroupGender[i] == "male")){    }


                else 
                    print("действие с кнопкой" + i +" Имя "+ MMOsettings.mmoGroupNames[i]);
                    //создаем кнопку
                    //активируем кнопки 
                    MMOstart.actionBTS[i].SetActive(true);
                    //называем кнопку
                    MMOstart.actionBTStxt[i].GetComponent<Text>().text = "Пригласить " + MMOsettings.mmoGroupNames[i];
                    //назначаем действие кнопки 
                    //MMOstart.actionBTScommand[i] = "roomMeeting"+i;
                }

            }



        }

    }


}
