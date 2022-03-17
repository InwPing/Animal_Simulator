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

        public bool isRunning = false;

        private float pauseTime;
        private float destinationReachTime;
        private Vector3 destination = Vector3.zero;
        private Vector3 direction = Vector3.zero;

        public float time = 5;

        public override void OnStart()
        {
            base.OnStart();
        }

        // There is no success or fail state with wander - the agent will just keep wandering
        public override TaskStatus OnUpdate()
        {
            if (direction == Vector3.zero)
            {
                direction = transform.forward + Random.insideUnitSphere * 20;
                direction.y = 1;
                Debug.Log("direction = " + direction);

                if (destination == Vector3.zero)
                {
                    destination = transform.position + direction.normalized * Random.Range(minWanderDistance.Value, maxWanderDistance.Value);
                    destination.y = 1;
                    Debug.Log("destination = " + destination);
                }                   
            }

            time -= Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination, step * Time.deltaTime);

            if (transform.position.y != 1)
            {
                transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            }

            if (time <= 0)
            {
                Debug.Log("++++++++++++++++++++++++++++++++++++");
                destination = Vector3.zero;
                direction = Vector3.zero;
                time = 5;
            }

            if (transform.position == destination)
            {
                Debug.Log("___________________________________");
                destination = Vector3.zero;
                direction = Vector3.zero;
                time = 5;
            }

            Debug.Log("49");
            return TaskStatus.Running;
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