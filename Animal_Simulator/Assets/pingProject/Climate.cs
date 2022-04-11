using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climate : MonoBehaviour
{
    CheckAllAgent checkAllAgent;
    [SerializeField] private float temperature; //ร้อนจัด
    [SerializeField] private float baseTemperature;
    [SerializeField] private float humidity;

    private float newTreeArrayLength;
    private float oldTreeArrayLength;

    private float timePerMonth;
    private float timePerDay;
    private float second;


    private int x;
    public string[] rainRate;
    private int newRate;
    private int lastRate;
    [SerializeField] int randomNum;

    private int gamrMonth = 1;
    private int gameYear = 1;   
    private int gameDay = 1;
    public int gameHour = 6;
    private int gameMinute = 0;
    private int gameSecond = 0;
   

    private bool gameClockPaused = false;

    private float gameTick = 0f;


    void Start()
    {
        rainRate = new string[10];
        newRate = 0;
        lastRate = newRate;
        humidity = 0.0f;
        oldTreeArrayLength = newTreeArrayLength;

        Humidity();
        Temperature();
        calculateTemperature();
    }

    void Update() //temperature อิงตามความชื้อกับช่วงเวลา (กลางวันกลางคือน) ความชื้นอิงอามต้นไม้ layer Crop tag Tree
    {
        if (!gameClockPaused)
        {
            GameTick();
        }

        //Rain();
        Humidity();
    }

    void Humidity() // ความชื้นในอากาส
    {
        newTreeArrayLength = GameObject.FindGameObjectsWithTag("Tree").Length;
        if (newTreeArrayLength != oldTreeArrayLength)
        {
            humidity = newTreeArrayLength * 0.2f;
            oldTreeArrayLength = newTreeArrayLength;
        }
        else return;
    }
    void Temperature() // 3 เดือน
    {
        baseTemperature = Random.Range(21, 30);
    }

    void calculateTemperature()
    {
        temperature =(baseTemperature - humidity ) + (float)gameHour / 12f;
    }
    /*void Rain()
    {
        if (lastRate != newRate)
        {
            Debug.Log(" if ");
            Debug.Log(newRate);
            for (int i = 0; i < newRate; i++)
            {
                Debug.Log(" for");
                rainRate[i] = "rainning";
                Debug.Log(" rainRate[i] " + i + " = " + rainRate[i]);

                randomNum = Random.Range(0, 10);

                if (rainRate[randomNum] == "rainning")
                {
                    Debug.Log("rainning");
                    lastRate = newRate;
                }
                else lastRate = newRate;
            }

            lastRate = newRate;
        }          
    }*/
    private void GameTick()
    {
        gameTick += Time.deltaTime;

        if (gameTick >= Settings.secondsPerGameSecond)
        {
            gameTick -= Settings.secondsPerGameSecond;

            UpdateGameSecond();

        }

    }
        

    private void UpdateGameSecond()
    {
        gameSecond++;

        if (gameSecond > 59)
        {
            gameSecond = 0;
            gameMinute++;

            if (gameMinute > 59)
            {
                gameMinute = 0;
                gameHour++;

                calculateTemperature();

                if (gameHour > 23)
                {
                    gameHour = 0;
                    gameDay++;

                    if (gameDay > 30)
                    {
                        gameDay = 1;
                        gamrMonth++;


                        if (gamrMonth > 12)
                        {
                            gamrMonth = 1;
                            gameYear++;

                            Temperature();

                            if (gameYear > 9999)
                            {
                                gameYear = 1;
                            }
                        }                           
                    }
                }
            }
        }
    }
}

