using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class IsInNight : Conditional
    {
        Climate climate;

        public override void OnAwake()
        {
            GameObject a = GameObject.FindGameObjectWithTag("GameManager");

            climate = a.GetComponent<Climate>();
        }
        public override TaskStatus OnUpdate()
        {
            Debug.Log(climate.Hour);
            if (climate.gameHour >= 19)
            {
                //Debug.Log(climate.Hour);
                return TaskStatus.Success;
            }
            else return TaskStatus.Failure;
        }
    }
}

