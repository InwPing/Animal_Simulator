using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class testCave : MonoBehaviour
{
    [SerializeField] Collider a;

    void Start()
    {
        a = GetComponent<Collider>();

    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            a.isTrigger = true;
            Debug.Log("spacebar");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            a.isTrigger = false;
            Debug.Log("KeyCode.Up");
        }
    }
    

    private void OnTriggerEnter(Collider collider)  // cheack for eat
    {
        if (collider.gameObject.tag == "Herbivore")
        {
            Debug.Log("Herbivore");
            a.isTrigger = true;
        }
        if (collider.gameObject.tag == "Carnivore")
        {
            Debug.Log("Carnivore");
            a.isTrigger = false;
        }
    }
}
