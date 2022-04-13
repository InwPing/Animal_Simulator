using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject
{
    [TaskCategory("Unity/GameObject")]
    [TaskDescription("Instantiates a new GameObject. Returns Success.")]
    public class InstantiateV2 : Action
    {
        public SharedGameObject targetGameObject;
        public SharedVector3 position;
        public SharedQuaternion rotation = Quaternion.identity;
        public SharedGameObject storeResult;
        public SharedInt Number = 1;

        public override TaskStatus OnUpdate()
        {
            if (Number != null)
            {
                for(int i = 0; i < Number.Value; i++)
                {

                    Vector3 thisPosition = transform.position;
                    GameObject X = GameObject.Instantiate(targetGameObject.Value);
                    X.transform.position = thisPosition;
                    Debug.Log(" InstantiateV2");

                    return TaskStatus.Success;
                    //storeResult.Value = GameObject.Instantiate(targetGameObject.Value, thisPosition, rotation.Value) as GameObject;
                }              
            }
            else Debug.Log(" Number is null put some value");
                 return TaskStatus.Failure;


        }

        public override void OnReset()
        {
            targetGameObject = null;
            position = Vector3.zero;
            rotation = Quaternion.identity;
        }
    }
}