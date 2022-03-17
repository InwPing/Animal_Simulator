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
    private Vector3 direction;
    private Vector3 destination;

    public float time;

    void Start()
    {
        direction = transform.position + Random.insideUnitSphere *20;
        direction.y = 1;
        destination = transform.position + direction.normalized * Random.Range(20, 20);
        Debug.Log(direction);

        
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
        float step = 3 * Time.deltaTime;
        //Vector3 direction = transform.position + Random.insideUnitSphere * 2;
        Vector3 destination = transform.position + direction.normalized * Random.Range(5, 5); // กำหนดเป้าหมาย
       
        transform.position = Vector3.MoveTowards(transform.position, destination, step);

        time -= Time.deltaTime;
 

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
