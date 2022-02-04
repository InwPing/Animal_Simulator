using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AgentFollowV3 : Action
    {
        public SharedString tag;
        public SharedString enemyTag;
        public SharedFloat speed;
        public SharedFloat search;
        public SharedFloat touchedDist;
        public SharedFloat fieldOfViewAngle = 360;

        private GameObject[] targetObjects;
        private GameObject[] myObjects;
        private GameObject[] enemyTags;
        private Vector3 prevDir;

        public override void OnStart()
        {
            base.OnStart();

            string a = gameObject.tag;
            Convert.ToInt32(a);


            targetObjects = GameObject.FindGameObjectsWithTag(tag.Value);
            if(enemyTags != null) 
            {
                enemyTags = GameObject.FindGameObjectsWithTag(enemyTag.Value);
            }

        }
        
        public override TaskStatus OnUpdate()
        {
            GameObject[] tags;
            tags = GameObject.FindGameObjectsWithTag(tag.Value);
            GameObject[] ETags;
            ETags = GameObject.FindGameObjectsWithTag(enemyTag.Value);

            GameObject closest = null;
            GameObject closestEnemy = null;

            float distance = Mathf.Infinity;
            float z = Mathf.Infinity;

            Vector3 position = transform.position;
            Vector3 dir = Vector3.zero;

            foreach (GameObject tag in tags)
            {
                Vector3 difftag = tag.transform.position - position;
                float curDistancetag = difftag.sqrMagnitude;
                if (curDistancetag < distance)
                {
                    closest = tag;
                    distance = curDistancetag;
                }                               
            }

            foreach (GameObject ETag in ETags)
            {
                Vector3 diffETag = ETag.transform.position - position;
                float curDistanceETag = diffETag.sqrMagnitude;
                if (curDistanceETag < z)
                {
                    closestEnemy = ETag;
                    z = curDistanceETag;

                }
            }

            if ((closest != null) & ((closestEnemy != null) || (closestEnemy == null)))
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;
                Vector3 toward = targetPos - currentPos;

                if (closestEnemy != null)
                {
                    Vector3 enemyPos = closestEnemy.transform.position;
                    Vector3 x = enemyPos - currentPos;
                    if (x.magnitude < search.Value)
                    {
                        return TaskStatus.Failure;
                    }
                }
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