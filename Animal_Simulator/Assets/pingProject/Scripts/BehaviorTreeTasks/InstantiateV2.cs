using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject
{
    [TaskCategory("Unity/GameObject")]
    [TaskDescription("Instantiates a new GameObject. Returns Success.")]
    public class InstantiateV2 : Action
    {
    
        public SharedGameObject targetGameObject;       
        private SharedQuaternion rotation = Quaternion.identity;
        [SharedRequired]       
        private SharedGameObject storeResult;
  
        public override TaskStatus OnUpdate()
        {
            Vector3 thisPosition = transform.position;
            storeResult.Value = GameObject.Instantiate(targetGameObject.Value, thisPosition, rotation.Value) as GameObject;

            return TaskStatus.Success;


        }
    }
}