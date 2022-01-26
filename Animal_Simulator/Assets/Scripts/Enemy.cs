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
    }

    public void TakeDamage(int damage) // damage from AgentCombat Script
    {
        currentHealth -= damage;

        if (currentHealth < minHealth)
        {
            currentHealth = minHealth;
            DropMeat();
            Die();
        }
    }

    public void GetHeal(int healthPoint)
    {
        currentHealth += healthPoint;
        currentHungryPoint += 10;

        Debug.Log("we can get heal");

        /*if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        if(currentHungryPoint >= maxHungryPoint)
        {
            currentHungryPoint = maxHungryPoint;

            Debug.Log("we can get heal");
        }*/

    }

    public void Die()
    {
        Destroy(gameObject);
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
    void DropMeat()
    {
        Vector3 thisPosition = transform.position;
        //GameObject rawMeat = (GameObject)Instantiate(Meat);
        for (int i = 0; i < NumberOfMeat; i++)
        {
            GameObject rawMeat = (GameObject)Instantiate(Meat);
            rawMeat.transform.position = new Vector3(Random.Range(thisPosition.x + 2, thisPosition.x - 2), thisPosition.y, Random.Range(thisPosition.z + 2, thisPosition.z - 2));
        }
    }
}
