using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRabbit : MonoBehaviour
{
    [SerializeField] GameObject Cave;
    [SerializeField] Enemy enemy;

    void Start()
    {
        Enemy enemy = gameObject.GetComponent<Enemy>();        
    }

    // Update is called once per frame
    void Update()
    {
        int HungryPoint = enemy.currentHungryPoint;
        Vector3 cavePos = Cave.transform.position;

        if (HungryPoint > 90)
        {
            Debug.Log("go to cave for sleep");
        }
    }

    
}
