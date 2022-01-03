using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int maxHungryPoint = 100;
    public int currentHungryPoint;

    private float time;

    void Start()
    {
        currentHealth = maxHealth;
        currentHungryPoint = maxHungryPoint;
    }

    void Update()
    {
        time += Time.deltaTime;
        int IntTime = Mathf.RoundToInt(time);
        if (IntTime % 5 == 0)
        {
            Hungry();
            time = 1;
        }
    }

    public void TakeDamage(int damage)
    {  
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Die I SUS");
    }

    void Hungry()
    {
        currentHungryPoint -= 1;

        //if currentHungryPoint > 80 dont eat
        //if currentHungryPoint < 80 eat plant only
        //if currentHungryPoint < 50 eat both of plant & animal
    }
}
