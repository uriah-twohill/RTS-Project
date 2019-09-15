using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElfAnimationTestScript : MonoBehaviour
{

    private Animator anim;

    public GameObject testCharacter;
    public Transform testCharacter1;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        //Walk
        if (Input.GetKeyDown("right"))
        {
            anim.SetInteger("Transition", 1);
        }
        //Attack 1
        if (Input.GetKeyDown("1"))
        {
            anim.SetInteger("Transition", 2);
        }
        //Attack 2
        if (Input.GetKeyDown("2"))
        {
            anim.SetInteger("Transition", 3);
        }
        //Attack 3
        if (Input.GetKeyDown("3"))
        {
            anim.SetInteger("Transition", 4);
        }
        //Airborne
        if (Input.GetKeyDown("4"))
        {
            anim.SetInteger("Transition", 5);
        }
        //Airborne Damage
        if (Input.GetKeyDown("5"))
        {
            anim.SetInteger("Transition", 6);
        }
        //Airborne Down
        if (Input.GetKeyDown("6"))
        {
            anim.SetInteger("Transition", 7);
        }
        //Airborne Splat
        if (Input.GetKeyDown("7"))
        {
            anim.SetInteger("Transition", 8);
        }
        //Death
        if (Input.GetKeyDown("d"))
        {
            anim.SetInteger("Transition", 9);
        }
        //Damage
        if (Input.GetKeyDown("backspace"))
        {
            anim.SetInteger("Transition", 10);
        }
        //Down
        if (Input.GetKeyDown("down"))
        {
            anim.SetInteger("Transition", 11);
        }
        //Attatch
        if (Input.GetKeyDown("left"))
        {
            anim.SetInteger("Transition", 12);
        }
        //Stand
        if (Input.GetKeyDown("space"))
        {
            anim.SetInteger("Transition", 13);
        }
        //Down Stand
        if (Input.GetKeyDown("s"))
        {
            anim.SetInteger("Transition", 14);
        }
        //Matinee Pose
        if (Input.GetKeyDown("p"))
        {
            anim.SetInteger("Transition", 15);
        }
        //Matinee Spawn2
        if (Input.GetKeyDown("g"))
        {
            anim.SetInteger("Transition", 16);
        //Pose
            if (Input.GetKeyDown("x"))
        {
            anim.SetInteger("Transition", 17);
        }
        //Stun
        if (Input.GetKeyDown("c"))
        {
            anim.SetInteger("Transition", 18);
        }
        
        }
    }
}
