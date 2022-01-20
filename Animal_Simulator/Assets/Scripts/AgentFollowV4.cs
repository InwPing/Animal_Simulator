using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AgentFollowV4 : Action
    {
        public SharedString tag;
        public SharedFloat fieldOfViewAngle = 360;
        public SharedFloat speed;
        public SharedFloat search;
        public SharedFloat touchedDist;

        private GameObject[] targetObjects;
        private Vector3 prevDir;

        public override void OnStart()
        {
            base.OnStart();
            targetObjects = GameObject.FindGameObjectsWithTag(tag.Value);
        }

        public override TaskStatus OnUpdate()
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag(tag.Value);

            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position; // this obj position
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            //Debug.Log("closest = " + closest);

            Vector3 dir = Vector3.zero;

            if (closest != null)
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;
                Vector3 toward = targetPos - currentPos;
                if (toward.magnitude <= touchedDist.Value)
                {
                    Debug.Log(" EAT " + closest.name);
                    //var destroyGameObject = GetDefaultGameObject(closest);
                   // GameObject.DestroyImmediate(destroyGameObject, true);

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