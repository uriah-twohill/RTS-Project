using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera camera;

    public NavMeshAgent agent;
    private Animator anim;

    public Texture2D tex = null;

    public GameObject explosionEffect;
    public GameObject staff;


    public float cooldown;
    bool onCooldown = false;
    public float radius = 10f;
    public float explosionForce = 700;
    public Vector3 explosionOffset;


    void OnGUI()
    {
        //Gets coordinate our object on screen
        Vector3 scrPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //Sets texture for size, for example, 100x30
        GUI.DrawTexture(new Rect(scrPos.x - 100 / 2.0f, Screen.height - scrPos.y - 30 / 2.0f, 100, 30), tex, ScaleMode.StretchToFill);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        explosionOffset = (transform.TransformPoint(Vector3.forward * 5));
        //  if (agent.hasPath == false)
        //  {
        //      anim.SetInteger("Transition", 9);
        //  }            
        if (agent.hasPath == true)
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
        ExplosionAttack();
    }

    private void ExplosionEffect()
    {
         Instantiate(explosionEffect, explosionOffset, transform.rotation);
    }
    
    private void ExplosionAttack()
    {
        if (Input.GetKeyDown("e"))
        {

            anim.SetInteger("Transition", 3);
            // Show effect
            Invoke("ExplosionEffect", 2.05f);

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius);
                }
            }
        }
    }   
}
