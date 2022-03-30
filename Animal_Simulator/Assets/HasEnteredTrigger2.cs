using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success when an object enters the trigger. This task will only receive the physics callback if it is being reevaluated (with a conditional abort or under a parallel task).")]
    [TaskCategory("Physics")]
    public class HasEnteredTrigger2 : Conditional
    {
        [Tooltip("The object that entered the trigger")]
        public SharedGameObject otherGameObject;

        private bool enteredTrigger = false;

        public override TaskStatus OnUpdate()
        {
            if (enteredTrigger == true)
            {
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;

           // return enteredTrigger; 
        }

        public override void OnEnd()
        {
            enteredTrigger = false;
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == gameObject.tag)
            {
                //Debug.Log("my tag = " + gameObject.tag);
                //Debug.Log("that tag = " + other.gameObject.tag);
                otherGameObject.Value = other.gameObject;
                enteredTrigger = true;
            }
            else enteredTrigger = false;
        }

        public override void OnReset()
        {
            otherGameObject = null;
        }
    }
}