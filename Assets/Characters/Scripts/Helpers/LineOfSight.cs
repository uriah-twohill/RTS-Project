using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LineOfSight : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Transform currentTarget;
    public UnitStats unitStats;
    private Transform[] playerUnits;



    public void Start()
    { 
        
    }
    public void Update()
    {

        navAgent.destination = currentTarget.position;

        var distance = (transform.position - playerUnits[0].position).magnitude;

        if (distance <= unitStats.lineOfSight)
        {
            PursuePlayer();
        }
    }

    public void PursuePlayer()
    {

    }



}
