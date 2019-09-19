using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestAnimationScript : MonoBehaviour {

    private Animator anim;

    public GameObject testCharacter;
    public Transform testCharacter1;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = 1;

        if (Input.GetKey("right"))
        {
            anim.SetInteger("Transition", 1);
        }
        if (Input.GetKey("1"))
        {
            anim.SetInteger("Transition", 2);
        }
        if (Input.GetKey("2"))
        {
            anim.SetInteger("Transition", 3);
        }
        if (Input.GetKey("3"))
        {
            anim.SetInteger("Transition", 4);
        }
    }
}
