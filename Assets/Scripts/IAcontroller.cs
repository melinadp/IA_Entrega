using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAcontroller : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    public Transform[] destinationPoints;

    public int destinationIndex = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) < 5f)
        {
            agent.destination = target.position;

            if (Vector3.Distance(transform.position, target.position) < 2f)
            {
                Debug.Log("Ataque");
            }
        }
        else
        {
             agent.destination = destinationPoints[destinationIndex].position;

            if(Vector3.Distance(transform.position, destinationPoints[destinationIndex].position) <1f)
            {
                if(destinationIndex < destinationPoints.Length -1)
            {
                    destinationIndex++;
                }else
                {
                    destinationIndex = 0;
                }
            }
        }

    }
}