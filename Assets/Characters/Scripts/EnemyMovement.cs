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
        agent.SetDestination(herosWalls.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        
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
