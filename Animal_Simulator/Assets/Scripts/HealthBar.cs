using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    Enemy enemy;

    public int Health;

    void Start()
    {
        //Find
        slider = GetComponent<Slider>();
        enemy = FindObjectOfType<Enemy>();
    }

    void Update()
    {
        Health = enemy.currentHealth;
        slider.value = Health;
    }
}
