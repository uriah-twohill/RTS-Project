using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int dyingState;
    public int deadBool;
    public int playerInSightBool;
    public int locomotionState;
    public int shoutState;

    private void Awake()
    {
        dyingState = Animator.StringToHash("Base Layer.Dying");
        deadBool = Animator.StringToHash("Dead");
        locomotionState = Animator.StringToHash("Base Layer.Locomotion");
        shoutState = Animator.StringToHash("Shouting.Shout");
    }


}
