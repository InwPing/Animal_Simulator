using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class AgentFollowV4 : Action         // follow with Tag and Layer
    {
        [Tooltip("Tag for target objects")]
        public SharedString tag;
        [Tooltip("The speed of the agent")]
        public SharedFloat speed;
        [Tooltip("Search area")]
        public SharedFloat search;
        [Tooltip("Touched distance")]
        public SharedFloat touchedDist;

        public SharedInt layer;


        private GameObject[] targetObjects;
        private Vector3 prevDir;



        public override void OnStart()
        {
            base.OnStart();

            //targetObjects = GameObject.FindGameObjectsWithTag(tag.Value);

        }



        public override TaskStatus OnUpdate()
        {
            GameObject[] TargetTags;
            TargetTags = GameObject.FindGameObjectsWithTag(tag.Value);

            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position; // this obj position
            foreach (GameObject TargetTag in TargetTags)
            {
                Debug.Log("TargetTag Layer = " + TargetTag.layer); // ++ 


                Vector3 diff = TargetTag.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = TargetTag;
                    distance = curDistance;
                }
            }

            //Debug.Log(closest);


            Vector3 dir = Vector3.zero;
            if (closest != null && closest.layer == layer.Value) // ++ 
            {
                Vector3 targetPos = closest.transform.position;
                Vector3 currentPos = transform.position;

                Vector3 toward = targetPos - currentPos;
                if (toward.magnitude < touchedDist.Value)
                {
                    var destroyGameObject = GetDefaultGameObject(closest);
                    GameObject.DestroyImmediate(destroyGameObject, true);


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


    }
}