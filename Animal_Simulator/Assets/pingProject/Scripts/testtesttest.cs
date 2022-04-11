//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtesttest : MonoBehaviour
{

    [SerializeField] Transform attackPoint;
    [SerializeField] float colliderRange = 0.5f;
    [SerializeField] LayerMask enemyLayers;

    [SerializeField] GameObject one;
    private Vector3 thisPos;
    public Vector3 tarPos;
    float lastXVal;


    void Start()
    {

        lastXVal = transform.position.x;
        /*
         Debug.Log(gameObject.name);
         Debug.Log(gameObject.tag);
         Debug.Log(gameObject.layer);
         Debug.Log(LayerMask.LayerToName(1 + 3));
        */

        // testLayer();
        // testTag();
    }


    void Update() // 
    {
        if (transform.hasChanged)
        {
            if (transform.position.x < lastXVal)
            {
                Debug.Log("Decreased!");
                //Update lastXVal
                lastXVal = transform.position.x;
            }

            else if (transform.position.x > lastXVal)
            {
                Debug.Log("Increased");

                //Update lastXVal
                lastXVal = transform.position.x;
            }

            transform.hasChanged = false;
        }

        //MeatIsEaten();
    }

    void testLayer()
    {
        int a = gameObject.layer;
        int b = one.layer;

        Debug.Log(a);
        Debug.Log(b);

        if (a < b)
        {
            Debug.Log("a < b");
        }
        else
        {
            Debug.Log("kzdhfgaefgeaj");
        }
    }

    void testTag()
    {
        Debug.Log(gameObject.tag);
        string a = gameObject.tag;        
    }

    void MeatIsEaten()
    {
        Collider[] hitObj = Physics.OverlapSphere(attackPoint.position, colliderRange, enemyLayers);
        Debug.Log("waiting for crash");
        foreach (Collider enemy in hitObj)
        {
            Debug.Log(enemy.transform.position);
            Debug.Log(enemy.transform.rotation);
            Debug.Log(enemy.tag);
            Debug.Log(enemy.name);

        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(transform.position, 20);
    }

    
}
