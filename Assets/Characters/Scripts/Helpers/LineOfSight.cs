using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LineOfSight : MonoBehaviour
{
    NavMeshAgent agent;
    public UnitStats unitStats;
    private Animator anim;

    private void Update()
    {
        anim = GetComponent<Animator>();
    }

   


}
