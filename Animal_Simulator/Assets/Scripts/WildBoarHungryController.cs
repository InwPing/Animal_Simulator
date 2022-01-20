using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
using System;


public class WildBoarHungryController : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    
    void Start()
    {
       // enemy = GetComponent<Enemy>();
    }

    void Update() // update hungrypoint every 1 second / hungrypoint -1 every 5 second
    {
        HungryController();
    }

    void HungryController()
    {
        BehaviorTree[] A = GetComponents<BehaviorTree>();   // stack behavoirTree in array A
        for (int i = 0; i < A.Length; i++)

            if (enemy.currentHungryPoint >= 80)
            {
                A[0].enabled = true;
                Debug.Log(A[0]);

            }
            else if ((50 < enemy.currentHungryPoint) && (enemy.currentHungryPoint < 80)) //eat plant only
            {
                A[0].enabled = false;
                A[1].enabled = true;
                Debug.Log(A[1]);
            }
            else if ((0 < enemy.currentHungryPoint) && (enemy.currentHungryPoint <= 50)) // eat both of plant & animal
            {
                A[0].enabled = false;
                A[1].enabled = false;
                A[2].enabled = true;
                Debug.Log(A[2]);
            }
            else if (enemy.currentHungryPoint <= 0)
            {
                enemy.Die();
            }
    }
}
