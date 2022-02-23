using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System;
//using BehaviorDesigner.Runtime;



public class Enemy : MonoBehaviour
{
    private Enemy enemy;
    private GameObject a;

    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;


    [SerializeField] public int maxHungryPoint;
    [SerializeField] public int currentHungryPoint;


    private int NumberOfMeat = 3;
    [SerializeField] public GameObject Meat = null;


    //[SerializeField] private static int z;
    [SerializeField] private float time;
    [SerializeField] public int meetingTime = 0;


    [SerializeField] public string Name;
    //[SerializeField] public GameObject agent;

    private Quaternion rotation = Quaternion.identity;
    private GameObject storeResult;
    private Vector3 genPos;

    public bool randomGen = false;
    private int genNum;
    private int Gen = 1;
    private int randomGenMin = 1;
    private int randomGenMax = 2;


    void Start()
    {
        gameObject.name = Name;
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

        if (currentHungryPoint < 0)
        {
            currentHungryPoint = 0;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
            DropMeat();
        }

    }

    public void TakeDamage(int damage) // damage from AgentCombat Script
    {
        currentHealth -= damage;
    }

    public void Eat(int healPoint)
    {
        currentHealth += 5;
        currentHungryPoint += healPoint;
        meetingTime += 1;
        Sex();
    }

    void Hungry()
    {
        currentHungryPoint -= 1;
        if (currentHungryPoint <= 0)
        {
            currentHungryPoint = 0;
            Destroy(gameObject);
        }
    }

    void DropMeat()
    {
        Vector3 thisPosition = transform.position;
        for (int i = 0; i < NumberOfMeat; i++)
        {
            GameObject rawMeat = (GameObject)Instantiate(Meat);
            rawMeat.transform.position = new Vector3(Random.Range(thisPosition.x + 2, thisPosition.x - 2), 0.5f, Random.Range(thisPosition.z + 2, thisPosition.z - 2));
        }
    }

    void Sex()
    {
        Vector3 thisPos = transform.position;
        if (meetingTime >= 5)
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject O = (GameObject)Instantiate(gameObject);
                O.transform.position = thisPos;
            }
                meetingTime = 0;
            
        }
    }

    /*private void OnTriggerEnter(Collider collider)
    {      
        if ((collider.name.Contains(Name)))
        {
            GameObject other = collider.gameObject;
            enemy = other.GetComponent<Enemy>();

            if (meetingTime > 1)
            {
                if (enemy.meetingTime > 1)
                {
                    if (randomGen)
                    {
                        genNum = Random.Range(randomGenMin, randomGenMax);
                    }
                    else
                    {
                        genNum = Gen;
                    }

                    Vector3 thisPos = transform.position;
                    for (int i = 0; i < 1; i++)
                    {
                        meetingTime = 0;
                        enemy.meetingTime = 0;
                        storeResult = GameObject.Instantiate(agent, thisPos, rotation) as GameObject;
                    }
                }
            }
        }       
    }*/
}
