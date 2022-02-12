using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
using System;

public class RabbitController : MonoBehaviour
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
        BehaviorTree[] behaviorTree = GetComponents<BehaviorTree>();   // stack behavoirTree in array A
        for (int i = 0; i < behaviorTree.Length; i++)
            if(enemy.currentHungryPoint >= 90)
            {
                //stay i n cave
                behaviorTree[0].enabled = true;
                behaviorTree[1].enabled = false;
            }
            else if (enemy.currentHungryPoint < 90)
            {
                // eat wander;
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = true;
            }          
            else if (enemy.currentHungryPoint <= 0)
            {
                enemy.Die();
            }
    }
}
