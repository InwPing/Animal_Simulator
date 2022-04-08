using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climate : MonoBehaviour
{
    CheckAllAgent checkAllAgent;
    [SerializeField] private float temperature; //ร้อนจัด
    [SerializeField] private float humidity;

    private float newTreeArrayLength;
    private float oldTreeArrayLength;

    [SerializeField] private float timePerMonth;
    [SerializeField] private float timePerDay;


    private int x;

    void Start()
    {
        humidity = 0.0f;
        oldTreeArrayLength = newTreeArrayLength;
        Humidity();
        Temperature();
    }

    void Update()
    {
        timePerMonth += Time.deltaTime; // 1 เดือนเปลี่ยนที
        timePerDay += Time.deltaTime; // 1วัน เปลี่ยนที

        Humidity();

        if (timePerMonth >=  24*30)
        {
            Temperature();
            timePerMonth = 0f;
        }
           
        if (timePerDay >= 24)
        {
            x = Random.Range(1, 3);
            calculateTemperature(x);
            timePerDay = 0;

        }
    }

    void Humidity() // ความชื้นในอากาส
    {
        newTreeArrayLength = GameObject.FindGameObjectsWithTag("tree").Length;
        if (newTreeArrayLength != oldTreeArrayLength)
        {
            humidity = newTreeArrayLength * 0.2f;
            oldTreeArrayLength = newTreeArrayLength;
        }
        else return;
    }
    void Temperature() // 3 เดือน
    {
        temperature = Random.Range(21, 39);
    }

    void calculateTemperature(int z)
    {        
        if (z == 1)
        {
            temperature = temperature + humidity;
            return;
        }
        
        if (z == 2)
        {
            temperature = temperature - humidity;
            return;
        }
    }
}
