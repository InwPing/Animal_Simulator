using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAi : MonoBehaviour
{
    public float speed;
    public bool shouldRotate;


    public Rigidbody rb;
    public Animator anim;
    private Vector3 movementV3;
    public Vector3 dir;

    private bool isInChaseRange;

    void Start()
    {
        //transform.Rotate(90, 0, 0);
        GameObject PL = GameObject.FindWithTag("Player");
        if (PL != null)
        {
            rb = PL.GetComponent<Rigidbody>();
            Debug.Log("Have PL");
        }
        //rb = GetComponent<Rigidbody>();

        GameObject a = GameObject.FindWithTag("sprite");
        if (a != null)
        {
            anim = a.GetComponent<Animator>();
            Debug.Log("Have Animator");
        }
        //anim = GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetBool("IsRunning", isInChaseRange);
        isInChaseRange = true;

        dir = transform.position;
        dir.Normalize();
        if (shouldRotate)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
            anim.SetFloat("Z", dir.z);
        }
    }
}
