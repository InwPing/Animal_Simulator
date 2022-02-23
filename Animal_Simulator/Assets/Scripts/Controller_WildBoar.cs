using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
using System;


public class Controller_WildBoar : MonoBehaviour
{

    [SerializeField] Enemy enemy;
    
    void Start()
    {

    }

    void Update() // update hungrypoint every 1 second / hungrypoint -1 every 5 second
    {
        HungryController();
    }

    void HungryController()
    {
        BehaviorTree[] behaviorTree = GetComponents<BehaviorTree>();   // stack behavoirTree in array A
                                                                       //for (int i = 0; i < behaviorTree.Length; i++)

        if (enemy.meetingTime >= 3)
        {
            behaviorTree[0].enabled = false;
            behaviorTree[1].enabled = false;
            behaviorTree[2].enabled = false;
            behaviorTree[3].enabled = true;
        }
        if (enemy.currentHungryPoint >= 200)
        {
            behaviorTree[0].enabled = true;
            behaviorTree[1].enabled = false;
            behaviorTree[2].enabled = false;
            behaviorTree[3].enabled = false;
            //Debug.Log(behaviorTree[0]);

        }
        if ((120 < enemy.currentHungryPoint) && (enemy.currentHungryPoint < 200)) //eat plant only
        {
            behaviorTree[0].enabled = false;
            behaviorTree[1].enabled = true;
            behaviorTree[2].enabled = false;
            behaviorTree[3].enabled = false;
        }
        if ((0 < enemy.currentHungryPoint) && (enemy.currentHungryPoint <= 120)) // eat both of plant & animal
        {
            behaviorTree[0].enabled = false;
            behaviorTree[1].enabled = false;
            behaviorTree[2].enabled = true;
            behaviorTree[3].enabled = false;
            //Debug.Log(behaviorTree[2]);               
        }
        if (enemy.currentHealth < 40)
        {
            behaviorTree[0].enabled = false;
            behaviorTree[1].enabled = false;
            behaviorTree[2].enabled = false;
            behaviorTree[3].enabled = true;
        }


    }
}
