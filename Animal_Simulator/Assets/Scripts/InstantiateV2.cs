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
        [SharedRequired]       
        public SharedGameObject storeResult;


        
        public SharedInt Gen = 1;       
        public SharedBool randomGen = false;
        public SharedInt randomGenMin = 1;
        public SharedInt randomGenMax = 1;

        private int genNum;


        private static int x;

        public override void OnStart()
        {
            if (randomGen.Value)
            {
                genNum = Random.Range(randomGenMin.Value, randomGenMax.Value);
            }
            else
            {
                genNum = Gen.Value;
            }
            Debug.Log("genNum" + genNum);
        }

        public override TaskStatus OnUpdate()
        {
            x = Counter.y;

            Vector3 thisPosition = transform.position;
            if ( x /7 == 0)
            {
                //Vector3 thisPosition = transform.position;
                for (int i = 0; i < genNum; i++)
                {
                    storeResult.Value = GameObject.Instantiate(targetGameObject.Value, thisPosition, rotation.Value) as GameObject;
                }
                return TaskStatus.Success;
            }

            return TaskStatus.Failure;
        }

        public override void OnReset()
        {
            targetGameObject = null;                   
            position = Vector3.zero;
            rotation = Quaternion.identity;

            Gen = 1;
            randomGen = false;
            randomGenMin = 1;
            randomGenMax = 1;
        }
    }
}