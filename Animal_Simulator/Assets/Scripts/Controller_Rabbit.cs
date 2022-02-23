using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
using System;

public class Controller_Rabbit: MonoBehaviour
{

    [SerializeField] Enemy enemy;

    void Start()
    {
        
    }

    void Update()
    {
        ControlRabbit();
    }

    void ControlRabbit()
    {
        BehaviorTree[] behaviorTree = GetComponents<BehaviorTree>();   // stack behavoirTree in array A
        //for (int i = 0; i < behaviorTree.Length; i++)
        //{
            
            if (enemy.meetingTime >= 3)
            {
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = false;
                behaviorTree[2].enabled = true;
            }

            if (enemy.currentHungryPoint >= 90)
            {
                //stay i n cave
                behaviorTree[0].enabled = true;
                behaviorTree[1].enabled = false;
                behaviorTree[2].enabled = false;
            }

            if (enemy.currentHungryPoint < 90)
            {
                // eat wander;
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = true;
                behaviorTree[2].enabled = false;
            }

            if (enemy.currentHealth < 40)
            {
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = false;
                behaviorTree[2].enabled = true;
            }
        //}
    }
}
