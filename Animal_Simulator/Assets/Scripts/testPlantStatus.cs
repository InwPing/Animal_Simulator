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

    //private int NumberOfitem = 3;
    //[SerializeField] public GameObject Item = null;

    [SerializeField] public int heal = 20;
    [SerializeField] Transform eatenPoint;
    [SerializeField] float colliderRange = 2f;
    [SerializeField] LayerMask enemyLayers;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        IsEaten();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    /*void DropItem()
    {
        Vector3 thisPosition = transform.position;
        for (int i = 0; i < NumberOfitem; i++)
        {
            GameObject item = (GameObject)Instantiate(Item);
            item.transform.position = new Vector3(Random.Range(thisPosition.x + 2, thisPosition.x - 2), thisPosition.y, Random.Range(thisPosition.z + 2, thisPosition.z - 2));
        }
    }*/

    void IsEaten()
    {
        Collider[] hitObj = Physics.OverlapSphere(eatenPoint.position, colliderRange, enemyLayers);
        if (currentHealth < minHealth)
        {
            currentHealth = 0;
            if (currentHealth == 0)
            {
                foreach (Collider enemy in hitObj)
                {
                    enemy.GetComponent<Enemy>().Eat(heal);

                    Destroy(gameObject);

                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (eatenPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(eatenPoint.position, colliderRange);
    }
}