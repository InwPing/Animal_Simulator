using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System;
//using BehaviorDesigner.Runtime;



public class Enemy : MonoBehaviour
{

    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    private int minHealth = 0;

    [SerializeField] public int maxHungryPoint;
    [SerializeField] public int currentHungryPoint;
    private int minHungryPoint = 0;

    private int NumberOfMeat = 3;
    [SerializeField] public GameObject Meat = null;


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
        if (currentHealth >= maxHealth) // check currentHealth dont over maxHealth
        {
            currentHealth = maxHealth;
        }
        if (currentHungryPoint >= maxHungryPoint) // check currentHungryPoint dont over maxHungryPoint
        {
            currentHungryPoint = maxHungryPoint;
        }
        Die();
    }

    public void TakeDamage(int damage) // damage from AgentCombat Script
    {
        currentHealth -= damage;
    }

    public void Eat(int healPoint)
    {
        currentHealth += 5;
        currentHungryPoint += healPoint;

       // Debug.Log("we can get heal");       
    }

    public void Die()
    {
        if (currentHealth <= minHealth)
        {
            currentHealth = minHealth;
            Destroy(gameObject);
            DropMeat();
        }
    }

    void Hungry()
    {
        currentHungryPoint -= 1;
        if (currentHungryPoint <= minHungryPoint)
        {
            currentHungryPoint = minHungryPoint;
            //Destroy(gameObject);
        }
    }
    void DropMeat()
    {
        Vector3 thisPosition = transform.position;
        for (int i = 0; i < NumberOfMeat; i++)
        {
            GameObject rawMeat = (GameObject)Instantiate(Meat);
            rawMeat.transform.position = new Vector3(Random.Range(thisPosition.x + 2, thisPosition.x - 2), thisPosition.y, Random.Range(thisPosition.z + 2, thisPosition.z - 2));
        }
    }
}
