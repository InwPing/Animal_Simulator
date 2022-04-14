using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitAnimation : MonoBehaviour
{
    Enemy enemy;
    private Animator animator;
    private float lastXVal;
    // Start is called before the first frame update
    void Awake()
    {
        enemy = GetComponent<Enemy>();
        GameObject a = this.gameObject.transform.GetChild(0).gameObject;
        animator = a.GetComponent<Animator>();
    }
    void Start()
    {
        lastXVal = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }
    private void Animation()
    {
        if (transform.position.x == lastXVal)
        {
            animator.SetBool("IsRabbitWalkRight", false);
            animator.SetBool("IsRabbitWalkLeft", false);
            lastXVal = transform.position.x;
        }

        else if (transform.position.x < lastXVal) //เดินซ้าย
        {
            animator.SetBool("IsRabbitWalkRight", false);
            animator.SetBool("IsRabbitWalkLeft", true);
            lastXVal = transform.position.x;
        }

        else if (transform.position.x > lastXVal) //เดินขวา
        {
            animator.SetBool("IsRabbitWalkRight", true);
            animator.SetBool("IsRabbitWalkLeft", false);
            lastXVal = transform.position.x;
        }
        
        if(enemy.currentHealth <= 0)
        {
            animator.SetBool("IsRabbitDie", true);
        }

    }
}
