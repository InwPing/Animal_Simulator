using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.AgentSystem
{
    [TaskCategory("AgentSystem")]
    public class RunAway : Action
    {
        [Tooltip("Tag for target objects")]
        public SharedString tag;
        [Tooltip("The speed of the agent")]
        public SharedFloat speed;
        [Tooltip("Search area")]
        public SharedFloat search;
        [Tooltip("Touched distance")]
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
            Vector3 dir = Vector3.zero;

            foreach (GameObject targetObject in targetObjects)
            {
                Vector3 targetPos = targetObject.transform.position;
                Vector3 currentPos = transform.position; // this obj position

                Vector3 toward = targetPos - currentPos;
                if (toward.magnitude > search.Value)
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
    }
}