using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAi : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;

    private float lastXVal;
    private bool isInChaseRange;


    void Start()
    {
        lastXVal = transform.position.x;
        GameObject PL = GameObject.FindWithTag("Player");
        if (PL != null)
        {
            rb = PL.GetComponent<Rigidbody>();
        }

        GameObject a = GameObject.FindWithTag("sprite");
        if (a != null)
        {
            anim = a.GetComponent<Animator>();
        }
    }
    void Update()
    {

        //if (transform.hasChanged)
        //{            
        //Debug.Log("anim.SetBool");

            if (transform.position.x < lastXVal) //เดินซ้าย
            {
                anim.SetBool("walkRight", false);
                anim.SetBool("walkLeft", true);
                Debug.Log("Left");
                lastXVal = transform.position.x;
            }

            else if (transform.position.x > lastXVal) //เดินขวา
            {
                anim.SetBool("walkRight", true);
                anim.SetBool("walkLeft", false);
                Debug.Log("Right");
                lastXVal = transform.position.x;
            }

           //transform.hasChanged = false;
        //}
        
    }
}
