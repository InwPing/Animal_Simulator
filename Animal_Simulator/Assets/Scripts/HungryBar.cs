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

        /*time += Time.deltaTime;
        int IntTime = Mathf.RoundToInt(time);
        if (IntTime % 5 == 0)
        {
            Hungry -= 1;
            time = 1;
            //if currentHungryPoint > 80 dont eat
            //if currentHungryPoint < 80 eat plant only
            //if currentHungryPoint < 50 eat both of plant & animal
        }     */   
    }
}