using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{    

    public class Wander2 : Action
    {
        public float step;

        [Tooltip("Minimum distance ahead of the current position to look ahead for a destination")]
        public SharedFloat minWanderDistance = 20;
        [Tooltip("Maximum distance ahead of the current position to look ahead for a destination")]
        public SharedFloat maxWanderDistance = 20;
        [Tooltip("The amount that the agent rotates direction")]
        public SharedFloat wanderRate = 2;

        public LayerMask crashLayers;
        public string crashObjectName;
        public float colliderRange;
        public SharedFloat fieldOfViewAngle = 360;

        //public float PauseTime = 0;


        private Vector3 destination = Vector3.zero;
        private Vector3 direction = Vector3.zero;

        public float time = 4;


        public override void OnStart()
        {
            base.OnStart();
        }

        // There is no success or fail state with wander - the agent will just keep wandering
        public override TaskStatus OnUpdate()
        {
            time -= Time.deltaTime;
            Collider[] Objects = Physics.OverlapSphere(transform.position, colliderRange, crashLayers);
            foreach (Collider Object in Objects)
            {
                if (Object.tag.Contains(crashObjectName))
                {
                    Debug.Log("crash");
                    destination = destination * (-1);
                }
            }

            if (direction == Vector3.zero)
            {
                direction = transform.forward + Random.insideUnitSphere * wanderRate.Value;
                direction.y = 1;

                if (destination == Vector3.zero)
                {
                    destination = transform.position + direction.normalized * Random.Range(minWanderDistance.Value, maxWanderDistance.Value);
                    destination.y = 1;
                }              
            }

            if (destination != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, step * Time.deltaTime);
            }
            
            if (transform.position.y != 1)
            {
                gameObject.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            }

            if (time <= 0)
            {
                destination = Vector3.zero;
                direction = Vector3.zero;
                time = 5;
            }

            if (transform.position == destination)
            {
                destination = Vector3.zero;
                direction = Vector3.zero;
                time = 5;
            }
            
            return TaskStatus.Running;
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
            UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, colliderRange);

            UnityEditor.Handles.color = oldColor;
#endif
        }


        // Reset the public variables
        public override void OnReset()
        {
            minWanderDistance = 20;
            maxWanderDistance = 20;
            wanderRate = 2;
        }
    }
}