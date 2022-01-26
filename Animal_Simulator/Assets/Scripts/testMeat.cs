using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMeat : MonoBehaviour  // meat can heal obj that collider;
{
    //[SerializeField] Enemy enemy;
    [SerializeField] public int heal = 20;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayers;

    void Start()
    {
       // Enemy enemy = gameObject.GetComponent<Enemy>();       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MeatDrop();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject)
        {
            MeatDrop();
            /*GameObject x = collider.gameObject;
            heal = 20;
            hungry = 10;
            enemy.GetComponent<Enemy>().GetHeal(heal, hungry);*/
        }
    }

    void MeatDrop()
    {
        Collider[] hitObj = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitObj)
        {
            enemy.GetComponent<Enemy>().GetHeal(heal);
            Debug.Log("we heal " + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
