using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBotCombat : MonoBehaviour
{

    // public Animator animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] public int attack;
    //[SerializeField] private string targetTag;



    void Start()
    {

    }

    void Update()
    {
    
        Attack();
    }

    void Attack()
    {
        // animator.SetTrigger("Attack");        
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<testPlantStatus>().TakeDamage(attack);
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
