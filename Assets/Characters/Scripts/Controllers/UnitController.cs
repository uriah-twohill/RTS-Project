using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class UnitController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Transform currentTarget;
    private Animator anim;
    private float attackTimer, health;
    public UnitStats unitStats;

    public void Start()
    {
        health = 100f;
        navAgent = GetComponent<NavMeshAgent>();
        attackTimer = unitStats.attackSpeed;
        anim = GetComponent<Animator>();
        anim.SetInteger("Transition", 13);
    }
    private void Update()
    {
        Die();
        attackTimer += Time.deltaTime;
        if (currentTarget != null)
        {
            if (currentTarget.GetComponent<UnitController>() != null)
            {
                if (currentTarget.GetComponent<UnitController>().getHealth() > 0)
                {
                    navAgent.destination = currentTarget.position;

                    var distance = (transform.position - currentTarget.position).magnitude;

                    if (distance <= unitStats.attackRange)
                    {
                        Attack();
                    }
                    else
                    {
                        runAnimation();
                    }
                }
                else currentTarget = null;
            }
        }
        else if (gameObject.tag.Equals("playerUnit")) runAnimation();
    }

    void runAnimation()
    {
        if (navAgent.remainingDistance <= 2)
        {
            anim.SetInteger("Transition", 13);
        }
        if (navAgent.remainingDistance > 2)
        {
            anim.SetInteger("Transition", 1);
        }
    }

    public void MoveUnit(Vector3 dest)
    {
        currentTarget = null;
        navAgent.destination = dest;
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
            gameObject.transform.LookAt(currentTarget.transform.position);
            //RTSGameManager.UnitTakeDamage(this, currentTarget.GetComponent<UnitController>());
            RectTransform[] o = currentTarget.GetComponentsInChildren<RectTransform>();
            for (int i = 0; i < o.Length; i++)
            {
                if (o[i].name.Equals("HealthBar"))
                {
                    currentTarget.GetComponent<UnitController>().setHealth(currentTarget.GetComponent<UnitController>().getHealth() - 10);
                    if (currentTarget.GetComponent<UnitController>().getHealth() <= 0) currentTarget.GetComponent<UnitController>().setHealth(0);
                    o[i].transform.localScale = new Vector3(currentTarget.GetComponent<UnitController>().getHealth() / 100, o[i].transform.localScale.y, o[i].transform.localScale.z);
                    break;
                }
            }
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
            renderer.material.color = Color.red;
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
    public void setHealth(float nHealth)
    {
        health = nHealth;
    }
    public float getHealth()
    {
        return health;
    }

    public void Die()
    {
        if (health <= 0)
        {
            anim.SetInteger("Transition", 9);
          //  SceneManager.LoadScene("GameOver");
        }
    }
}
