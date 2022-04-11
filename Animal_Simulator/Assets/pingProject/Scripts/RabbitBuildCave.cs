using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBuildCave : MonoBehaviour
{

    public float colliderRange;
    public LayerMask enemyLayers;
    public string Tag;
    public int spaceAnotherCave = 15;

    [SerializeField] private float timeClock;
    [SerializeField] public GameObject Cave = null;

    void Start()
    {

    }

    void Update()
    {
        if (colliderRange < spaceAnotherCave)
        {
            colliderRange = spaceAnotherCave;
            Debug.Log("colliderRange must >= spaceAnotherCave");
        }
        TimeClock();
    }

    void TimeClock()
    {
        timeClock += Time.deltaTime;
        if (timeClock >= 1.0f)
        {
            GenerateCave();
            //timeClock = 0.0f;            
        }
    }

    void GenerateCave()
    {
        Vector3 thisObjPos = transform.position;
        if (timeClock >= 5.0f)
        {
            GameObject X = (GameObject)Instantiate(Cave);
            X.transform.position = thisObjPos;

           
            timeClock = 0.0f;
        }

        Collider[] hitObj = Physics.OverlapSphere(thisObjPos, colliderRange, enemyLayers);
        foreach (Collider Object in hitObj)
        {

            if (Object.tag == Tag)
            {
                Debug.Log("Not genCave");
                timeClock = 0.0f;
                return;
            }

            /*if (Object.tag != Tag)
            {
                Vector3 ObjPosition = Object.transform.position;
                Vector3 Distance = ObjPosition - thisObjPos;
                if (Distance.magnitude > spaceAnotherCave)
                {
                    Debug.Log("Not genCave");
                    for (int i = 0; i < 1; i++)
                    {
                        Debug.Log("genCave");
                        GameObject Obj = (GameObject)Instantiate(Cave);
                        Obj.transform.position = thisObjPos;

                        timeClock = 0.0f;
                    }
                }

            }*/
            timeClock = 0.0f;
            return;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, colliderRange);
        Gizmos.DrawWireSphere(transform.position, spaceAnotherCave);
    }
}
