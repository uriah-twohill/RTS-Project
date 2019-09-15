using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;

    private NavMeshAgent nav;
    private SphereCollider col;
    private Animator anim;
    private LastPlayerSighting lastPlayerSighting;
    public GameObject playerUnit;
    private Animator playerAnim;
    private Health health;
    private HashIDs hash;
    private Vector3 previousSighting;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
        playerAnim = playerUnit.GetComponent<Animator>();
        health = playerUnit.GetComponent< Health >();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

        personalLastSighting = lastPlayerSighting.resetPosition;
        previousSighting = lastPlayerSighting.resetPosition;

        previousSighting = lastPlayerSighting.position;

        if (health.currentHealth > 0f)
            anim.SetBool(hash.playerInSightBool, playerInSight);
        else
            anim.SetBool(hash.playerInSightBool, false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "playerUnit")
        {
            Debug.Log("tracking working");
            playerInSight = false;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;

                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if (hit.collider.gameObject == playerUnit)
                    {
                        playerInSight = true;
                        lastPlayerSighting.position = playerUnit.transform.position;
                        Debug.Log("tracking working");
                    }
                }
            }

            int playerLayerZeroStateHash = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;
            int playerLayerOneStateHash = playerAnim.GetCurrentAnimatorStateInfo(1).fullPathHash;

            if (playerLayerZeroStateHash == hash.locomotionState || playerLayerOneStateHash == hash.shoutState) ;
            {
                if(CalculatePathLength(playerUnit.transform.position) <= col.radius)
                {
                    personalLastSighting = playerUnit.transform.position;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerUnit)
            playerInSight = false;
    }

    float CalculatePathLength(Vector3 targetPosition)
    {
        NavMeshPath path = new NavMeshPath();

        if(nav.enabled)
        nav.CalculatePath(targetPosition, path);

        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        for(int i=0; i<path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        float pathLength = 0f;

        for(int i=0; i<allWayPoints.Length; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }

        return pathLength;
    }

}
