using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class testTrigger : MonoBehaviour
{
    [SerializeField] Collider thisCollider;

    [SerializeField] public string Name;
    [SerializeField] public string Mytag;
    [SerializeField] public float colliderRange;
    [SerializeField] public LayerMask enemyLayers;

    private int x;
    private int y;

    private GameObject m;
    private GameObject n;

    public List<GameObject> col = new List<GameObject>();

    public int timeToActive;
   
    //private float time;
    //private int IntTime;
    //private bool timer;
    //private bool TimerStarted = false;
    //private bool status = false;

    public Vector3 genPos;

    bool TimerStarted = false;
    private float _timer;
    public float TimeIWantInSeconds = 10f;




    void Start()
    {
        thisCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (TimerStarted == false)
        {
            _timer = 0;
        }
        if (TimerStarted == true)
        {
            _timer += Time.deltaTime;
            if (_timer > TimeIWantInSeconds)
            {
                thisCollider.enabled = false;
                if (thisCollider.enabled == false)
                {
                    foreach (GameObject agent in col)
                    {
                        agent.SetActive(true);

                        GameObject O = (GameObject)Instantiate(agent);
                        O.transform.position = genPos;

                        Destroy(agent);
                        col = new List<GameObject>();

                        thisCollider.enabled = true;
                    }
                }
                _timer = 0;
                TimerStarted = false;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        x = Convert.ToInt32(Mytag);

        string b = collider.tag;
        y = Convert.ToInt32(b);

        if (x == y)
        {
            n = collider.gameObject;
            if (n.name.Contains(Name))
            {
                n.name = Name;
                _timer = 0;
                TimerStarted = true;

                Debug.Log(n.name);
                n.GetComponent<GameObject>();
                col.Add(n);
                n.SetActive(false);


            }
            else Debug.Log(n.name);
        }

        else if (x < y)
        {
            m = collider.gameObject;
            TimerStarted = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        TimerStarted = true;
    }


}
