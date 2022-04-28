using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class Cave : MonoBehaviour
{
    public string Name;


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

            // สลับ layer ให้น้อยลง
            //Renderer colliRenderer = collider.GetComponent<Renderer>();
            //colliRenderer.enabled = false;            
        }


    }
    void OnTriggerExit(Collider other)
    {
        if (other.name.Contains(Name))
        {
            other.gameObject.layer = 7;

            // สลับ layer ให้เท่าเดิม
            //Renderer otherRenderer = other.GetComponent<Renderer>();
            //otherRenderer.enabled = true;            
        }
    }


}
