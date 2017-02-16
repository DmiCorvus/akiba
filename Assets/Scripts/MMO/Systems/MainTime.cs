using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//ПРИКРЕПЛЕН К РАЙТ ПАНЕЛЬ
//ВРЕМЯ В ИГРЕ
public class MainTime : MonoBehaviour {

    public static int MTDayCycle; //1 день 1 вечер 2 ночь 0 утро
   
    public static int MTDayWeek; //ДЕНЬ недели 0 - Пнд
    public static string MTDayWeekTXT; //ДЕНЬ недели
    public GameObject MTDayWeekSlot;

    public static int MThour; //ЧАС
    public GameObject MThourSlot;


    //ТАЙМЕР
    public static float startTimer;
    public static int intTime;

    //ВПИСЫВАЕМ В СЛОТЫ


    void OnEnable()
    {
        //дефолт время
        MTDayCycle = 0; //утро

        if (MMOsettings.LANG =="RU") MTDayWeekTXT = "Понедельник";
        if (MMOsettings.LANG == "EN") MTDayWeekTXT = "Monday";

        MTDayWeek = 0;
        MThour = 11;

        //Таймер смены времени
        startTimer = 10;
        intTime = 10;

        MThourSlot.GetComponent<Text>().text = MThour + ":00";
        MTDayWeekSlot.GetComponent<Text>().text = MTDayWeekTXT;

    }
	
	
	void Update () {
       
       //ТАЙМЕР ИДЕТ
        if (intTime > 0)
        {
            startTimer -= Time.deltaTime;
            intTime = (int)startTimer;

        }


        if (intTime == 0)
        {
            intTime = 10;
            startTimer = 10;

            MThour += 1; //+1 час
            if (MThour >= 24) { MThour = 0; }

            //+1 время суток
            if ((MThour == 12)||(MThour == 18) ||(MThour == 0) || (MThour == 6))
            {   MTDayCycle ++;                
                if (MTDayCycle >= 4) { MTDayCycle = 0; }
                daycycle_loc.DayCyclePIC();
            }
            //+1день
            if (MThour == 0)
            {
                MTDayWeek++;
                if (MTDayWeek >= 7) { MTDayWeek = 0; }

                if (MTDayWeek == 0)
                {
                    if (MMOsettings.LANG == "RU") MTDayWeekTXT = "Понедельник";
                    if (MMOsettings.LANG == "EN") MTDayWeekTXT = "Monday";
                }

                if (MTDayWeek == 1)
                {
                    if (MMOsettings.LANG == "RU") MTDayWeekTXT = "Вторник";
                    if (MMOsettings.LANG == "EN") MTDayWeekTXT = "Tuesday";
                }

                if (MTDayWeek == 2)
                {
                    if (MMOsettings.LANG == "RU") MTDayWeekTXT = "Среда";
                    if (MMOsettings.LANG == "EN") MTDayWeekTXT = "Wednesday";
                }
                if (MTDayWeek == 3)
                {
                    if (MMOsettings.LANG == "RU") MTDayWeekTXT = "Четверг";
                    if (MMOsettings.LANG == "EN") MTDayWeekTXT = "Thursday";
                }
                if (MTDayWeek == 4)
                {
                    if (MMOsettings.LANG == "RU") MTDayWeekTXT = "Пятница";
                    if (MMOsettings.LANG == "EN") MTDayWeekTXT = "Friday";
                }
                if (MTDayWeek == 5)
                {
                    if (MMOsettings.LANG == "RU") MTDayWeekTXT = "Суббота";
                    if (MMOsettings.LANG == "EN") MTDayWeekTXT = "Saturday";
                }
                if (MTDayWeek == 6)
                {
                    if (MMOsettings.LANG == "RU") MTDayWeekTXT = "Воскресенье";
                    if (MMOsettings.LANG == "EN") MTDayWeekTXT = "Sunday";
                }


            }

            //
            MThourSlot.GetComponent<Text>().text = MThour+":00";
            MTDayWeekSlot.GetComponent<Text>().text = MTDayWeekTXT;

        }	
	}





}
