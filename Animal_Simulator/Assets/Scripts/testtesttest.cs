using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtesttest : MonoBehaviour
{
    public GameObject one;
    void Start()
    {
        /*
         Debug.Log(gameObject.name);
         Debug.Log(gameObject.tag);
         Debug.Log(gameObject.layer);
         Debug.Log(LayerMask.LayerToName(1 + 3));
        */


        testLayer();
        testTag();
    }
    

    void Update()
    {

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
}