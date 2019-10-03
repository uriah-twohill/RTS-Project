using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyMovement : MonoBehaviour
{
    GameObject[] heros;
    public NavMeshAgent agent;
    private Animator anim;
    public GameObject herosWalls;
    float distance = float.MaxValue, attackRange= 10f;
    GameObject target = null;
    public bool inCombat = false;

    private void Start()
    {
        heros = GameObject.FindGameObjectsWithTag("playerUnit");
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
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            findTarget();
        }
        if(target != null)
        {
            if(Vector3.Distance(gameObject.transform.position,target.transform.position) <= attackRange)
            {
                agent.SetDestination(target.transform.position);
            }
        }
    }

    void findTarget()
    {
        distance = float.MaxValue;
        for (int i = 0; i < heros.Length; i++)
        {
            if (Vector3.Distance(gameObject.transform.position, heros[i].transform.position) < distance)
            {
                distance = Vector3.Distance(gameObject.transform.position, heros[i].transform.position);
                target = heros[i];
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "playerUnit")
        {
            inCombat = true;
            Debug.Log("VillainAttacking");
            anim.SetInteger("Transition", 2);
             findTarget();
            RectTransform[] o = target.GetComponentsInChildren<RectTransform>();
            for (int i = 0; i < o.Length; i++)
            {
                if (o[i].name.Equals("HealthBar"))
                {
                    target.GetComponent<UnitController>().setHealth(target.GetComponent<UnitController>().getHealth() - 0.1f);
                    if (target.GetComponent<UnitController>().getHealth() <= 0) target.GetComponent<UnitController>().setHealth(0);
                    o[i].transform.localScale = new Vector3(target.GetComponent<UnitController>().getHealth() / 100, o[i].transform.localScale.y, o[i].transform.localScale.z);
                    break;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "playerUnit")
        {
            inCombat = false;
        }
    }

}
