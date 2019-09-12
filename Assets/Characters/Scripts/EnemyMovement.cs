using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator anim;

    public GameObject herosWalls;

    



    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(herosWalls.transform.position);
        if (agent.hasPath == false)
        {
            anim.SetInteger("Transition", 13);
        }
        else if (agent.hasPath == true)
        {
            anim.SetInteger("Transition", 1);
        }

        

    }
}
