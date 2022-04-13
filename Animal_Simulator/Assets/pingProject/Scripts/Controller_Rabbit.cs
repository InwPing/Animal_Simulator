using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
using System;

public class Controller_Rabbit: MonoBehaviour
{

    [SerializeField] Enemy enemy;
    //[SerializeField] Climate climate;
    //[SerializeField] RabbitBuildCave RabbitBuildCave;

    //private GameObject cavePrefab;
    //public float caveDistance;
    //public LayerMask enemyLayers;

    void Start()
    {
        BehaviorTree[] behaviorTree = GetComponents<BehaviorTree>();
        behaviorTree[0].enabled = false;
        behaviorTree[1].enabled = false;
        behaviorTree[2].enabled = false;
        behaviorTree[3].enabled = false;
    }

    void Update()
    {
        ControlRabbit();
    }

    void ControlRabbit()
    {
        BehaviorTree[] behaviorTree = GetComponents<BehaviorTree>();
        

        if (enemy.currentHungryPoint >= 0.9f * enemy.maxHungryPoint)
        {
            // idle
            behaviorTree[0].enabled = true;
        }

        if (enemy.currentHungryPoint < 0.9f * enemy.maxHungryPoint)
        {
            // wander , follow sameTag
            behaviorTree[0].enabled = false;
            behaviorTree[1].enabled = true;

        }
        if (enemy.currentHungryPoint < 0.8f * enemy.maxHungryPoint)
        {
            //หิว
            behaviorTree[1].enabled = false;
            behaviorTree[2].enabled = true;
        }
        if (enemy.currentHealth < 0.9f * enemy.maxHungryPoint)
        {
            // วิ่งเข้าโพลง
            behaviorTree[2].enabled = false;
            behaviorTree[3].enabled = true;
        }
        
    }

    /*void buildCave() // ยังไม่เสด
    {
        Vector3 thisObjPos = transform.position;
        Collider[] Caves = Physics.OverlapSphere(thisObjPos, caveDistance, enemyLayers);
        foreach (Collider cave in Caves)
        {
            if (cave.name != "RabbitCave")
            {
                GameObject X = (GameObject)Instantiate(cavePrefab);
                X.transform.position = thisObjPos;
                StartCoroutine(Delay());

                Debug.Log("build cave");
            }
        }
    }*/
    
    public IEnumerator Delay()
    {       
        yield return new WaitForSeconds(2.0f);
    }
}
