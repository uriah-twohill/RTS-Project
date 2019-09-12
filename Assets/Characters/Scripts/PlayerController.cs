using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera camera;

    public NavMeshAgent agent;
    private Animator anim;


    


    private void Start()
    {
        anim = GetComponent<Animator>();
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

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(" Mouse Button Clicked");
            Ray ray =  camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("Coordinates Recieved");
            
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

        }    
        
    }
}
