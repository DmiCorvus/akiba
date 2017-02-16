using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ПРИКРЕПЛЕН MMO/OTHER/trainWaiting

public class su_trainwait_QS : MonoBehaviour {
    //место назначения
    public static string destinationTrain;
    
    //ТАЙМЕР
    public static float startTimer;
    public static int intTime;

    public static bool trainRide;//поезд прибыл в центр
    public static GameObject trainWait; //

    void Start()
    {

        trainWait = GameObject.Find("trainWait");
        gameObject.SetActive(false);
    }

    void OnEnable()
    {   //Таймер смены времени
        startTimer = 7;
        intTime = 7;
        trainRide = false;
    }


	void Update ()
    {       //ТАЙМЕР ИДЕТ
            if (intTime > 0)
            {
            startTimer -= Time.deltaTime;
            intTime = (int)startTimer;
            }

            if (intTime == 0)
            {
            gameObject.SetActive(false);
            trainRide = true;
            su_train_LOC.Train();
            }   
    }
}
