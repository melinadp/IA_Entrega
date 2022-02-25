using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAcontroller : MonoBehaviour
{

    //Target al que seguirá la IA
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
        //si la distancia entre al IA y el target es menor que 5, sigue al target
        if(Vector3.Distance(transform.position, target.position) < 5)
        {
            agent.destination = target.position;
        }else
        {
            //va a la posición de patrulla
             agent.destination = destinationPoints[destinationIndex].position;

             //si la distancia entre la IA y el destino es menor a 0.5
            if(Vector3.Distance(transform.position, destinationPoints[destinationIndex].position) <1f)
            {
            //mientras el Index sea inferior a la cantidad de puntos en el array pasa al siguiente punto
            if(destinationIndex < destinationPoints.Length -1)
            {
                //aumenta el index en 1
                destinationIndex++;
            }else
            {
                //si llega al maximo de puntos en el array los pone en 0
                destinationIndex = 0;
            }
            }
        }

    }
}