using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]

    public class DetectObjects : Conditional
    {
        public SharedString Mytag;
       // public Transform attackPoint;
        public float colliderRange;
        public LayerMask enemyLayers;

        public SharedFloat fieldOfViewAngle = 360;
        public SharedFloat search;


        private float x;
        private float y;
        

        public SharedString returnTag;

        public override void OnStart()
        {
            search.Value = colliderRange;
        }

        public override TaskStatus OnUpdate()
        {
            Vector3 thisObjPos = transform.position;


            Collider[] hitObj = Physics.OverlapSphere(thisObjPos, colliderRange, enemyLayers);
            foreach (Collider enemy in hitObj)
            {
                string a = Mytag.Value;
                x = float.Parse(a);
                //x = Convert.ToInt32(a);

                string b = enemy.tag;
                y = float.Parse(b);
                //y = Convert.ToInt32(b);

               //Debug.Log(enemy.transform.position);

                if (x > y)
                {
                    returnTag.Value = enemy.tag;
                    return TaskStatus.Success;
                }
                if ( x <= y)
                {
                    returnTag.Value = enemy.tag;
                    return TaskStatus.Failure;
                }
                

                if (Mytag == null)
                {
                    Debug.Log("nullllllllllll");
                }
                return TaskStatus.Failure;
            }

            //if (x > y)
            //{            
                //return TaskStatus.Success;
            //}

           return TaskStatus.Failure;
        }

        public override void OnDrawGizmos()
        {
#if UNITY_EDITOR
            var oldColor = UnityEditor.Handles.color;
            var color = Color.yellow;
            color.a = 0.1f;
            UnityEditor.Handles.color = color;

            var halfFOV = colliderRange * 0.5f;
            var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
            //UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, colliderRange, enemyLayers);
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, search.Value);


            UnityEditor.Handles.color = oldColor;
#endif
        }
    }
}