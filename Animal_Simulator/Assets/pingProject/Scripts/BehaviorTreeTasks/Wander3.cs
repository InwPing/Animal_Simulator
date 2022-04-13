using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskDescription("Wander using the Unity NavMesh.")]
    [TaskCategory("Movement")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer-movement-pack/")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}WanderIcon.png")]
    public class Wander3 : NavMeshMovement
    {
        public float speed = 10;
        public SharedFloat minWanderDistance = 20;
        public SharedFloat maxWanderDistance = 20;
        public SharedFloat wanderRate = 2;
        public SharedFloat minPauseDuration = 0;
        public SharedFloat maxPauseDuration = 0;

        public SharedFloat search;

        private float pauseTime;
        private float destinationReachTime;
        private Vector3 prevDir;

        public override TaskStatus OnUpdate()
        {
            Vector3 dir = Vector3.zero;
            Vector3 currentPos = transform.position;
            Vector3 RandomPos = Random.insideUnitSphere * wanderRate.Value * Random.Range(minWanderDistance.Value, maxWanderDistance.Value);
            //transform.position = Vector3.MoveTowards(currentPos, RandomPos, speed * Time.deltaTime);

            Vector3 toward = currentPos - RandomPos;
            if (toward.magnitude < transform.position.magnitude)
            {
                return TaskStatus.Success;
            }
            if (toward.magnitude < search.Value)
            {
                dir += toward;
            }

            dir.Normalize();
            dir = dir * speed * Time.deltaTime;
            dir = Vector3.Lerp(prevDir, dir, 0.2f);
            transform.position += dir;
            prevDir = dir;

            return TaskStatus.Running;
        }

       

        // Reset the public variables
        public override void OnReset()
        {
            minWanderDistance = 20;
            maxWanderDistance = 20;
            wanderRate = 2;
            minPauseDuration = 0;
            maxPauseDuration = 0;
        }
    }
}