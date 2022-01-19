using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryBar : MonoBehaviour
{
    public Slider slider;
    Enemy enemy;

    public int Hungry;

    private float time;

    void Start()
    {
        //Find
        slider = GetComponent<Slider>();
        enemy = FindObjectOfType<Enemy>();
    }

    void Update()
    {
        Hungry = enemy.currentHungryPoint;
        slider.value = Hungry;
    }
}