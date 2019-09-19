using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator anim;
    Health health;
    public GameObject herosWalls;

    public bool inCombat = false;
    


    private void Start()
    {
        anim = GetComponent<Animator>();
        agent.SetDestination(herosWalls.transform.position);
    }

    // Update is called once per frame
    void Update()
    {


        if (agent.hasPath == false && inCombat == false)
        {
            anim.SetInteger("Transition", 13);
        }
        else if (agent.hasPath == true && inCombat == false)
        {
            anim.SetInteger("Transition", 1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "playerUnit")
        {
            inCombat = true;
            Debug.Log("VillainAttacking");
            anim.SetInteger("Transition", 2);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "playerUnit")
        {
            inCombat = false;
        }
    }

}
