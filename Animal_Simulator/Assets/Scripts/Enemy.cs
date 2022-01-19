using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using BehaviorDesigner.Runtime;



public class Enemy : MonoBehaviour
{
    // function : Start, Update, TakeDamage, Eat, Hungry, Die, OnCollisionEnter, 
    
    public int maxHealth = 100;
    public int currentHealth;
    public int maxHungryPoint = 100;
    public int currentHungryPoint;

    private static int z;
    private float time;

    void Start()
    {
        currentHealth = maxHealth;
        currentHungryPoint = maxHungryPoint;
    }

    void Update() // update hungrypoint every 1 second / hungrypoint -1 every 5 second
    {
        time += Time.deltaTime;
        int IntTime = Mathf.RoundToInt(time); // float time to int time
        if (IntTime % 2 == 0)
        {
            Hungry();
            time = 1;
        }
    }

    public void TakeDamage(int damage) // damage from AgentCombat Script
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Die I SUS");
    }

    void Hungry()
    {
        currentHungryPoint -= 1;
    }

    void Eat()
    {
        currentHungryPoint += 1000;
        //currentHealth += eatPoint/3;
    }

    private void OnTriggerEnter(Collider collider)  // cheack for eat
    {
        if (collider.gameObject.tag == "Plant")
        {
            Debug.Log("Die I SUS");
            Eat();
        }

    }    
}
