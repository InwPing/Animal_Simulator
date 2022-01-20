using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Enemy x;
    //Enemy enemy;

    void Start()
    {
        Enemy x = gameObject.GetComponent<Enemy>();
        //Find
        slider = GetComponent<Slider>();
       // enemy = FindObjectOfType<Enemy>();
    }

    void Update()
    {
        int Hungry = x.currentHungryPoint;
        slider.value = Hungry;
        slider.maxValue = x.maxHungryPoint;
    }
}