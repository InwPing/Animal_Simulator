using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
using System;

public class Controller_Wolf : MonoBehaviour
{

    [SerializeField] Enemy enemy;

    void Start()
    {
        
    }

    void Update()
    {
        Controller();
    }
    void Controller()
    {
        BehaviorTree[] behaviorTree = GetComponents<BehaviorTree>();
        //for (int i = 0; i < behaviorTree.Length; i++)
        if (enemy.countEat >= 5)
        {
            behaviorTree[0].enabled = false;
            behaviorTree[1].enabled = false;
            behaviorTree[2].enabled = true;
            behaviorTree[3].enabled = false;
        }

        if (enemy.currentHungryPoint >= 200)
        {
            behaviorTree[0].enabled = true;
            behaviorTree[1].enabled = false;
            behaviorTree[2].enabled = false;
            behaviorTree[3].enabled = false;
        }

        if (enemy.currentHungryPoint < 200)
        {
            behaviorTree[0].enabled = false;
            behaviorTree[1].enabled = true;
            behaviorTree[2].enabled = false;
            behaviorTree[3].enabled = false;
            if (enemy.currentHealth < (40 / enemy.maxHealth) * 100)
            {
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = false;
                behaviorTree[2].enabled = false;
                behaviorTree[3].enabled = true;
            }
        }
    }
}
