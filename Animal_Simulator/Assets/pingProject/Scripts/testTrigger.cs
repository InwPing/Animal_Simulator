using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class testTrigger : MonoBehaviour
{

    [SerializeField] private string Name;






    void Start()
    {
        
    }

    void Update()
    {
        
                
                   
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.name.Contains(Name))
        {
            collider.gameObject.layer = 31;
            Renderer colliRenderer = collider.GetComponent<Renderer>();
            colliRenderer.enabled = false;

            Debug.Log("rabbit is in");
        }


    }
    void OnTriggerExit(Collider other)
    {
        if (other.name.Contains(Name))
        {
            other.gameObject.layer = 7;
            Renderer otherRenderer = other.GetComponent<Renderer>();
            otherRenderer.enabled = true;


            Debug.Log("rabbit is out");
        }
    }


}
