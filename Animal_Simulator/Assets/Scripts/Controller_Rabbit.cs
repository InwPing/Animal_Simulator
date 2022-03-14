using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
using System;

public class Controller_Rabbit: MonoBehaviour
{

    [SerializeField] Enemy enemy;
    [SerializeField] RabbitBuildCave RabbitBuildCave;

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
            
            if (enemy.currentHungryPoint >= 90) // อิ่ม
            {
                //stay i n cave
                behaviorTree[0].enabled = true;
                behaviorTree[1].enabled = false;
                behaviorTree[2].enabled = false;
                if (enemy.currentHealth >= ((80/ enemy.maxHealth)*100))
                {
                    RabbitBuildCave.enabled = true;
                }
                else RabbitBuildCave.enabled = false;
            }

            if (enemy.currentHungryPoint < 90) // เริ่มหิว
            {
                // eat wander;
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = true;
                behaviorTree[2].enabled = false;
            }

            if (enemy.currentHealth < 40) // เลือดน้อย
            {
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = false;
                behaviorTree[2].enabled = true;
            }

            if (enemy.countEat >= 3)
            {
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = false;
                behaviorTree[2].enabled = true;
            }
        //}
    }
}
