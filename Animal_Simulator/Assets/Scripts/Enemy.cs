using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public int maxHungryPoint = 100;
    int currentHungryPoint;

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
            currentHungryPoint -= 1;

            time = 1;
            //if currentHungryPoint > 80 dont eat
            //if currentHungryPoint < 80 eat plant only
            //if currentHungryPoint < 50 eat both of plant & animal
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
}
