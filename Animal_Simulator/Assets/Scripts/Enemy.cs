using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System;
//using BehaviorDesigner.Runtime;



public class Enemy : MonoBehaviour
{
    // function : Start, Update, TakeDamage, Eat, Hungry, Die, OnCollisionEnter, 
    
    public int maxHealth;
    public int currentHealth;
    private int minHealth = 0;

    public int maxHungryPoint;
    public int currentHungryPoint;
    private int minHungryPoint = 0;

    public int NumberOfMeat =3;
    [SerializeField] private GameObject Meat = null;


    [SerializeField] private static int z;
    [SerializeField] private float time;

    void Start()
    {
        currentHealth = maxHealth;
        currentHungryPoint = maxHungryPoint;
    }

    void Update() // update hungrypoint every 1 second / hungrypoint -1 every 5 second
    {
        time += Time.deltaTime;
        int IntTime = Mathf.RoundToInt(time); // float time to int time
        if (IntTime % 2 == 0) // time for hungry
        {
            Hungry();
            time = 1;
        }
    }

    public void TakeDamage(int damage) // damage from AgentCombat Script
    {
        currentHealth -= damage;
        //if (currentHealth <= minHealth)
        {
        //    currentHealth = minHealth;
            Die();
        }
    }

    public void Die()
    {
        //drop meat
        Vector3 thisPosition = transform.position;
        GameObject rawMeat = (GameObject)Instantiate(Meat);
        for (int i = 0; i < NumberOfMeat; i++)
        {
            rawMeat.transform.position = new Vector3(Random.Range(thisPosition.x + 3, thisPosition.x - 3), thisPosition.y, Random.Range(thisPosition.z + 3, thisPosition.z - 3));
        }
    }

    void Hungry()
    {
        currentHungryPoint -= 1;
        if (currentHungryPoint <= minHungryPoint)
        {
            currentHungryPoint = minHungryPoint;
        }
    }

    void Eat()
    {
        currentHungryPoint += 40;
        //currentHealth += currentHungryPoint / 3;
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
