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
        for (int i = 0; i < behaviorTree.Length; i++)

            if (enemy.currentHungryPoint >= 80)
            {
                behaviorTree[0].enabled = true;
                behaviorTree[1].enabled = false;
                behaviorTree[2].enabled = false;
                //Debug.Log(behaviorTree[0]);

            }
            else if ((50 < enemy.currentHungryPoint) && (enemy.currentHungryPoint < 80)) //eat plant only
            {
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = true;
                behaviorTree[2].enabled = false;
            }
            else if ((0 < enemy.currentHungryPoint) && (enemy.currentHungryPoint <= 50)) // eat both of plant & animal
            {
                behaviorTree[0].enabled = false;
                behaviorTree[1].enabled = false;
                behaviorTree[2].enabled = true;
                //Debug.Log(behaviorTree[2]);               
            }

    }
}
