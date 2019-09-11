using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera camera;

    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(" Mouse Button Clicked");
            Ray ray =  camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log
                ("Coordinates Recieved");

           if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                Debug.Log("moving to destination");
            }
            

        }
    }
}
