using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyRadiusScript : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;


    public Transform[] player;
    public float walkingDistance = 10.0f;
    public float smoothTime = 25.0f;
    private float smoothVelocity = 1.0f;



    public bool isTouchingPlayer = false;
   // private Vector3 smoothVelocity = Vector3.zero;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {

        if(isTouchingPlayer == false)
        {
            MoveTwoards();
        }
            

    }

    private void MoveTwoards()
    {
        for (int i = 0; i <= 2; i++)
        {
            transform.LookAt(player[i]);
            float distance = Vector3.Distance(transform.position, player[i].position);
            if (distance < walkingDistance)
            {
                anim.SetInteger("Transition", 1);
                transform.position = Vector3.MoveTowards(transform.position, player[i].position, Time.deltaTime * 2);
            }
        }        
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "playerUnit")
        {
            isTouchingPlayer = true;
            anim.SetInteger("Transition", 2);
            Debug.Log("yo");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isTouchingPlayer = false;
        Debug.Log("hello");
    }


}