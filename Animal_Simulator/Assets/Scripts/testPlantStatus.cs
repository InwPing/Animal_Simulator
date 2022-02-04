using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System;
//using BehaviorDesigner.Runtime;



public class testPlantStatus : MonoBehaviour
{

    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    private int minHealth = 0;

    private int NumberOfitem = 3;
    [SerializeField] public GameObject Item = null;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update() // update hungrypoint every 1 second / hungrypoint -1 every 5 second
    {
    
        Die();
    }

    public void TakeDamage(int damage) // damage from AgentCombat Script
    {
        currentHealth -= damage;
    }
         
    public void Die()
    {
        if (currentHealth <= minHealth)
        {
            currentHealth = minHealth;
            Destroy(gameObject);
            DropItem();
        }
    }

    void DropItem()
    {
        Vector3 thisPosition = transform.position;
        for (int i = 0; i < NumberOfitem; i++)
        {
            GameObject item = (GameObject)Instantiate(Item);
            item.transform.position = new Vector3(Random.Range(thisPosition.x + 2, thisPosition.x - 2), thisPosition.y, Random.Range(thisPosition.z + 2, thisPosition.z - 2));
        }
    }
}
