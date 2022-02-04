using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public int number_ag1;
    public int number_ag2;

    public GameObject prefab_ag1;
    public GameObject prefab_ag2;

    // Use this for initialization
    void Start()
    {
        Vector3 size = transform.localScale;
       // Debug.Log(size);
        Vector3 Pos = transform.position;


        for (int i = 0; i < number_ag1; i++)
        {
            GameObject instanceAgentA = (GameObject)Instantiate(prefab_ag1);
            instanceAgentA.transform.position = new Vector3
                (Random.Range(-size.x * 10f, size.x * 10f),
                size.y,
                Random.Range(-size.z * 10f, size.z * 10f));

        }

        for (int i = 0; i < number_ag2; i++)
        {
            GameObject instanceAgentB = (GameObject)Instantiate(prefab_ag2);
            instanceAgentB.transform.position = new Vector3(Random.Range(-size.x * 10f, size.x * 10f), size.y, Random.Range(-size.z * 10f, size.z * 10f));

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}