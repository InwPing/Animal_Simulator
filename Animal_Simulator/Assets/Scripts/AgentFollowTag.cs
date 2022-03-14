using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AgentFollowTag : Action
    {
        public string tag;
        public float colliderRange;
        public LayerMask enemyLayers;

        public SharedFloat speed;
        public SharedFloat search;
        public SharedFloat touchedDist;
        public SharedFloat fieldOfViewAngle = 360;

        private Vector3 prevDir;



        public override void OnStart()
        {
            base.OnStart();
            search = colliderRange;
        }

        public override TaskStatus OnUpdate()
        {

            GameObject closest = null;

            float distance = Mathf.Infinity;
            Vector3 dir = Vector3.zero;

            Vector3 thisObjPos = transform.position;
            Collider[] hitObj = Physics.OverlapSphere(thisObjPos, colliderRange, enemyLayers);
            foreach (Collider enemy in hitObj)
            {
                if(enemy.tag == tag)
                {
                    Vector3 difftag = enemy.transform.position - thisObjPos;
                    float curDistancetag = difftag.sqrMagnitude;
                    if (curDistancetag < distance)
                    {
                        closest = enemy.gameObject;
                        distance = curDistancetag;
                    }
                }
                
            }

            if (closest != null)
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;
                Vector3 toward = targetPos - currentPos;

               
                if (toward.magnitude <= touchedDist.Value)
                {
                    return TaskStatus.Success;
                }
                if (toward.magnitude < search.Value)
                {
                    dir += toward;
                }
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

        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            var oldColor = UnityEditor.Handles.color;
            var color = Color.yellow;
            color.a = 0.1f;
            UnityEditor.Handles.color = color;

            var halfFOV = fieldOfViewAngle.Value * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, search.Value);

            UnityEditor.Handles.color = oldColor;
#endif
        }
    }

}