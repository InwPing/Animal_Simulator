using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    Enemy enemy;

    void Start()
    {
        //Find
        slider = GetComponent<Slider>();
        enemy = FindObjectOfType<Enemy>();
    }

    void Update()
    {
        int Health = enemy.currentHealth;
        slider.value = Health;
    }
}
