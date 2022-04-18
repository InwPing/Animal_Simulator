using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace BehaviorDesigner.Runtime.Tasks.Movement
{    

    public class NewWander : Action
    {
        public SharedFloat speed;

        public SharedFloat minWanderDistance = 20;
        public SharedFloat maxWanderDistance = 20;
        public SharedFloat wanderRate = 2;
        public SharedFloat minPauseDuration = 0;
        public SharedFloat maxPauseDuration = 0;


        private Animator animator;
        private float lastXVal;
        private float time;
        private bool randomPos = false;
        private bool randomTime = false;
        private Vector3 newPos;
        public float pauseTime;

        public override void OnAwake()
        {
            GameObject a = this.gameObject.transform.GetChild(0).gameObject;
            animator = a.GetComponent<Animator>();
        }
        public override void OnStart()
        {
            lastXVal = transform.position.x;
            //_animator = gameObject.GetComponent<Animator>();
        }

        public override TaskStatus OnUpdate()
        {
            //Animation();
            if (maxPauseDuration.Value > 0)
            {
                if (randomTime == false)
                {
                    pauseTime = Random.Range(minPauseDuration.Value, maxPauseDuration.Value);
                    randomTime = true;                                      
                }

                if (randomTime == true)
                {
                    pauseTime -= Time.deltaTime;
                    if (pauseTime <= 0f)
                    {
                        if (randomPos == false)
                        {
                            newPos = Random.insideUnitSphere * wanderRate.Value;
                            newPos.y = 0;
                            Debug.Log(newPos);
                            randomPos = true;

                        }
                        if (randomPos == true)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, newPos, speed.Value * Time.deltaTime);
                            if (transform.position == newPos)
                            {
                                randomPos = false;
                                randomTime = false;
                            }
                        }
                    }
                }

            }
            else
            {
                if (randomPos == false)
                {
                    newPos = Random.insideUnitSphere * 10;
                    newPos.y = 0;
                    Debug.Log(newPos);
                    randomPos = true;

                }

                if (randomPos == true)
                {
                    transform.position = Vector3.MoveTowards(transform.position, newPos, speed.Value * Time.deltaTime);
                    if (transform.position == newPos)
                    {
                        randomPos = false;
                    }
                }
            }                      
            return TaskStatus.Running;
        }

        /*private void Animation()
        {
            if (transform.position.x < lastXVal) //เดินซ้าย
            {
                animator.SetBool("IsRabbitWalkRight", false);
                animator.SetBool("IsRabbitWalkLeft", true);
                lastXVal = transform.position.x;
            }

            else if (transform.position.x > lastXVal) //เดินขวา
            {
                animator.SetBool("IsRabbitWalkRight", true);
                animator.SetBool("IsRabbitWalkLeft", false);
                lastXVal = transform.position.x;
            }
            else if (transform.position.x == lastXVal)
            {
                animator.SetBool("IsRabbitWalkRight", false);
                animator.SetBool("IsRabbitWalkLeft", false);
                lastXVal = transform.position.x;
            }
        }*/

        // Reset the public variables
        public override void OnReset()
        {
            minWanderDistance = 20;
            maxWanderDistance = 20;
            wanderRate = 2;
        }
    }
}