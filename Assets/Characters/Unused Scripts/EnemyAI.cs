using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform heroTransform;
    NavMeshAgent agent;
    Animator anim;


    void Start()
    {
        heroTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        float distance = Vector3.Distance(heroTransform.position, transform.position);
        if(distance > 2)
        {
            agent.SetDestination(heroTransform.position);
            anim.SetInteger("Transition", 1);
        }
        else
        {
            agent.updatePosition = false;
            anim.SetInteger("Transition", 3);
        }
    }
}
