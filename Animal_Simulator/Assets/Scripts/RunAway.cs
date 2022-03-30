using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class RunAway : Action
    {
        public SharedString Mytag;
        public float colliderRange;
        public LayerMask enemyLayers;

        public SharedFloat speed;
        private SharedFloat runRange;

        private GameObject[] targetObjects;
        private Vector3 prevDir;

        private int x;
        private int y;
        private string a;
        private string b;

        public override void OnStart()
        {
            base.OnStart();
            runRange = colliderRange;
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 thisObjPos = transform.position;
            Collider[] gos = Physics.OverlapSphere(thisObjPos, colliderRange, enemyLayers);

            GameObject closest = null;
            float distance = Mathf.Infinity;

            foreach (Collider go in gos)
            {
                a = Mytag.Value;
                x = Convert.ToInt32(a);

                b = go.tag;
                y = Convert.ToInt32(b);

                if (x < y)
                {
                    Vector3 diff = go.transform.position - thisObjPos;
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < distance)
                    {

                        closest = go.gameObject;
                        distance = curDistance;
                    }
                }                  
            }


            Vector3 dir = Vector3.zero;
            if (closest != null)
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;

                Vector3 toward = targetPos - currentPos;

                if (toward.magnitude > runRange.Value)
                {

                    return TaskStatus.Success;
                }
                else dir -= toward;

            }

            dir.Normalize();
            dir = dir * speed.Value * Time.deltaTime;
            dir = Vector3.Lerp(prevDir, dir, 0.2f);
            transform.position += dir;
            prevDir = dir;


            return TaskStatus.Running;

        }

        public override void OnReset()
        {
            base.OnReset();

        }

    }
}