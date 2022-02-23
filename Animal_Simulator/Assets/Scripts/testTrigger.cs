using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class testTrigger : MonoBehaviour
{
    [SerializeField] Collider thisCollider;
    Enemy enemy;

    [SerializeField] public GameObject prefab;

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

    public int timeYED;


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
                    /*foreach (GameObject agent in col)
                    {
                        agent.SetActive(true);

                        GameObject O = (GameObject)Instantiate(agent);
                        O.transform.position = genPos;

                        Destroy(agent);
                        col = new List<GameObject>();
                        //Destroy(agent);

                        thisCollider.enabled = true;
                    }*/
                    for (int i = 0;i < col.Count; i++ )
                    {
                        
                        GameObject O = (GameObject)Instantiate(prefab);
                        O.transform.position = genPos;
                        prefab.SetActive(true);
                        //Destroy(prefab);
                    }

                    col = new List<GameObject>();
                    //Destroy(prefab);
                    //DestroyImmediate(prefab, true);
                    thisCollider.enabled = true;
                }
                _timer = 0;
                TimerStarted = false;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //enemy = collider.GetComponent<Enemy>();
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
                enemy = collider.GetComponent<Enemy>();
                n.GetComponent<GameObject>();
                if (enemy.meetingTime > timeYED)
                {
                    enemy.meetingTime = 0;
                    col.Add(n);

                }
                //n.name = Name;
                //_timer = 0;
                //TimerStarted = true;

               // n.GetComponent<GameObject>();
                col.Add(n);
                n.SetActive(false);
                Destroy(n);



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
