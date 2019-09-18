using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Transform currentTarget;
    private Animator anim;

    private float attackTimer;

    public UnitStats unitStats;

    public void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        attackTimer = unitStats.attackSpeed;
        anim = GetComponent<Animator>();
        anim.SetInteger("Transition", 13);
    }
    private void Update()
    {
        attackTimer += Time.deltaTime;
        if(currentTarget != null)
        {
            navAgent.destination = currentTarget.position;

            var distance = (transform.position - currentTarget.position).magnitude;

            if(distance <= unitStats.attackRange)
            {
                Attack();
            }
        }
    }

    public void MoveUnit(Vector3 dest)
    {
        currentTarget = null;
        navAgent.destination = dest;
        if (navAgent.hasPath == false)
        {
            anim.SetInteger("Transition", 13);
        }
        if (navAgent.hasPath == true)
        {
            anim.SetInteger("Transition", 1);
        }
    }

    public void SetSelected(bool isSelected)
    {
        transform.Find("Highlight").gameObject.SetActive(isSelected);
    }

    public void SetNewTarget(Transform enemy)
    {
        currentTarget = enemy;
    }

    public void Attack()
    {
        if (attackTimer >= unitStats.attackSpeed)
        {
            anim.SetInteger("Transition", 2);
            RTSGameManager.UnitTakeDamage(this, currentTarget.GetComponent<UnitController>());
            attackTimer = 0;
        }
        
    }

    public void TakeDamage(UnitController enemy, float damage)
    {
        StartCoroutine(Flasher(GetComponent<Renderer>().material.color));
    }

    IEnumerator Flasher(Color defaultColor)
    {
        var renderer = GetComponent<Renderer>();
        for (int i = 0; i < 2; i++)
        {
            renderer.material.color = Color.gray;
            yield return new WaitForSeconds(.05f);
            renderer.material.color = defaultColor;
            yield return new WaitForSeconds(.05f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "idleTrigger")
        {
            anim.SetInteger("Transition", 13);
        }
    }
}
