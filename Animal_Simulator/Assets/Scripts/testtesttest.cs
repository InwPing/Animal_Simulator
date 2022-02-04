using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtesttest : MonoBehaviour
{

    [SerializeField] Transform attackPoint;
    [SerializeField] float colliderRange = 0.5f;
    [SerializeField] LayerMask enemyLayers;

    [SerializeField] GameObject one;
    void Start()
    {
        /*
         Debug.Log(gameObject.name);
         Debug.Log(gameObject.tag);
         Debug.Log(gameObject.layer);
         Debug.Log(LayerMask.LayerToName(1 + 3));
        */


      // testLayer();
       // testTag();
    }
    

    void Update()
    {
        MeatIsEaten();
    }

    void testLayer()
    {
        Debug.Log(gameObject.layer);
        Debug.Log(one.layer);

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
        Convert.ToInt32(a);
        Debug.Log(Convert.ToInt32(a)+2);
    }

    void MeatIsEaten()
    {
        Collider[] hitObj = Physics.OverlapSphere(attackPoint.position, colliderRange, enemyLayers);
        Debug.Log("waiting for crash");
        foreach (Collider enemy in hitObj)
        {
            Debug.Log(enemy.transform.position);
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

        Gizmos.DrawWireSphere(attackPoint.position, colliderRange);
    }
}